using System;
namespace Service.Helpers
{
	public class EmailSetting
	{
        public string FromAddress { get; set; }
        public string Server { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}