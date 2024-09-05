using CSharpEducation.GroupProject.ChatMSG.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEducation.GroupProject.ChatMSG.Core.Abstractions
{
	public interface IInvitationService
	{
		string GenerateInvitationLink();
		//void SaveInvitationLink(string link);
	//	Task GetInvitationByLink();
	}
}
