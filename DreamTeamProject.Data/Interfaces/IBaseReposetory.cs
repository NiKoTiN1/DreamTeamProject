using DreamTeamProject.Data.Models;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace DreamTeamProject.Data.Interfaces
{
    public interface IBaseReposetory
    {
        public void SetUpConnectionOptions();
        public DbOutput RunDbRequest(string funckName, bool mustRespond = false, Tuple<string, OracleDbType, object>[] args = null, Tuple<string, OracleDbType> returnVal = null);
    }
}
