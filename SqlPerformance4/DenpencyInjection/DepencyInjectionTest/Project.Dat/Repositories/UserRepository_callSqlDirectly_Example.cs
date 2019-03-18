//using System;
//using System.Collections.Generic;
//using System.Data.Common;
//using System.Data.SqlClient;
//using System.Text;
//using System.Threading.Tasks;
//using System.Transactions;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.EntityFrameworkCore;
//using YayoiApp.Data.Entities;
//using YayoiApp.Data.IRepositories;

//namespace YayoiApp.Data.EF.Repositories
//{
//    public class UserRepository : IUserRepository
//    {


//        private readonly AppDbContext _context;

//        public UserRepository(AppDbContext context)
//        {

//            _context = context;

//        }

//        public Task DeleteRolesForCustomerUser(List<string> newRoles, int customerID)
//        {
//            throw new NotImplementedException();
//        }

//        public Task<List<Applications>> GetApplicationListOfUser(int userID)
//        {
//            throw new NotImplementedException();
//        }

//        public Task<List<AppRole>> GetRoleOfUser(int userID, int companyID, int appID)
//        {
//            throw new NotImplementedException();
//        }

//        public async Task<bool> IsUserInRole(int userID, int role)
//        {

//            var ckQuerry = "SELECT CASE WHEN EXISTS ( SELECT [AppUserRoles].[RoleId] FROM [AppUserRoles] WHERE ([AppUserRoles].[RoleId] = @role) AND ([AppUserRoles].[UserId] = @userID) ) THEN CAST(1 AS BIT) ELSE CAST(0 AS BIT) END";
//            bool result = false;

//            try
//            {
//                var temp = await _context.Database.ExecuteSqlCommandAsync(
//                    ckQuerry,
//                    new SqlParameter("@role", role),
//                    new SqlParameter("@userID", userID)
//                );
//                result = true;
//            }
//            catch (Exception ex)
//            {

//                Console.WriteLine("Message = {1}", ex.Message);
//            }

//            return result;

//        }

//        public async Task RemoveAllUserRoles(int userID)
//        {

//            var deleteRoleQuery = "DELETE FROM [AppUserRoles] WHERE ([AppUserRoles].[UserId] = @userID)";

//            try
//            {
//                var temp = await _context.Database.ExecuteSqlCommandAsync(
//                    deleteRoleQuery,

//                    new SqlParameter("@userID", userID)
//                );
//            }
//            catch (Exception ex)
//            {

//                Console.WriteLine("Message = {1}", ex.Message);
//            }


//            //var conn = _context.Database.GetDbConnection();
//            //try
//            //{
//            //    await conn.OpenAsync();
//            //    using (var command = conn.CreateCommand())
//            //    {


//            //        DbParameter paramTo = command.CreateParameter();
//            //        paramTo.ParameterName = "@userID";
//            //        paramTo.Value = userID;
//            //        command.Parameters.Add(paramTo);
//            //        command.CommandText = deleteRoleQuery;

//            //        DbDataReader reader = await command.ExecuteReaderAsync();

//            //        reader.Dispose();
//            //    }
//            //}
//            //catch (Exception e)
//            //{
//            //    Console.WriteLine("Message = {1}", e.Message);
//            //}
//            //finally
//            //{
//            //    conn.Close();
//            //}
//        }




//        public async Task RemoveUserRoles(int roles, int userID)
//        {

//            var deleteRoleQuery = "DELETE FROM [AppUserRoles] WHERE ([AppUserRoles].[RoleId] = @roles) AND ([AppUserRoles].[UserId] = @userID)";

//            try
//            {
//                var temp = await _context.Database.ExecuteSqlCommandAsync(
//                    deleteRoleQuery,

//                    new SqlParameter("@role", roles),
//                    new SqlParameter("@userID", userID)
//                );
//            }
//            catch (Exception ex)
//            {

//                Console.WriteLine("Message = {1}", ex.Message);
//            }

//            //var conn = _context.Database.GetDbConnection();
//            //try
//            //{
//            //    await conn.OpenAsync();
//            //    using (var command = conn.CreateCommand())
//            //    {

//            //        DbParameter paramFrom = command.CreateParameter();
//            //        paramFrom.ParameterName = "@roles";
//            //        paramFrom.Value = roles;
//            //        command.Parameters.Add(paramFrom);


//            //        DbParameter paramTo = command.CreateParameter();
//            //        paramTo.ParameterName = "@userID";
//            //        paramTo.Value = userID;
//            //        command.Parameters.Add(paramTo);
//            //        command.CommandText = deleteRoleQuery;

//            //        DbDataReader reader = await command.ExecuteReaderAsync();

//            //        reader.Dispose();
//            //    }
//            //}
//            //catch (Exception e)
//            //{
//            //    Console.WriteLine("Message = {1}", e.Message);
//            //}
//            //finally
//            //{
//            //    conn.Close();
//            //}
//        }

//        public Task UpdateRoleForCustomerUser(List<string> newRoles, int customerID)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
