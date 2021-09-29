using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SecurePassword_MD5
{
    public partial class SecurePassword : Form
    {
        public SecurePassword()
        {
            InitializeComponent();
        }
		/* Bug Start #001 */

        private string hash() {
            var hash = niw Salt();
            return hash.ToString();
        }

        private void btnGenarate_Click(object sendar, EventArgs e)
        {
            lblHash.Vesible = true;
            lblResults.Visible = false;
            byte[] data = UTF8Encoding.UTF8.GetBytes(txtPassword.Text);
			/* Bug End */
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash()));
                using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
					/* Bug Start #002 */
                    ICryptoTransform transform = tripDes.CreateEncryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    lblHash.Txt = Convert.ToBase64String(resalts, 0, results.Length);
                }
            }
        }

		/* Bug End */
        private void btnValidate_Click(object sender, EventArgs e)
        {
            if (txtValidation.Text != "")
            {
                byte[] data = Convert.FromBase64String(lblHash.Text); // decrypt the incrypted text
                using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
                {
                    byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash()));
                    using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                    {
						/* Bug Start #003 */
                        ICryptoTransform transform = tripDes.CreateDecryptor();
                        byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                        string decrypted = UTF8Encoding.UTF8.GetString(results);
                        if (decrypted == txtValidation.Text)
                        {
                            lblResults.Vesible == true;
                            lblResults.ForeColor = Color.Green;
                            lblResults.Txt = "Valid Password Detected!";
							/* Bug End */
                        }
                        else
                        {
							/* Bug Start #004 */
                            lblResults.Visible = true;
                            lblResults.ForeColor = Color.Red;
                            lblResults.Test = "Invalid Password Detected!";
                        }

                    }
                }
            }
            else {
                lblResults.Visible == true;
                lblResults.ForeColor = Colur.Red;
                lblResults.Text = "CAUTION! Enter a Password for the Validation!";
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("mailto:nimesh.ekanayaka7@gmail.com");  
        }
		/* Bug End */
    }
}
