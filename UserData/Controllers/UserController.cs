using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserData.Models;
using MySqlConnector;
using System.Data;

namespace UserData.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SignIn()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignIn(UserClass model)
        {
            if (ModelState.IsValid)
            {
                string connectionString = "server=localhost;database=guestbook;user=root;password=Vivek@7859;";

                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    string hashedPassword = HashPassword(model.Password);
                    string query = "INSERT INTO UserDetails (Name, UserName, Email, Password) VALUES (@Name, @UserName,@Email,@Password);";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Name", model.Name);
                    cmd.Parameters.AddWithValue("@UserName", model.UserName);
                    cmd.Parameters.AddWithValue("@Email", model.Email);
                    cmd.Parameters.AddWithValue("@Password", hashedPassword);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        ViewBag.Message = "User created successfully!";
                        return RedirectToAction("Login", "User");

                    }
                    catch (Exception ex)
                    {
                        ViewBag.Message = "Error: " + ex.Message;
                    }
                }
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            string connectionString = "server=localhost;database=guestbook;user=root;password=Vivek@7859;";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "SELECT Password FROM UserDetails WHERE UserName = @UserName";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserName", model.UserName);

                try
                {
                    conn.Open();
                    string hashedPassword = cmd.ExecuteScalar() as string;

                    if (!string.IsNullOrEmpty(hashedPassword))
                    {
                        if (VerifyPassword(model.Password, hashedPassword))
                        {
                            
                            ViewBag.Message = "Login successful!";
                            return RedirectToAction("Index", "Home");
                        }
                    }
                    ViewBag.Message = "Invalid username or password.";
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "Error: " + ex.Message;
                }
            }




            return View();
        }

        private string HashPassword(string password)
        {
            return Convert.ToBase64String(System.Security.Cryptography.SHA256.Create().ComputeHash(System.Text.Encoding.UTF8.GetBytes(password)));
        }

        private bool VerifyPassword(string enteredPassword, string hashedPassword)
        {
            string enteredHashedPassword = HashPassword(enteredPassword);
            return enteredHashedPassword == hashedPassword;
        }
    }
}


