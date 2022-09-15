using Demo2020.Biz.Equipment.Interfaces;
using Demo2020.Biz.Equipment.Models;
using Demo2020.Data.Interfaces;
using Demo2020.Data.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Demo2020.Biz.Equipment.Services
{
    public class EquipmentDataAccessService : IEquipmentDataAccessService
    {
        //**************************************************\\
        //********************* Fields *********************\\
        //**************************************************\\
        private const string _baseUrl = "http://www.dnd5eapi.co";

        private ISQLiteDataAccess _sqLiteDataAccessService;
        private IEquipmentFactoryService _equipmentFactoryService;

        public EquipmentDataAccessService(IEquipmentFactoryService equipmentFactoryService)
        {
            _sqLiteDataAccessService = new SQLiteDataAccessService();
            _equipmentFactoryService = equipmentFactoryService;
        }

        //**************************************************\\
        //******************** Methods *********************\\
        //**************************************************\\

        //public IList<IEquipmentModel> GetAllEquipment()
        //{
        //    IList<IEquipmentModel> equipment = new List<IEquipmentModel>();

        //    string query = "SELECT * FROM Equipment";
        //    try
        //    {
        //        using (DataSet ds = _sqLiteDataAccessService.ExecuteQuery(query))
        //        {
        //            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        //            {
        //                foreach (DataRow row in ds.Tables[0].Rows)
        //                {
        //                    IEquipmentModel equipmentModel = _equipmentFactoryService.GetEquipment();

        //                    equipmentModel.Id = Convert.IsDBNull(row["Id"]) ? 0 : Convert.ToInt32(row["Id"]);
        //                    equipmentModel.Name = Convert.IsDBNull(row["Name"]) ? string.Empty : Convert.ToString(row["Name"]);
        //                    equipmentModel.Weight = Convert.IsDBNull(row["Weight"]) ? 0 : Convert.ToDouble(row["Weight"]);
        //                    equipmentModel.Cost.Quantity = Convert.IsDBNull(row["CostQuantity"]) ? 0 : Convert.ToInt32(row["CostQuantity"]);
        //                    equipmentModel.Cost.Unit = Convert.IsDBNull(row["CostUnits"]) ? string.Empty : Convert.ToString(row["CostUnits"]);
        //                    equipmentModel.Damage.DamageDice = Convert.IsDBNull(row["OneHandedDamageDice"]) ? string.Empty : Convert.ToString(row["OneHandedDamageDice"]);
        //                    equipmentModel.Damage.DamageType.Name = Convert.IsDBNull(row["OneHandedDamageType"]) ? string.Empty : Convert.ToString(row["OneHandedDamageType"]);
        //                    equipmentModel.TwoHandedDamage.DamageDice = Convert.IsDBNull(row["TwoHandedDamageDice"]) ? string.Empty : Convert.ToString(row["TwoHandedDamageDice"]);
        //                    equipmentModel.TwoHandedDamage.DamageType.Name = Convert.IsDBNull(row["TwoHandedDamageType"]) ? string.Empty : Convert.ToString(row["TwoHandedDamageType"]);
        //                    equipmentModel.Range.Normal = Convert.IsDBNull(row["NormalRange"]) ? (int?)null : Convert.ToInt32(row["NormalRange"]);
        //                    equipmentModel.Range.Long = Convert.IsDBNull(row["LongRange"]) ? (int?)null : Convert.ToInt32(row["LongRange"]);
        //                    equipmentModel.ArmorClass.Base = Convert.IsDBNull(row["ArmorClass"]) ? (int?)null : Convert.ToInt32(row["ArmorClass"]);
        //                    equipmentModel.ArmorClass.DexBonus = Convert.IsDBNull(row["IsDexBonus"]) ? false : Convert.ToBoolean(row["IsDexBonus"]);
        //                    equipmentModel.ArmorClass.MaxBonus = Convert.IsDBNull(row["MaxDexBonus"]) ? (int?)null : Convert.ToInt32(row["MaxDexBonus"]);
        //                    equipmentModel.StrengthRequirement = Convert.IsDBNull(row["StrengthRequirement"]) ? 0 : Convert.ToInt32(row["StrengthRequirement"]);
        //                    equipmentModel.IsStealthDisadvantage = Convert.IsDBNull(row["IsStealthDisadvantage"]) ? false : Convert.ToBoolean(row["IsStealthDisadvantage"]);
        //                    equipmentModel.EquipmentCategory.Name = Convert.IsDBNull(row["EquipmentCategory"]) ? string.Empty : Convert.ToString(row["EquipmentCategory"]);
        //                    equipmentModel.WeaponRange = Convert.IsDBNull(row["WeaponRange"]) ? string.Empty : Convert.ToString(row["WeaponRange"]);
        //                    equipmentModel.WeaponCategory = Convert.IsDBNull(row["WeaponCategory"]) ? string.Empty : Convert.ToString(row["WeaponCategory"]);
        //                    equipmentModel.ToolCategory = Convert.IsDBNull(row["ToolCategory"]) ? string.Empty : Convert.ToString(row["ToolCategory"]);
        //                    equipmentModel.VehicleCategory = Convert.IsDBNull(row["VehicleCategory"]) ? string.Empty : Convert.ToString(row["VehicleCategory"]);
        //                    equipmentModel.ArmorCategory = Convert.IsDBNull(row["ArmorCategory"]) ? string.Empty : Convert.ToString(row["ArmorCategory"]);
        //                    equipmentModel.GearCategory.Name = Convert.IsDBNull(row["GearCategory"]) ? string.Empty : Convert.ToString(row["GearCategory"]);

        //                    equipment.Add(equipmentModel);
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }

        //    return equipment;
        //}

        //Deprecated Methods
        public async Task<List<EquipmentModel>> GetAllEquipment()
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri(_baseUrl);

                    // Add an Accept header for JSON format.
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.GetAsync("/api/equipment");
                    if (response.IsSuccessStatusCode)
                    {
                        string rawJSON = await response.Content.ReadAsStringAsync();
                        var data = JsonConvert.DeserializeObject<EquipmentContainer>(rawJSON);
                        return data.Results;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return null;
        }

        public async Task<EquipmentModel> GetEquipment(string name)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri(_baseUrl);

                    // Add an Accept header for JSON format.
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    
                    name = name.ToLower()
                        .Replace(" form", "")
                        .Replace(" ", "-")
                        .Replace("/", "-")
                        .Replace("(", "")
                        .Replace(")", "")
                        .Replace("'", "")
                        .Replace(":", "")
                        .Replace(",", "");
                    HttpResponseMessage response = await client.GetAsync("/api/equipment/" + name);
                    if (response.IsSuccessStatusCode)
                    {
                        string rawJSON = await response.Content.ReadAsStringAsync();
                        var data = JsonConvert.DeserializeObject<EquipmentModel>(rawJSON);
                        return data;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return default(EquipmentModel);
        }

        // New Methods
        public IEquipmentModel GetEquipment(int id)
        {
            throw new NotImplementedException();
        }

        public IEquipmentModel GetEquipmentv2(string name)
        {
            throw new NotImplementedException();
        }

        public bool SaveEquipment(IEquipmentModel equipment)
        {
            bool success = false;

            StringBuilder header = new StringBuilder();
            StringBuilder values = new StringBuilder();
            header.Append("INSERT INTO Equipment (");
            values.Append(" VALUES (");

            if (equipment.Id != 0)
            {
                header.Append("Id, ");
                values.Append(equipment.Id + ", ");
            }

            if (equipment.Name != null)
            {
                header.Append("Name, ");
                values.Append("\"" + equipment.Name + "\", ");
            }

            if (equipment.Weight != 0)
            {
                header.Append("Weight, ");
                values.Append("\"" + equipment.Weight + "\", ");
            }

            if (equipment.Cost.Quantity != 0)
            {
                header.Append("CostQuantity, ");
                values.Append("\"" + equipment.Cost.Quantity + "\", ");
            }

            if (equipment.Cost.Unit != null)
            {
                header.Append("CostUnits, ");
                values.Append("\"" + equipment.Cost.Unit + "\", ");
            }

            if (equipment.Damage.DamageDice != null)
            {
                header.Append("OneHandedDamageDice, ");
                values.Append("\"" + equipment.Damage.DamageDice + "\", ");
            }

            if (equipment.Damage.DamageType.Name != null)
            {
                header.Append("OneHandedDamageType, ");
                values.Append("\"" + equipment.Damage.DamageType.Name + "\", ");
            }

            if (equipment.TwoHandedDamage.DamageDice != null)
            {
                header.Append("TwoHandedDamageDice, ");
                values.Append("\"" + equipment.TwoHandedDamage.DamageDice + "\", ");
            }

            if (equipment.TwoHandedDamage.DamageType.Name != null)
            {
                header.Append("TwoHandedDamageType, ");
                values.Append("\"" + equipment.TwoHandedDamage.DamageType.Name + "\", ");
            }

            if (equipment.Range.Normal != null)
            {
                header.Append("NormalRange, ");
                values.Append("\"" + equipment.Range.Normal + "\", ");
            }

            if (equipment.Range.Long != null)
            {
                header.Append("LongRange, ");
                values.Append("\"" + equipment.Range.Long + "\", ");
            }

            if (equipment.ArmorClass.Base != null)
            {
                header.Append("ArmorClass, ");
                values.Append("\"" + equipment.ArmorClass.Base + "\", ");
            }

            if (equipment.ArmorClass.DexBonus != false)
            {
                header.Append("IsDexBonus, ");
                values.Append("\"" + equipment.ArmorClass.DexBonus + "\", ");
            }

            if (equipment.ArmorClass.MaxBonus != null)
            {
                header.Append("MaxDexBonus, ");
                values.Append("\"" + equipment.ArmorClass.MaxBonus + "\", ");
            }

            if (equipment.StrengthRequirement != 0)
            {
                header.Append("StrengthRequirement, ");
                values.Append("\"" + equipment.StrengthRequirement + "\", ");
            }

            if (equipment.IsStealthDisadvantage != false)
            {
                header.Append("IsStealthDisadvantage, ");
                values.Append("\"" + equipment.IsStealthDisadvantage + "\", ");
            }

            if (equipment.EquipmentCategory.Name != null)
            {
                header.Append("EquipmentCategory, ");
                values.Append("\"" + equipment.EquipmentCategory.Name + "\", ");
            }

            if (equipment.WeaponRange != null)
            {
                header.Append("WeaponRange, ");
                values.Append("\"" + equipment.WeaponRange + "\", ");
            }

            if (equipment.WeaponCategory != null)
            {
                header.Append("WeaponCategory, ");
                values.Append("\"" + equipment.WeaponCategory + "\", ");
            }

            if (equipment.ToolCategory != null)
            {
                header.Append("ToolCategory, ");
                values.Append("\"" + equipment.ToolCategory + "\", ");
            }

            if (equipment.VehicleCategory != null)
            {
                header.Append("VehicleCategory, ");
                values.Append("\"" + equipment.VehicleCategory + "\", ");
            }

            if (equipment.ArmorCategory != null)
            {
                header.Append("ArmorCategory, ");
                values.Append("\"" + equipment.ArmorCategory + "\", ");
            }

            if (equipment.GearCategory.Name != null)
            {
                header.Append("GearCategory, ");
                values.Append("\"" + equipment.GearCategory.Name + "\", ");
            }

            header.Remove(header.Length - 2, 2);
            header.Append(") ");

            values.Remove(values.Length - 2, 2);
            values.Append(") ");

            try
            {
                _sqLiteDataAccessService.ExecuteNonQuery(header.ToString() + values.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return success;
        }

        public bool SaveEquipment(IList<IEquipmentModel> equipment)
        {
            throw new NotImplementedException();
        }

        public bool UpdateEquipment(IEquipmentModel equipment)
        {
            throw new NotImplementedException();
        }

        public bool UpdateEquipment(IList<IEquipmentModel> equipment)
        {
            throw new NotImplementedException();
        }

        public bool DeleteEquipment(IEquipmentModel equipment)
        {
            throw new NotImplementedException();
        }

        public bool DeleteEquipment(IList<IEquipmentModel> equipment)
        {
            throw new NotImplementedException();
        }

        public IList<IEquipmentModel> GetAllEquipmentv2()
        {
            throw new NotImplementedException();
        }


        //**************************************************\\
        //****************** Nested Class ******************\\
        //**************************************************\\
        private class EquipmentContainer
        {
            public EquipmentContainer(int count, List<EquipmentModel> results)
            {
                Count = count;
                Results = results;
            }

            public int Count { get; set; }
            public List<EquipmentModel> Results { get; set; }
        }
    }
}
