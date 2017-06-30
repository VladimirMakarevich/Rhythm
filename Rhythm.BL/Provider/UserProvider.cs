using Rhythm.BL.Interfaces;
using Rhythm.Domain.Entities;
using Rhythm.Domain.Repository.Interfaces;
using Rhythm.Domain.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Rhythm.BL.Provider
{
    public class UserProvider : IUserProvider
    {
        private IUnitOfWork _uow;

        public UserProvider(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task CreateUserAsync(ChiefUser chiefUser, int portfolioId)
        {
            var portfolio = await _uow.Portfolio.GetPortfolioAsync(portfolioId);
            chiefUser.Portfolios.Add(portfolio);

            await _uow.User.CreateUserAsync(chiefUser);
        }

        public async Task DeleteUserAsync(int id)
        {
            var chiefUser = await _uow.User.GetUserAsync(id);

            await _uow.User.DeleteUserAsync(chiefUser);
        }

        public async Task EditUser(ChiefUser chiefUser, int portfolioId)
        {
            var portfolio = await _uow.Portfolio.GetPortfolioAsync(portfolioId);
            chiefUser.Portfolios.Add(portfolio);

            await _uow.User.EditUser(chiefUser);
        }

        public async Task<IEnumerable<ChiefUser>> GetChiefUsersAsync()
        {
            return await _uow.User.GetChiefUsersAsync();
        }

        public async Task<ChiefUser> GetUserAsync(int chiefUser)
        {
            return await _uow.User.GetUserAsync(chiefUser);
        }

        public async Task<bool> SendMessage(string name, string email, string message)
        {
            try
            {
                MailMessage msz = new MailMessage();
                msz.From = new MailAddress(email);
                msz.To.Add("justadreampictures@gmail.com");
                msz.Body = String.Format("Name: " + name + "\n\nE-mail: " + email + "\n\nMessage: " + message);
                msz.Subject = "site - DogCoding";

                SmtpClient smpt = new SmtpClient();
                smpt.Host = "smtp.gmail.com";
                smpt.Port = 587;
                smpt.Credentials = new System.Net.NetworkCredential("justadreampictures", "q26s4hcxz2332Q!@W");

                smpt.EnableSsl = true;
                await smpt.SendMailAsync(msz);

                return true;
                    //"Thank you for Contacting me.";
            }
            catch (Exception ex)
            {
                return false;
                    /*"Sorry, but a problem occured on the server, please try again after some time."*/;
            }
        }
    }
}
