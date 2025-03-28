using System.Net.Http;
using System.Text.Json;

namespace btcpairs
{
    public partial class Form1 : Form
    {
        private readonly HttpClient httpClient;
        private readonly string apiKey;
        private CancellationTokenSource? _cts;
        private readonly Dictionary<string, string> currencyPairs = new()
        {
            { "USD", "BTC/USD" },
            { "EUR", "BTC/EUR" },
            { "GBP", "BTC/GBP" },
            { "AUD", "BTC/AUD" },
            { "JPY", "BTC/JPY" },
        };

        public Form1()
        {
            InitializeComponent();

            // Initialize HttpClient
            httpClient = new HttpClient
            {
                Timeout = TimeSpan.FromSeconds(10) // Set timeout for API calls
            };

            // Load API key from environment variable
            apiKey = Environment.GetEnvironmentVariable("POLYGON_API_KEY") ?? string.Empty;

            // Apply dark theme only on Windows platforms
            if (OperatingSystem.IsWindowsVersionAtLeast(6, 1))
            {
                ApplyDarkTheme();
            }

            // Start timer for auto refresh (every 30 seconds)
            if (OperatingSystem.IsWindowsVersionAtLeast(6, 1))
            {
                var timer = new System.Windows.Forms.Timer
                {
                    Interval = 30000 // 30 seconds
                };
                timer.Tick += async (s, e) => await GetSelectedCurrencyPrice(GetCbCurrencyPair());
                timer.Start();
            }
            else if (OperatingSystem.IsWindows())
            {
                if (OperatingSystem.IsWindowsVersionAtLeast(6, 1))
                {
                    lblStatus.Text = "Timer is not supported on this version of Windows.";
                    lblStatus.ForeColor = Color.Red;
                }
            }
        }

        private void ApplyDarkTheme()
        {
            if (!OperatingSystem.IsWindowsVersionAtLeast(6, 1))
                return;

            // Main form properties
            this.BackColor = Color.FromArgb(25, 25, 35);
            this.ForeColor = Color.White;
            this.Text = "Bitcoin Price Tracker";
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;

            // Apply theme to all controls
            foreach (Control control in this.Controls)
            {
                if (control is Button btn)
                {
                    btn.BackColor = Color.FromArgb(90, 50, 180);
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderColor = Color.FromArgb(120, 80, 200);
                    btn.ForeColor = Color.White;
                }
                else if (control is ComboBox combo)
                {
                    combo.BackColor = Color.FromArgb(45, 45, 55);
                    combo.ForeColor = Color.White;
                    combo.FlatStyle = FlatStyle.Flat;
                }
                else if (control is Label)
                {
                    control.ForeColor = Color.FromArgb(200, 200, 255);
                }
                else if (control is TextBox || control is RichTextBox)
                {
                    control.BackColor = Color.FromArgb(45, 45, 55);
                    control.ForeColor = Color.White;
                }
                else if (control is Panel panel)
                {
                    panel.BackColor = Color.FromArgb(35, 35, 45);
                    panel.BorderStyle = BorderStyle.FixedSingle;
                }
            }
        }

        private ComboBox GetCbCurrencyPair()
        {
            return cbCurrencyPair;
        }

