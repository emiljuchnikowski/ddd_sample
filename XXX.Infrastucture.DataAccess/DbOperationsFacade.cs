using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using XXX.Infrastructure.Diagnostics;

namespace XXX.Infrastructure.DataAccess
{
    [ExcludeFromCodeCoverage]
// ReSharper disable once InconsistentNaming
    public class DbOperationsFacade : IDbOperationsFacade
    {
        private readonly ILog _log;

        public DbOperationsFacade(ILog log)
        {
            _log = log;
        }

        public async Task<int> RegisterUserAsync(RegisterUserModel model)
        {
            int result;
            using (var conn = new SqlConnection(GetConnectionString()))
            {
                try
                {
                    var cmd = new SqlCommand("app.RegisterUser", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Email", model.Email);
                    cmd.Parameters.AddWithValue("@Password", model.Password);
                    cmd.Parameters.AddWithValue("@Uuid", model.Uuid);
                    cmd.Parameters.AddWithValue("@Token", model.Token);
                    cmd.Parameters.AddWithValue("@FirstName", model.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", model.LastName);
                    cmd.Parameters.AddWithValue("@Phone", model.Phone);
                    await conn.OpenAsync();
                    result = (int) await cmd.ExecuteScalarAsync();
                }
                catch (SqlException ex)
                {
                    _log.Error("Message: {0}|Exception: {1}", ex.Message, ex);
                    if (ex.Number == 70000)
                        throw new InternalSqlException(ex.Message);
                    throw new Exception("SqlExceptionError");
                }
                catch (Exception ex)
                {
                    _log.Error("Message: {0}|Exception: {1}", ex.Message, ex);
                    throw new Exception("ExceptionError");
                }
            }
            return result;
        }

        public int RegisterUser(RegisterUserModel model)
        {
            int result;
            using (var conn = new SqlConnection(GetConnectionString()))
            {
                try
                {
                    var cmd = new SqlCommand("app.RegisterUser", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Email", model.Email);
                    cmd.Parameters.AddWithValue("@Password", model.Password);
                    cmd.Parameters.AddWithValue("@Uuid", model.Uuid);
                    cmd.Parameters.AddWithValue("@Token", model.Token);
                    cmd.Parameters.AddWithValue("@FirstName", model.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", model.LastName);
                    cmd.Parameters.AddWithValue("@Phone", model.Phone);
                    conn.Open();
                    result = (int) cmd.ExecuteScalar();
                }
                catch (SqlException ex)
                {
                    _log.Error("Message: {0}|Exception: {1}", ex.Message, ex);
                    if (ex.Number == 70000)
                        throw new InternalSqlException(ex.Message);
                    throw new Exception("SqlExceptionError");
                }
                catch (Exception ex)
                {
                    _log.Error("Message: {0}|Exception: {1}", ex.Message, ex);
                    throw new Exception("ExceptionError");
                }
            }
            return result;
        }

        public async Task UpdateUserPasswordAsync(UpdateUserPasswordModel model)
        {
            using (var conn = new SqlConnection(GetConnectionString()))
            {
                try
                {
                    var cmd = new SqlCommand("app.UpdateUserPassword", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Email", model.Email);
                    cmd.Parameters.AddWithValue("@Password", model.Password);
                    cmd.Parameters.AddWithValue("@ChangePasswordToken", model.ChangePasswordToken);
                    await conn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
                catch (SqlException ex)
                {
                    _log.Error("Message: {0}|Exception: {1}", ex.Message, ex);
                    if (ex.Number == 70000)
                        throw new InternalSqlException(ex.Message);
                    throw new Exception("SqlExceptionError");
                }
                catch (Exception ex)
                {
                    _log.Error("Message: {0}|Exception: {1}", ex.Message, ex);
                    throw new Exception("ExceptionError");
                }
            }
        }

        public void UpdateUserPassword(UpdateUserPasswordModel model)
        {
            using (var conn = new SqlConnection(GetConnectionString()))
            {
                try
                {
                    var cmd = new SqlCommand("app.UpdateUserPassword", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Email", model.Email);
                    cmd.Parameters.AddWithValue("@Password", model.Password);
                    cmd.Parameters.AddWithValue("@ChangePasswordToken", model.ChangePasswordToken);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    _log.Error("Message: {0}|Exception: {1}", ex.Message, ex);
                    if (ex.Number == 70000)
                        throw new InternalSqlException(ex.Message);
                    throw new Exception("SqlExceptionError");
                }
                catch (Exception ex)
                {
                    _log.Error("Message: {0}|Exception: {1}", ex.Message, ex);
                    throw new Exception("ExceptionError");
                }
            }
        }

        private string GetConnectionString()
        {
            var str = ConfigurationManager.ConnectionStrings["OperationsContext"].ConnectionString;
            return str;
        }
    }
}