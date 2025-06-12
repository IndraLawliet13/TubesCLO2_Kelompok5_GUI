using TubesCLO2_Kelompok5_GUI.Controllers;
using TubesCLO2_Kelompok5_GUI.Models;
using TubesCLO2_Kelompok5_GUI.Services;
using TubesCLO2_Kelompok5_GUI.Views;
namespace TubesCLO2_Kelompok5_GUI
{
    public partial class LoginForm : Form
    {
        private readonly LoginController _loginController;
        private ConfigurationService _configService;
        public LoginForm(ConfigurationService configService)
        {
            InitializeComponent();
            _configService = configService;
            _loginController = new LoginController(_configService);

            // this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click); // Removed this line
            ApplyLocalization(); // Call parameterless ApplyLocalization
        }

        // Made private and parameterless
        private void ApplyLocalization()
        {
            this.Text = _configService.GetMessage("LoginFormTitle") ?? "Login";
            lblUsername.Text = _configService.GetMessage("UsernameLabel") ?? "Username:";
            lblPassword.Text = _configService.GetMessage("PasswordLabel") ?? "Password:";
            btnLogin.Text = _configService.GetMessage("LoginButton") ?? "Login";
            // Consider localizing MessageBox titles as well if they are static
        }

        public void ApplyLocalizationPublic()
        {
            ApplyLocalization();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // Assuming ValidateLogin in LoginController might also use localized messages for internal errors,
            // though here we only care about the final true/false.
            if (_loginController.ValidateLogin(username, password))
            {
                MessageBox.Show(_configService.GetMessage("SuccessLogin"),
                                _configService.GetMessage("SuccessLoginTitle"), // Localized title
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                this.Hide();
                // Pass MainController which contains ConfigService to MainMenuForm
                MainMenuForm mainMenuForm = new MainMenuForm(_loginController.MainController);
                mainMenuForm.FormClosed += (s, args) => this.Close(); // Close LoginForm when MainMenuForm is closed
                mainMenuForm.Show();
            }
            else
            {
                MessageBox.Show(_configService.GetMessage("ErrorLoginFailed"),
                                _configService.GetMessage("ErrorLoginFailedTitle"), // Localized title
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }
    }
}