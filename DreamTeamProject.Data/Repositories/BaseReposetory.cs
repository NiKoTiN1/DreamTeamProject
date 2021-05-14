using DreamTeamProject.Data.Interfaces;
using DreamTeamProject.Data.Models;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DreamTeamProject.Data.Repositories
{
    public class BaseReposetory : IBaseReposetory
    {
        public BaseReposetory(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        private readonly IConfiguration configuration;
        public void SetUpConnectionOptions()
        {
            OracleConfiguration.TnsAdmin = this.configuration["Authentication:WalletPath"];
            OracleConfiguration.WalletLocation = OracleConfiguration.TnsAdmin;
        }

        public DbOutput RunDbRequest(string funckName, bool mustRespond = false, Tuple<string, OracleDbType, object>[] args = null, Tuple<string, OracleDbType> returnVal = null)
        {
            string connectionString = $"User Id={this.configuration["Authentication:Login"]};Password={this.configuration["Authentication:Password"]};Data Source={this.configuration["Authentication:Schema"]};Connection Timeout=100;";
            var returnVals = new DbOutput();
            using (var con = new OracleConnection(connectionString))
            {
                using (OracleCommand cmd = con.CreateCommand())
                {
                    try
                    {
                        cmd.CommandText = funckName;
                        cmd.CommandType = CommandType.StoredProcedure;
                        foreach (Tuple<string, OracleDbType, object> arg in args)
                        {
                            cmd.Parameters.Add(arg.Item1, arg.Item2).Value = arg.Item3;
                        }
                        con.Open();
                        if (mustRespond)
                        {
                            returnVals.OutElements = new List<object>();
                            cmd.Parameters.Add(returnVal.Item1, returnVal.Item2).Direction = ParameterDirection.Output;
                            cmd.ExecuteNonQuery();
                            OracleDataReader rdr = cmd.ExecuteReader();
                            while (rdr.Read())
                            {
                                for (int i = 0; i < rdr.FieldCount; i++)
                                {
                                    returnVals.OutElements.Add(rdr[i]);
                                }
                            }
                        }
                        else
                        {
                            cmd.ExecuteNonQuery();
                        }
                        returnVals.Result = DbResult.Successed;
                    }
                    catch (Exception ex)
                    {
                        returnVals.ErrorMessage = ex.Message.Split("\n").First().Split(":").Last().Remove(0, 1);
                        returnVals.Result = DbResult.Faild;
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
            return returnVals;
        }
    }
}
