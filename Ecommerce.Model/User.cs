using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Model
{
	public class User
	{
		[BindNever]
		public string UserId { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public User(string email, string password)
		{
			UserId = Guid.NewGuid().ToString();
			Email = email;
			Password = password;
		}
		public User()
		{

		}
	}
}
