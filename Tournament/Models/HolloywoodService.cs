using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Tournament.ViewModels;

namespace Tournament.Models
{
    public class HolloywoodService
    {
       private readonly string _connectionStr = "Data Source=.\\SQLEXPRESS;Initial Catalog=HollywoodTest; Integrated Security=True;MultipleActiveResultSets=True";
        public async Task<List<EventDetailViewModel>> GetEventDetails()
        {
            using (SqlConnection con = new SqlConnection(_connectionStr))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("GetEventDetail", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    await cmd.ExecuteNonQueryAsync();
                    SqlDataReader reader = await cmd.ExecuteReaderAsync();

                    List<EventDetailViewModel> list = new List<EventDetailViewModel>();
                    // list.Add(new L_PayFrequency { PayFrequencyID = -1, Description = "--Select A Pay Interval--" });
                    while (reader.Read())
                    {
                        var record = new EventDetailViewModel
                        {
                            EventDetailID = Convert.ToInt32(reader["EventDetailID"].ToString()),
                            FK_EventID = Convert.ToInt32(reader["FK_EventID"].ToString()),
                            EventName = reader["EventName"].ToString(),
                            FK_EventDetailStatusID = Convert.ToInt32(reader["FK_EventDetailStatusID"].ToString()),
                            EventDetailStatusName = reader["EventDetailStatusName"].ToString(),
                            EventDetailName = reader["EventDetailName"].ToString(),
                            EventDetailNumber = Convert.ToInt32(reader["EventDetailNumber"].ToString()),
                            EventDetailOdd = Convert.ToDecimal(reader["EventDetailOdd"].ToString()),
                            FinishingPosition = Convert.ToInt32(reader["FinishingPosition"].ToString()),
                            FirstTimer = Convert.ToBoolean(reader["FirstTimer"].ToString()),


                        };
                        list.Add(record);
                    }
                    reader.Close();
                    con.Close();
                    return list;
                }
            }
        }
    }
}
