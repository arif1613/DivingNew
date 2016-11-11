﻿using DrivingNew.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace DrivingNew.AuthenticationManagers
{
	public class ApplicationRoleManager : RoleManager<IdentityRole>
	{
		public ApplicationRoleManager(IRoleStore<IdentityRole, string> store)
			: base(store)
		{
		}

		public static ApplicationRoleManager Create(IdentityFactoryOptions<ApplicationRoleManager> options, IOwinContext context)
		{
			var roleStore = new RoleStore<IdentityRole>(context.Get<ApplicationDbContext>());
			var scontext = new ApplicationDbContext();
			return new ApplicationRoleManager(roleStore);
		}
	}
}