        private async Task GetSelectedCurrencyPrice(ComboBox cbCurrencyPair)
        {
            // Show loading state
            if (OperatingSystem.IsWindowsVersionAtLeast(6, 1))
            {
                btnRefresh.Enabled = false;
                lblStatus.Text = "Fetching price...";
            }

            // Cancel any ongoing request
            _cts?.Cancel();
            _cts?.Dispose();
            _cts = new CancellationTokenSource();
            var token = _cts.Token;

            try
            {
                if (string.IsNullOrEmpty(apiKey))
                {
                    if (OperatingSystem.IsWindowsVersionAtLeast(6, 1))
                    {
                        MessageBox.Show("Please set the POLYGON_API_KEY environment variable and restart the application.",
                            "API Key Missing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    return;
                }

                // Check if we're on Windows before accessing ComboBox properties
                if (!OperatingSystem.IsWindowsVersionAtLeast(6, 1))
                {
                    return;
                }

                if (cbCurrencyPair.SelectedItem == null)
                {
                    MessageBox.Show("Please select a currency pair.",
                        "Selection Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string? selectedItem = cbCurrencyPair.SelectedItem?.ToString();
                if (selectedItem != null)
                {
                    string currency = selectedItem.Split('/')[1];
                    string url = $"https://api.polygon.io/v1/last/crypto/BTC/{currency}?apiKey={apiKey}";

                    HttpResponseMessage response = await httpClient.GetAsync(url, token);
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync(token);

                    // Parse response with improved robustness
                    using JsonDocument document = JsonDocument.Parse(responseBody);
                    var root = document.RootElement;

                    if (root.TryGetProperty("last", out var lastProperty) &&
                        lastProperty.TryGetProperty("price", out var priceProperty))
                    {
                        if (priceProperty.TryGetDecimal(out decimal price))
                        {
                            if (OperatingSystem.IsWindowsVersionAtLeast(6, 1))
                            {
                                lblPrice.Text = price.ToString("N2");
                                lblLastUpdated.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                lblStatus.Text = "Ready";
                                lblStatus.ForeColor = Color.LightGreen;
                            }
                        }
                        else
                        {
                            if (OperatingSystem.IsWindowsVersionAtLeast(6, 1))
                            {
                                lblPrice.Text = "N/A";
                                lblStatus.Text = "Failed to parse price value.";
                                lblStatus.ForeColor = Color.Yellow;
                            }
                        }
                    }
                    else
                    {
                        if (OperatingSystem.IsWindowsVersionAtLeast(6, 1))
                        {
                            lblPrice.Text = "N/A";
                            lblStatus.Text = "Failed to parse API response.";
                            lblStatus.ForeColor = Color.Yellow;
                        }
                    }
                }
            }
            catch (OperationCanceledException)
            {
                // Silently handle cancellation
            }
            catch (HttpRequestException ex)
            {
                if (OperatingSystem.IsWindowsVersionAtLeast(6, 1))
                {
                    lblPrice.Text = "Error";
                    lblStatus.Text = $"Network error: {ex.Message}";
                    lblStatus.ForeColor = Color.Red;
                }
            }
            catch (JsonException ex)
            {
                if (OperatingSystem.IsWindowsVersionAtLeast(6, 1))
                {
                    lblPrice.Text = "Error";
                    lblStatus.Text = $"JSON parsing error: {ex.Message}";
                    lblStatus.ForeColor = Color.Red;
                }
            }
            catch (Exception ex)
            {
                if (OperatingSystem.IsWindowsVersionAtLeast(6, 1))
                {
                    lblPrice.Text = "Error";
                    lblStatus.Text = $"Error: {ex.Message}";
                    lblStatus.ForeColor = Color.Red;
                }
            }
            finally
            {
                // Reset UI state
                if (OperatingSystem.IsWindowsVersionAtLeast(6, 1))
                {
                    btnRefresh.Enabled = true;
                }
            }
        }

        private async void BtnRefresh_Click(object sender, EventArgs e)
        {
            await GetSelectedCurrencyPrice(GetCbCurrencyPair());
        }

        private async void CbCurrencyPair_SelectedIndexChanged(object sender, EventArgs e)
        {
            await GetSelectedCurrencyPrice(GetCbCurrencyPair());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!OperatingSystem.IsWindowsVersionAtLeast(6, 1))
                return;

            // Setup the UI controls
            foreach (var pair in currencyPairs)
            {
                cbCurrencyPair.Items.Add(pair.Value);
            }

            // Select default
            if (cbCurrencyPair.Items.Count > 0)
                cbCurrencyPair.SelectedIndex = 0;

            if (string.IsNullOrEmpty(apiKey))
            {
                lblStatus.Text = "Warning: API Key not set. Please set POLYGON_API_KEY environment variable.";
                lblStatus.ForeColor = Color.Yellow;
            }
            else
            {
                lblStatus.Text = "Ready";
                lblStatus.ForeColor = Color.LightGreen;
            }
        }
    }
}
