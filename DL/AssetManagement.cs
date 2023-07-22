using System;
using System.Data;
using System.Data.SqlClient;

namespace DL
{
    [CLSCompliantAttribute(false)]
    public class AssetManagement
    {
        #region Function Related to AssetManufacturer

        /// <summary>
        /// To get All the data from AssetManufacturer
        /// </summary>
        /// <returns>Dataset Message with ManufacturerName,ManufacturerEmail,ManufacturerPhone,ManufacturerAddress</returns>
        public DataSet AssetManufacturerGetRecords(string CompanyCode)
        {

            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
            DataSet ds = SqlHelper.ExecuteDataset("udpMstAssetManufacturerGetAll", objParam);
            return ds;
        }

        /// <summary>
        /// To Insert the data of AssetManufacturer
        /// </summary>
        /// <param name="manufacturerName">ManufacturerName</param>
        /// <param name="manufacturerEmail">ManufacturerEmail</param>
        /// <param name="manufacturerPhone">ManufacturerPhone</param>
        /// <param name="manufacturerAddress">ManufacturerAddress</param>
        /// <param name="modifiedBy">modifiedBy</param>
        /// <returns>Dataset Message with ManufacturerName,ManufacturerEmail,ManufacturerPhone,ManufacturerAddress </returns>
        public DataSet AssetManufacturerAddNew(string manufacturerName, string manufacturerEmail, string manufacturerPhone, string manufacturerAddress, string modifiedBy,string CompanyCode)
        {
            var objParam = new SqlParameter[6];
            objParam[0] = new SqlParameter(Properties.Resources.ManufacturerName, manufacturerName);
            objParam[1] = new SqlParameter(Properties.Resources.ManufacturerEmail, manufacturerEmail);
            objParam[2] = new SqlParameter(Properties.Resources.ManufacturerPhone, manufacturerPhone);
            objParam[3] = new SqlParameter(Properties.Resources.ManufacturerAddress, manufacturerAddress);
            objParam[4] = new SqlParameter(Properties.Resources.ModifiedBy, modifiedBy);
            objParam[5] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
            var addStatus = SqlHelper.ExecuteDataset("udpMstAssetManufacturerInsert", objParam);
            return addStatus;

        }

        /// <summary>
        /// To Update the data of AssetManufacturer
        /// </summary>
        /// <param name="ManufacturerName">ManufacturerName</param>
        /// <param name="ManufacturerEmail">ManufacturerEmail</param>
        /// <param name="ManufacturerPhone">ManufacturerPhone</param>
        /// <param name="ManufacturerAddress">ManufacturerAddress</param>
        /// <param name="modifiedBy">modifiedBy</param>
        /// <returns>Dataset Message with ManufacturerName,ManufacturerEmail,ManufacturerPhone,ManufacturerAddress </returns>
        public DataSet AssetManufacturerUpdateRecords(string ManufacturerName, string ManufacturerEmail, string ManufacturerPhone, string ManufacturerAddress, string modifiedBy, string CompanyCode)
        {
            SqlParameter[] objParam = new SqlParameter[6];
            objParam[0] = new SqlParameter(Properties.Resources.ManufacturerName, ManufacturerName);
            objParam[1] = new SqlParameter(Properties.Resources.ManufacturerEmail, ManufacturerEmail);
            objParam[2] = new SqlParameter(Properties.Resources.ManufacturerPhone, ManufacturerPhone);
            objParam[3] = new SqlParameter(Properties.Resources.ManufacturerAddress, ManufacturerAddress);
            objParam[4] = new SqlParameter(Properties.Resources.ModifiedBy, modifiedBy);
            objParam[5] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
            DataSet updateStatus = SqlHelper.ExecuteDataset("udpMstAssetManufacturerUpdate", objParam);
            return updateStatus;

        }

        /// <summary>
        /// To Delete Data from AssetManufacturer
        /// </summary>
        /// <param name="ManufacturerAutoID">ManufacturerAutoID</param>
        /// <returns>Dataset Message String</returns>
        public DataSet AssetManufacturerDelete(string ManufacturerAutoID, string CompanyCode)
        {

            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(Properties.Resources.ManufacturerAutoID, Convert.ToInt32(ManufacturerAutoID));
            objParam[1] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);

            DataSet deleteStatus = SqlHelper.ExecuteDataset("udpMstAssetManufacturerDelete", objParam);
            return deleteStatus;

        }

        public DataSet insertempmapping(string baseLocationAutoID, string empcode, string clientcode)
        {
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(Properties.Resources.LocationAutoId, baseLocationAutoID);
            objParam[1] = new SqlParameter(Properties.Resources.EmployeeCode, empcode);

            objParam[2] = new SqlParameter(Properties.Resources.ClientCode, clientcode);

            DataSet deleteStatus = SqlHelper.ExecuteDataset("udp_updateempMapping", objParam);
            return deleteStatus;
        }
        #endregion

        #region Function related to Asset Category
        public DataSet AssetCategoryInsert(int ID, string CategoryName, string ModifiedBy, string CompanyCode)
        {

            SqlParameter[] objParam = new SqlParameter[4];
            objParam[0] = new SqlParameter(Properties.Resources.AssetCategoryId, ID);
            objParam[1] = new SqlParameter(Properties.Resources.AssetCategoryName, CategoryName);
            objParam[2] = new SqlParameter(Properties.Resources.ModifiedBy, ModifiedBy);
            objParam[3] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "UdpAssetCategoryInsert", objParam);
            return ds;
        }
        public DataSet AssetCategoryDelete(int ID,string CompanyCode)
        {

            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(Properties.Resources.AssetCategoryId, ID);
            objParam[1] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "UdpAssetCategoryDelete", objParam);
            return ds;
        }

       

        public DataSet UpdateLatLong(string baseLocationAutoID, string clientcode, string lat, string Longtitude)
        {
            SqlParameter[] objParam = new SqlParameter[4];
            objParam[0] = new SqlParameter(Properties.Resources.LocationAutoId, baseLocationAutoID);
            objParam[1] = new SqlParameter(Properties.Resources.ClientCode, clientcode);
            objParam[2] = new SqlParameter(Properties.Resources.Latitude, lat);
            objParam[3] = new SqlParameter(Properties.Resources.Longitude, Longtitude);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_updatelatLong", objParam);
            return ds;
        }

        public DataSet AssetMasterDetailGetSMCL(int locationAutoID)
        {
            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(Properties.Resources.LocationAutoId, locationAutoID);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "Udp_GetAssetDetailSMCL", objParam);
            return ds;
        }

        public DataSet GetFeedbackSMCL(int locationAutoID)
        {
            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(Properties.Resources.LocationAutoId, locationAutoID);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "Udp_GetFeedbackSMCL", objParam);
            return ds;
        }

        public DataSet ScheduleEmpSMCL(int autoID, int locationAutoID, string empNo)
        {
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(Properties.Resources.AutoId, autoID);
            objParam[1] = new SqlParameter(Properties.Resources.LocationAutoId, locationAutoID);
            objParam[2] = new SqlParameter(Properties.Resources.EmployeeCode, empNo);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "Udp_ScheduleEmpSMCL", objParam);
            return ds;
        }

        public DataSet ScheduleEmpSMCLCMS(int autoID, int locationAutoID, string empNo)
        {
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(Properties.Resources.AutoId, autoID);
            objParam[1] = new SqlParameter(Properties.Resources.LocationAutoId, locationAutoID);
            objParam[2] = new SqlParameter(Properties.Resources.EmployeeCode, empNo);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "Udp_ScheduleEmpSMCLCMS", objParam);
            return ds;
        }


        public DataSet GetEmpSMCL(int locationAutoID)
        {
            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(Properties.Resources.LocationAutoId, locationAutoID);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "Udp_GetEmpListSMCL", objParam);
            return ds;
        }

        public DataSet GetEmpCMSSMCL(int locationAutoID)
        {
            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(Properties.Resources.LocationAutoId, locationAutoID);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "Udp_GetEmpListSMCLCMS", objParam);
            return ds;
        }

        public DataSet GetBreakfixDetailsSMCL(int autoID, int locationAutoID)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(Properties.Resources.AutoId, autoID);
            objParam[1] = new SqlParameter(Properties.Resources.LocationAutoId, locationAutoID);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "Udp_GetBreakFixDetailsSMCL", objParam);
            return ds;
        }

        //public DataSet GetCMSDetailsSMCL(int autoID, int locationAutoID)
        //{
        //    SqlParameter[] objParam = new SqlParameter[2];
        //    objParam[0] = new SqlParameter(Properties.Resources.AutoId, autoID);
        //    objParam[1] = new SqlParameter(Properties.Resources.LocationAutoId, locationAutoID);
        //    DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "Udp_GetBreakFixDetailsSMCL", objParam);
        //    return ds;
        //} 
        public DataSet GetbreakFixSMCL(int locationAutoID)
        {
            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(Properties.Resources.LocationAutoId, locationAutoID);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "Udp_GetBreakFixSMCL", objParam);
            return ds;
        }

        public DataSet GetCMSSMCL(int locationAutoID, string FromDate, string ToDate, string EmployeeNumber)
        {
            SqlParameter[] objParam = new SqlParameter[4];
            objParam[0] = new SqlParameter(Properties.Resources.LocationAutoId, locationAutoID);
            objParam[1] = new SqlParameter(DL.Properties.Resources.FromDate, DL.Common.DateFormat(FromDate));
            objParam[2] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(ToDate));
            objParam[3] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, EmployeeNumber);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "Udp_GetCMSSMCL", objParam);
            return ds;
        }

        public DataSet AssetCategoryDetailGet(string CompanyCode)
        {
            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "UdpAssetCategoryDetailGet", objParam);
            return ds;
        }
        #endregion

        # region function related to Asset Sub Category
        public DataSet AssetSubCategoryDetailGet(int ID,string CompanyCode)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(Properties.Resources.AssetCategoryId, ID);
            objParam[1] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "UdpAssetSubCategoryDetailGet", objParam);
            return ds;
        }
        public DataSet AssetSubCategoryInsert(int ID, int CategoryId, string SubCategoryName, string ModifiedBy, string CompanyCode)
        {

            SqlParameter[] objParam = new SqlParameter[5];
            objParam[0] = new SqlParameter(Properties.Resources.AssetSubCategoryId, ID);
            objParam[1] = new SqlParameter(Properties.Resources.AssetCategoryId, CategoryId);
            objParam[2] = new SqlParameter(Properties.Resources.AssetSubCategoryName, SubCategoryName);
            objParam[3] = new SqlParameter(Properties.Resources.ModifiedBy, ModifiedBy);
            objParam[4] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "UdpAssetSubCategoryInsert", objParam);
            return ds;
        }
        public DataSet AssetSubCategoryDelete(int ID, string CompanyCode)
        {

            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(Properties.Resources.AssetSubCategoryId, ID);
            objParam[1] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "UdpAssetSubCategoryDelete", objParam);
            return ds;
        }
        #endregion

        # region function related to Asset Master
        public DataSet AssetMasterDetailGet(string CompanyCode)
        {
            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "UdpAssetMasterDetailGet", objParam);
            return ds;
        }
        public DataSet AssetManufactureDetailGet(string CompanyCode)
        {
            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "UdpAssetManufactureDetailGet",objParam);
            return ds;
        }
        public DataSet AssetMasterDetailForUpdate(string AssetId,string CompanyCode)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(Properties.Resources.AssetID, AssetId);
            objParam[1] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "UdpAssetMasterDetailForUpdate", objParam);
            return ds;
        }
        public DataSet AssetMasterDetailInsert(string AssetCode, string AssetName, string AssetCategory, string AssetSubCategory, string AssetManufacture, string ModelNo, string ModelName, string SerialNo, string Description, string AssetOwner, string TagID, string Remarks, string IsActive, string Inactivewef, string Activewef, string status, string Condition, string ImageUrl, string MgmtGuideline, string ModifiedBy, string CompanyCode)
        {
            SqlParameter[] objParam = new SqlParameter[21];
            objParam[0] = new SqlParameter(Properties.Resources.AssetCode, AssetCode);
            objParam[1] = new SqlParameter(Properties.Resources.AssetName, AssetName);
            objParam[2] = new SqlParameter(Properties.Resources.AssetCategoryId, AssetCategory);
            objParam[3] = new SqlParameter(Properties.Resources.AssetSubCategoryId, AssetSubCategory);
            objParam[4] = new SqlParameter(Properties.Resources.AssetManufactureId, AssetManufacture);
            objParam[5] = new SqlParameter(Properties.Resources.ModelNo, ModelNo);
            objParam[6] = new SqlParameter(Properties.Resources.ModelName, ModelName);
            objParam[7] = new SqlParameter(Properties.Resources.SerialNo, SerialNo);
            objParam[8] = new SqlParameter(Properties.Resources.Description, Description);
            objParam[9] = new SqlParameter(Properties.Resources.AssetOwner, AssetOwner);
            objParam[10] = new SqlParameter(Properties.Resources.TagId, TagID);
            objParam[11] = new SqlParameter(Properties.Resources.Remarks, Remarks);
            objParam[12] = new SqlParameter(Properties.Resources.IsActive, IsActive);
            objParam[13] = new SqlParameter(Properties.Resources.Inactivewef, Inactivewef);
            objParam[14] = new SqlParameter(Properties.Resources.Activewef, Activewef);
            objParam[15] = new SqlParameter(Properties.Resources.Status, status);
            objParam[16] = new SqlParameter(Properties.Resources.Condition, Condition);
            objParam[17] = new SqlParameter(Properties.Resources.ModifiedBy, ModifiedBy);
            objParam[18] = new SqlParameter(Properties.Resources.Image, ImageUrl);
            objParam[19] = new SqlParameter(Properties.Resources.ManagementGuideline, MgmtGuideline);
            objParam[20] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "UdpAssetMasterDetailInsert", objParam);
            return ds;
        }
        public DataSet AssetMasterImageUpload(string AssetId, string ImageUrl, string ModifiedBy,string CompanyCode)
        {
            SqlParameter[] objParam = new SqlParameter[4];
            objParam[0] = new SqlParameter(Properties.Resources.AssetID, AssetId);
            objParam[1] = new SqlParameter(Properties.Resources.Image, ImageUrl);
            objParam[2] = new SqlParameter(Properties.Resources.ModifiedBy, ModifiedBy);
            objParam[3] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "UdpAssetMasterImageUpload", objParam);
            return ds;
        }
        public DataSet AssetMasterDetailUpdate(int AssetAutoId, string AssetCode, string AssetName, string AssetCategory, string AssetSubCategory, string AssetManufacture, string ModelNo, string ModelName, string SerialNo, string Description, string AssetOwner, string TagID, string Remarks, string IsActive, string Inactivewef, string Activewef, string status, string Condition, string ImageUrl, string MgmtGuideline, string ModifiedBy, string CompanyCode)
        {
            SqlParameter[] objParam = new SqlParameter[22];
            objParam[0] = new SqlParameter(Properties.Resources.AssetCode, AssetCode);
            objParam[1] = new SqlParameter(Properties.Resources.AssetName, AssetName);
            objParam[2] = new SqlParameter(Properties.Resources.AssetCategoryId, AssetCategory);
            objParam[3] = new SqlParameter(Properties.Resources.AssetSubCategoryId, AssetSubCategory);
            objParam[4] = new SqlParameter(Properties.Resources.AssetManufactureId, AssetManufacture);
            objParam[5] = new SqlParameter(Properties.Resources.ModelNo, ModelNo);
            objParam[6] = new SqlParameter(Properties.Resources.ModelName, ModelName);
            objParam[7] = new SqlParameter(Properties.Resources.SerialNo, SerialNo);
            objParam[8] = new SqlParameter(Properties.Resources.Description, Description);
            objParam[9] = new SqlParameter(Properties.Resources.AssetOwner, AssetOwner);
            objParam[10] = new SqlParameter(Properties.Resources.TagId, TagID);
            objParam[11] = new SqlParameter(Properties.Resources.Remarks, Remarks);
            objParam[12] = new SqlParameter(Properties.Resources.IsActive, IsActive);
            objParam[13] = new SqlParameter(Properties.Resources.Inactivewef, Inactivewef);
            objParam[14] = new SqlParameter(Properties.Resources.Activewef, Activewef);
            objParam[15] = new SqlParameter(Properties.Resources.Status, status);
            objParam[16] = new SqlParameter(Properties.Resources.Condition, Condition);
            objParam[17] = new SqlParameter(Properties.Resources.ModifiedBy, ModifiedBy);
            objParam[18] = new SqlParameter(Properties.Resources.AssetID, AssetAutoId);
            objParam[19] = new SqlParameter(Properties.Resources.Image, ImageUrl);
            objParam[20] = new SqlParameter(Properties.Resources.ManagementGuideline, MgmtGuideline);
            objParam[21] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "UdpAssetMasterDetailUpdate", objParam);
            return ds;
        }
        #endregion

        #region Function related to Asset Lease
        public DataSet AssetLeaseDetailGet(string AssetId,string CompanyCode)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(Properties.Resources.AssetID, AssetId);
            objParam[1] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "UdpAssetLeaseDetailGet", objParam);
            return ds;
        }

        public DataSet AssetLeaseInsert(int LeaseId, string assetName, string firmName, string firmEmail, string firmPhone, string firmAddress, string typeOfLease, string leaseStartDate, string leaseEndDate, decimal leaseAmount, string remarks, string ModifiedBy,string CompanyCode)
        {
            SqlParameter[] objParam = new SqlParameter[13];
            objParam[0] = new SqlParameter(Properties.Resources.LeaseAutoId, LeaseId);
            objParam[1] = new SqlParameter(Properties.Resources.AssetName, assetName);
            objParam[2] = new SqlParameter(Properties.Resources.Name, firmName);
            objParam[3] = new SqlParameter(Properties.Resources.Email, firmEmail);
            objParam[4] = new SqlParameter(Properties.Resources.Phone, firmPhone);
            objParam[5] = new SqlParameter(Properties.Resources.Address, firmAddress);
            objParam[6] = new SqlParameter(Properties.Resources.LeaseType, typeOfLease);
            objParam[7] = new SqlParameter(Properties.Resources.EndDate, Common.DateFormat(leaseEndDate, true));
            objParam[8] = new SqlParameter(Properties.Resources.Amount, leaseAmount);
            objParam[9] = new SqlParameter(Properties.Resources.Remarks, remarks);
            objParam[10] = new SqlParameter(Properties.Resources.ModifiedBy, ModifiedBy);
            objParam[11] = new SqlParameter(Properties.Resources.StartDate, Common.DateFormat(leaseStartDate, true));

            objParam[12] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "UdpAssetLeaseDetailInsert", objParam);
            return ds;
        }
        public DataSet AssetLeaseDelete(int LeaseId, string DocType,string CompanyCode)
        {
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(Properties.Resources.LeaseAutoId, LeaseId);
            objParam[1] = new SqlParameter(Properties.Resources.type, DocType);
            objParam[2] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "UdpAssetLeaseDelete", objParam);
            return ds;
        }
        public DataSet AssetLeaseUpdate(int LeaseId, string assetName, string firmName, string firmEmail, string firmPhone, string firmAddress, string typeOfLease, string leaseStartDate, string leaseEndDate, decimal leaseAmount, string remarks, string ModifiedBy,string CompanyCode)
        {
            SqlParameter[] objParam = new SqlParameter[13];
            objParam[0] = new SqlParameter(Properties.Resources.LeaseAutoId, LeaseId);
            objParam[1] = new SqlParameter(Properties.Resources.AssetName, assetName);
            objParam[2] = new SqlParameter(Properties.Resources.Name, firmName);
            objParam[3] = new SqlParameter(Properties.Resources.Email, firmEmail);
            objParam[4] = new SqlParameter(Properties.Resources.Phone, firmPhone);
            objParam[5] = new SqlParameter(Properties.Resources.Address, firmAddress);
            objParam[6] = new SqlParameter(Properties.Resources.LeaseType, typeOfLease);
            objParam[7] = new SqlParameter(Properties.Resources.EndDate, Common.DateFormat(leaseEndDate, true));
            objParam[8] = new SqlParameter(Properties.Resources.Amount, leaseAmount);
            objParam[9] = new SqlParameter(Properties.Resources.Remarks, remarks);
            objParam[10] = new SqlParameter(Properties.Resources.ModifiedBy, ModifiedBy);
            objParam[11] = new SqlParameter(Properties.Resources.StartDate, Common.DateFormat(leaseStartDate, true));
            objParam[12] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "UdpAssetLeaseDetailUpdate", objParam);
            return ds;
        }
        #endregion Function related to Asset Lease

        #region Function related to AssetInsurance
        public DataSet AssetInsuranceGetRecords(string AssetId,string CompanyCode)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(Properties.Resources.AssetID, AssetId);
            objParam[1] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
            DataSet ds = SqlHelper.ExecuteDataset("UdpAssetInsuranceDetailGet", objParam);
            return ds;
        }
        public DataSet AssetInsuranceAddNew(string AssetName, string PolicyNo, decimal SumInsured, string InsuranceCompanyName, string Email, string Phone, string InsurancePeriodFrom, string InsurancePeriodTo, string modifiedBy,string CompanyCode)
        {
            SqlParameter[] objParam = new SqlParameter[10];
            objParam[0] = new SqlParameter(Properties.Resources.AssetName, Convert.ToInt32(AssetName));
            objParam[1] = new SqlParameter(Properties.Resources.PolicyNo, PolicyNo);
            objParam[2] = new SqlParameter(Properties.Resources.SumInsured, SumInsured);
            objParam[3] = new SqlParameter(Properties.Resources.InsuranceCompanyName, InsuranceCompanyName);
            objParam[4] = new SqlParameter(Properties.Resources.Email, Email);
            objParam[5] = new SqlParameter(Properties.Resources.Phone, Phone);
            objParam[6] = new SqlParameter(Properties.Resources.InsurancePeriodFrom, Common.DateFormat(InsurancePeriodFrom, true));
            objParam[7] = new SqlParameter(Properties.Resources.InsurancePeriodTo, Common.DateFormat(InsurancePeriodTo, true));
            objParam[8] = new SqlParameter(Properties.Resources.ModifiedBy, modifiedBy);
            objParam[9] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
            DataSet addStatus = SqlHelper.ExecuteDataset("udpMstAssetInsuranceInsert", objParam);
            return addStatus;
        }
        public DataSet AssetInsuranceUpdate(int AssetInsuranceAutoId, decimal SumInsured, string InsuranceCompanyName, string Email, string PhoneNo, string InsurancePeriodFrom, string InsurancePeriodTo, string modifiedBy,string CompanyCode)
        {
            SqlParameter[] objParam = new SqlParameter[9];
            objParam[0] = new SqlParameter(Properties.Resources.AssetInsuranceAutoId, AssetInsuranceAutoId);
            objParam[1] = new SqlParameter(Properties.Resources.SumInsured, SumInsured);
            objParam[2] = new SqlParameter(Properties.Resources.InsuranceCompanyName, InsuranceCompanyName);
            objParam[3] = new SqlParameter(Properties.Resources.Email, Email);
            objParam[4] = new SqlParameter(Properties.Resources.Phone, PhoneNo);
            objParam[5] = new SqlParameter(Properties.Resources.InsurancePeriodFrom, Common.DateFormat(InsurancePeriodFrom));
            objParam[6] = new SqlParameter(Properties.Resources.InsurancePeriodTo, Common.DateFormat(InsurancePeriodTo));
            objParam[7] = new SqlParameter(Properties.Resources.ModifiedBy, modifiedBy);
            objParam[8] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
            DataSet updateStatus = SqlHelper.ExecuteDataset("udpMstAssetInsuranceUpdate", objParam);
            return updateStatus;
        }
        public DataSet AssetInsuranceDelete(int AssetInsuranceAutoId, string DocType,string CompanyCode)
        {
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(Properties.Resources.AssetInsuranceAutoId, AssetInsuranceAutoId);
            objParam[1] = new SqlParameter(Properties.Resources.type, DocType);
            objParam[2] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstAssetInsuranceDelete", objParam);
            return ds;
        }
        #endregion Function related to AssetInsurance

        #region Function related to AssetGurantee
        public DataSet AssetGuranteeGetRecords(string AssetId,string CompanyCode)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(Properties.Resources.AssetID, AssetId);
            objParam[1] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
            DataSet ds = SqlHelper.ExecuteDataset("UdpAssetGuranteeDetailGet", objParam);
            return ds;
        }
        public DataSet AssetGuranteeAddNew(string AssetName, string GuranteeExpDate, string modifiedBy,string CompanyCode)
        {
            SqlParameter[] objParam = new SqlParameter[4];
            objParam[0] = new SqlParameter(Properties.Resources.AssetName, Convert.ToInt32(AssetName));
            objParam[1] = new SqlParameter(Properties.Resources.GuranteeExpDate, Common.DateFormat(GuranteeExpDate, true));
            objParam[2] = new SqlParameter(Properties.Resources.ModifiedBy, modifiedBy);
            objParam[3] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
            DataSet addStatus = SqlHelper.ExecuteDataset("udpMstGuranteeInsert", objParam);
            return addStatus;
        }
        public DataSet AssetGuranteeUpdate(int AssetGuarantyAutoId, string GuranteeExpDate, string modifiedBy,string CompanyCode)
        {
            SqlParameter[] objParam = new SqlParameter[4];
            objParam[0] = new SqlParameter(Properties.Resources.AssetGuarantyAutoId, AssetGuarantyAutoId);
            objParam[1] = new SqlParameter(Properties.Resources.GuranteeExpDate, Common.DateFormat(GuranteeExpDate));
            objParam[2] = new SqlParameter(Properties.Resources.ModifiedBy, modifiedBy);
            objParam[3] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
            DataSet updateStatus = SqlHelper.ExecuteDataset("udpMstAssetGuranteeUpdate", objParam);
            return updateStatus;
        }
        public DataSet AssetGuranteeDelete(int AssetGuarantyAutoId, string DocType,string CompanyCode)
        {
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(Properties.Resources.AssetGuarantyAutoId, AssetGuarantyAutoId);
            objParam[1] = new SqlParameter(Properties.Resources.type, DocType);
            objParam[2] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstAssetGuranteeDelete", objParam);
            return ds;
        }
        #endregion Function related to AssetGurantee

        #region Function related to AssetWarrenty
        public DataSet AssetWarrentyGetRecords(string AssetId,string CompanyCode)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(Properties.Resources.AssetID, AssetId);
            objParam[1] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
            DataSet ds = SqlHelper.ExecuteDataset("UdpAssetWarrentyDetailGet", objParam);
            return ds;
        }
        public DataSet AssetWarrentyAddNew(string AssetName, string WarrentyExpDate, string modifiedBy,string CompanyCode)
        {
            SqlParameter[] objParam = new SqlParameter[4];
            objParam[0] = new SqlParameter(Properties.Resources.AssetName, Convert.ToInt32(AssetName));
            objParam[1] = new SqlParameter(Properties.Resources.WarrentyExpDate, Common.DateFormat(WarrentyExpDate, true));
            objParam[2] = new SqlParameter(Properties.Resources.ModifiedBy, modifiedBy);
            objParam[3] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
            DataSet addStatus = SqlHelper.ExecuteDataset("udpMstWarrentyInsert", objParam);
            return addStatus;
        }
        public DataSet AssetWarrentyUpdate(int AssetWarrentyAutoId, string WarrentyExpDate, string modifiedBy,string CompanyCode)
        {
            SqlParameter[] objParam = new SqlParameter[4];
            objParam[0] = new SqlParameter(Properties.Resources.AssetWarrentyAutoId, AssetWarrentyAutoId);
            objParam[1] = new SqlParameter(Properties.Resources.WarrentyExpDate, Common.DateFormat(WarrentyExpDate));
            objParam[2] = new SqlParameter(Properties.Resources.ModifiedBy, modifiedBy);
            objParam[3] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
            DataSet updateStatus = SqlHelper.ExecuteDataset("udpMstAssetWarrentyUpdate", objParam);
            return updateStatus;
        }
        public DataSet AssetWarrentyDelete(int AssetWarrentyAutoId, string DocType,string CompanyCode)
        {
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(Properties.Resources.AssetWarrentyAutoId, AssetWarrentyAutoId);
            objParam[1] = new SqlParameter(Properties.Resources.type, DocType);
            objParam[2] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstAssetWarrentyDelete", objParam);
            return ds;
        }
        #endregion Function related to AssetWarrenty

        #region Function related to Asset Purchase
        public DataSet AssetLeaseDeleteAfterPurchaseInsert(int AssetId)
        {
            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(Properties.Resources.AssetID, AssetId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "UdpAssetLeaseDeleteAfterPurchaseDetail", objParam);
            return ds;
        }
        public DataSet AssetPurchaseDetail(string AssetId,string CompanyCode)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(Properties.Resources.AssetID, AssetId);
            objParam[1] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "UdpAssetPurchaseDetail", objParam);
            return ds;
        }
        public DataSet AssetPurchaseDetailUpdate(int AssetAutoId, string CompanyName, string OrderNo, string OrderDate, decimal Price, string SupplierName, string SupplierEmail, string SupplierPhone, string SupplierAddress, string Remarks, string ImageUrl, string ModifiedBy,string CompanyCode)
        {
            SqlParameter[] objParam = new SqlParameter[13];
            objParam[0] = new SqlParameter(Properties.Resources.AssetID, AssetAutoId);
            objParam[1] = new SqlParameter(Properties.Resources.CompanyName, CompanyName);
            objParam[2] = new SqlParameter(Properties.Resources.OrderNo, OrderNo);
            objParam[3] = new SqlParameter(Properties.Resources.OrderDate, Common.DateFormat(OrderDate, true));
            objParam[4] = new SqlParameter(Properties.Resources.Price, Price);
            objParam[5] = new SqlParameter(Properties.Resources.SupplierName, SupplierName);
            objParam[6] = new SqlParameter(Properties.Resources.SupplierEmail, SupplierEmail);
            objParam[7] = new SqlParameter(Properties.Resources.SupplierPhone, SupplierPhone);
            objParam[8] = new SqlParameter(Properties.Resources.SupplierAddress, SupplierAddress);
            objParam[9] = new SqlParameter(Properties.Resources.Remarks, Remarks);
            objParam[10] = new SqlParameter(Properties.Resources.Image, ImageUrl);
            objParam[11] = new SqlParameter(Properties.Resources.ModifiedBy, ModifiedBy);
            objParam[12] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "UdpAssetPurchaseDetailUpdate", objParam);
            return ds;
        }
        public DataSet AssetPurchaseDetailInsert(int AssetAutoId, string CompanyName, string OrderNo, string OrderDate, decimal Price, string SupplierName, string SupplierEmail, string SupplierPhone, string SupplierAddress, string Remarks, string ImageUrl, string ModifiedBy,string CompanyCode)
        {
            SqlParameter[] objParam = new SqlParameter[13];
            objParam[0] = new SqlParameter(Properties.Resources.AssetID, AssetAutoId);
            objParam[1] = new SqlParameter(Properties.Resources.CompanyName, CompanyName);
            objParam[2] = new SqlParameter(Properties.Resources.OrderNo, OrderNo);
            objParam[3] = new SqlParameter(Properties.Resources.OrderDate, Common.DateFormat(OrderDate, true));
            objParam[4] = new SqlParameter(Properties.Resources.Price, Price);
            objParam[5] = new SqlParameter(Properties.Resources.SupplierName, SupplierName);
            objParam[6] = new SqlParameter(Properties.Resources.SupplierEmail, SupplierEmail);
            objParam[7] = new SqlParameter(Properties.Resources.SupplierPhone, SupplierPhone);
            objParam[8] = new SqlParameter(Properties.Resources.SupplierAddress, SupplierAddress);
            objParam[9] = new SqlParameter(Properties.Resources.Remarks, Remarks);
            objParam[10] = new SqlParameter(Properties.Resources.Image, ImageUrl);
            objParam[11] = new SqlParameter(Properties.Resources.ModifiedBy, ModifiedBy);
            objParam[12] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "UdpAssetPurchaseDetailInsert", objParam);
            return ds;
        }
        #endregion  Function related to Asset Purchase

        #region function related to Document Upload
        public DataSet AssetDocumentInsert(string category, int AssetAutoId, string DocDesc, string DocPath, string ModifiedBy,string CompanyCode)
        {
            SqlParameter[] objParam = new SqlParameter[6];
            objParam[0] = new SqlParameter(Properties.Resources.Catagory, category);
            objParam[1] = new SqlParameter(Properties.Resources.AssetID, AssetAutoId);
            objParam[2] = new SqlParameter(Properties.Resources.DocumentDesc, DocDesc);
            objParam[3] = new SqlParameter(Properties.Resources.DocumentFileName, DocPath);
            objParam[4] = new SqlParameter(Properties.Resources.ModifiedBy, ModifiedBy);
            objParam[5] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "UdpAssetDocumentInsert", objParam);
            return ds;
        }
        public DataSet AssetDocumentDetail(int AutoID, string Category,string CompanyCode)
        {
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(Properties.Resources.AssetID, AutoID);
            objParam[1] = new SqlParameter(Properties.Resources.Catagory, Category);
            objParam[2] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "UdpAssetDocumentDetailGet", objParam);
            return ds;
        }
        public DataSet AssetDocumentDelete(int ID,string CompanyCode)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(Properties.Resources.AssetID, ID);
            objParam[1] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "UdpAssetDocumentDelete", objParam);
            return ds;
        }
        public DataSet GetAssetDocumentsDetail(int AutoId, String Doctype,string CompanyCode)
        {
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(Properties.Resources.AssetID, AutoId);
            objParam[1] = new SqlParameter(Properties.Resources.type, Doctype);
            objParam[2] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "UdpAssetDocumentDetailGetForDeletion", objParam);
            return ds;
        }
        #endregion function related to Document Upload

        #region Function Related to AssetPart
        public DataSet AssetManufacturerNameDetailGet(string CompanyCode)
        {
            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "UdpAssetManufacturerNameDetailGet",objParam);
            return ds;
        }
        public DataSet AssetNameDetailGet(int AssetSubCategory, int AssetManufacturer,string CompanyCode)
        {
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(Properties.Resources.AssetSubCategoryAutoId, AssetSubCategory);
            objParam[1] = new SqlParameter(Properties.Resources.ManufacturerAutoID, AssetManufacturer);
            objParam[2] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "UdpAssetNameDetailGet", objParam);
            return ds;
        }
        public DataSet AssetModelNoGet(int SubCategoryAutoId, int ManufacturerAutoId, string AssetName,string CompanyCode)
        {
            SqlParameter[] objParam = new SqlParameter[4];
            objParam[0] = new SqlParameter(Properties.Resources.AssetSubCategoryAutoId, SubCategoryAutoId);
            objParam[1] = new SqlParameter(Properties.Resources.ManufactureAutoId, ManufacturerAutoId);
            objParam[2] = new SqlParameter(Properties.Resources.AssetName, AssetName);
            objParam[3] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "UdpAssetModelNoGet", objParam);
            return ds;
        }
        public DataSet AssetPartGetRecords(string CompanyCode)
        {
            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
            DataSet ds = SqlHelper.ExecuteDataset("UdpAssetPartDetailGet", objParam);
            return ds;
        }
        public DataSet AssetPartAddNew(int AssetCategory, int AssetSubCategory, int ManufacturerName, string AssetName, string ModelNo, string AssetPartNo, string AssetPartName, int AssetPartQuantity, string modifiedBy,string CompanyCode)
        {
            SqlParameter[] objParam = new SqlParameter[10];
            objParam[0] = new SqlParameter(Properties.Resources.AssetCategoryAutoId, AssetCategory);
            objParam[1] = new SqlParameter(Properties.Resources.AssetSubCategoryAutoId, AssetSubCategory);
            objParam[2] = new SqlParameter(Properties.Resources.ManufacturerAutoID, ManufacturerName);
            objParam[3] = new SqlParameter(Properties.Resources.AssetName, AssetName);
            objParam[4] = new SqlParameter(Properties.Resources.ModelNo, ModelNo);
            objParam[5] = new SqlParameter(Properties.Resources.AssetPartNo, AssetPartNo);
            objParam[6] = new SqlParameter(Properties.Resources.AssetPartName, AssetPartName);
            objParam[7] = new SqlParameter(Properties.Resources.AssetPartQuantity, Convert.ToInt32(AssetPartQuantity));
            objParam[8] = new SqlParameter(Properties.Resources.ModifiedBy, modifiedBy);
            objParam[9] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
            DataSet addStatus = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstAssetPartInsert", objParam);
            return addStatus;
        }
        public DataSet AssetPartUpdate(int AssetPartsAutoId, string AssetPartNo, string AssetPartName, int AssetPartQuantity, string modifiedBy,string CompanyCode)
        {
            SqlParameter[] objParam = new SqlParameter[6];
            objParam[0] = new SqlParameter(Properties.Resources.AssetPartsAutoId, AssetPartsAutoId);

            objParam[1] = new SqlParameter(Properties.Resources.AssetPartNo, AssetPartNo);
            objParam[2] = new SqlParameter(Properties.Resources.AssetPartName, AssetPartName);
            objParam[3] = new SqlParameter(Properties.Resources.AssetPartQuantity, AssetPartQuantity);
            objParam[4] = new SqlParameter(Properties.Resources.ModifiedBy, modifiedBy);
            objParam[5] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstAssetPartUpdate", objParam);
            return ds;
        }
        public DataSet AssetPartDelete(int AssetPartsAutoId,string CompanyCode)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(Properties.Resources.AssetPartsAutoId, AssetPartsAutoId);
            objParam[1] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstAssetPartsDelete", objParam);
            return ds;
        }

        #endregion Function Related to AssetPart

        #region Function Related to AssetServiceType
        public DataSet AssetServiceTypeGetRecords(string CompanyCode)
        {
            SqlParameter[] objParam = new SqlParameter[1];
                       objParam[0] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
            DataSet ds = SqlHelper.ExecuteDataset("UdpAssetServiceGet",objParam);
            return ds;
        }
        public DataSet AssetServiceTypeAddNew(string AssetName, string AssetServiceTypename, string modifiedBy,string CompanyCode)
        {
            SqlParameter[] objParam = new SqlParameter[4];

            objParam[0] = new SqlParameter(Properties.Resources.AssetName, AssetName);
            objParam[1] = new SqlParameter(Properties.Resources.AssetServiceTypeName, AssetServiceTypename);
            objParam[2] = new SqlParameter(Properties.Resources.ModifiedBy, modifiedBy);
            objParam[3] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
            DataSet addStatus = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstAssetServiceTypeInsertRecord", objParam);
            return addStatus;
        }
        public DataSet AssetServiceTypeUpdate(int AssetServiceTypeAutoId, string AssetName, string AssetServiceTypename, string modifiedBy,string CompanyCode)
        {
            SqlParameter[] objParam = new SqlParameter[5];
            objParam[0] = new SqlParameter(Properties.Resources.AssetServiceTypeAutoId, AssetServiceTypeAutoId);
            objParam[1] = new SqlParameter(Properties.Resources.AssetName, AssetName);
            objParam[2] = new SqlParameter(Properties.Resources.AssetServiceTypeName, AssetServiceTypename);
            objParam[3] = new SqlParameter(Properties.Resources.ModifiedBy, modifiedBy);
            objParam[4] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstAssetServiceTypeUpdateRecords", objParam);
            return ds;

        }
        public DataSet AssetServiceForDelete(int AssetServiceTypeAutoId,string CompanyCode)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(Properties.Resources.AssetServiceTypeAutoId, AssetServiceTypeAutoId);
            objParam[1] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpMstAssetServiceTypeDeleteRecords", objParam);
            return ds;
        }
        public DataSet AssetNameDetailForServiceType(string CompanyCode)
        {
            SqlParameter[] objParam = new SqlParameter[1];

            objParam[0] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "UdpAssetNameForServiceType",objParam);
            return ds;
        }
        #endregion

        #region Function related to Asset Service Checklist
        public DataSet AssetServiceTypeGet(int AssetId,string CompanyCode)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(Properties.Resources.AssetID, AssetId);
            objParam[1] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "UdpAssetServiceTypeGet", objParam);
            return ds;
        }
        public DataSet AssetChecklistNameInsert(int AssetId, int ServiceAutoId, string ChecklistName, string ModifiedBy,string CompanyCode)
        {
            SqlParameter[] objParam = new SqlParameter[5];
            objParam[0] = new SqlParameter(Properties.Resources.AssetID, AssetId);
            objParam[1] = new SqlParameter(Properties.Resources.AssetServiceTypeAutoId, ServiceAutoId);
            objParam[2] = new SqlParameter(Properties.Resources.ChecklistName, ChecklistName);
            objParam[3] = new SqlParameter(Properties.Resources.ModifiedBy, ModifiedBy);
            objParam[4] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "UdpAssetChecklistNameInsert", objParam);
            return ds;
        }
        public DataSet GetChecklistName(int AssetId, string ServiceAutoId,string CompanyCode)
        {
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(Properties.Resources.AssetID, AssetId);
            objParam[1] = new SqlParameter(Properties.Resources.AssetServiceTypeAutoId, ServiceAutoId);
            objParam[2] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "UdpChecklistNameGet", objParam);
            return ds;
        }
        public DataSet GetChecklistNameItems(int ChecklistId,string CompanyCode)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(Properties.Resources.CheckListAutoId, ChecklistId);
            objParam[1] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "UdpGetChecklistItems", objParam);
            return ds;
        }
        public DataSet ChecklistItemNameInsert(int ChecklistId, string ItemName, string ModifiedBy,string CompanyCode)
        {
            SqlParameter[] objParam = new SqlParameter[4];
            objParam[0] = new SqlParameter(Properties.Resources.CheckListAutoId, ChecklistId);
            objParam[1] = new SqlParameter(Properties.Resources.ChecklistItem, ItemName);
            objParam[2] = new SqlParameter(Properties.Resources.ModifiedBy, ModifiedBy);
            objParam[3] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "UdpAssetChecklistItemInsert", objParam);
            return ds;

        }
        public DataSet ChecklistItemNameUpdate(int ChecklistId, string ItemName, string ModifiedBy,string CompanyCode)
        {
            SqlParameter[] objParam = new SqlParameter[4];
            objParam[0] = new SqlParameter(Properties.Resources.CheckListAutoId, ChecklistId);
            objParam[1] = new SqlParameter(Properties.Resources.ChecklistItem, ItemName);
            objParam[2] = new SqlParameter(Properties.Resources.ModifiedBy, ModifiedBy);
            objParam[3] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "UdpAssetChecklistItemUpdate", objParam);
            return ds;

        }
        public DataSet ChecklistItemNameDelete(int ChecklistId,string CompanyCode)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(Properties.Resources.CheckListAutoId, ChecklistId);
            objParam[1] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "UdpAssetChecklistItemDelete", objParam);
            return ds;
        }
        #endregion

        #region Function related to Asset Note
        public DataSet AssetNoteDetailGet(string AssetId,string CompanyCode)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(Properties.Resources.AssetID, AssetId);
            objParam[1] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "UdpAssetNoteDetailGet", objParam);
            return ds;
        }
        public DataSet AssetNoteInsert(string AssetId, string Towhom, string NoteType, string Note, string ModifiedBy,string CompanyCode)
        {
            SqlParameter[] objParam = new SqlParameter[6];
            objParam[0] = new SqlParameter(Properties.Resources.AssetID, AssetId);
            objParam[1] = new SqlParameter(Properties.Resources.ToWhom, Towhom);
            objParam[2] = new SqlParameter(Properties.Resources.NoteType, NoteType);
            objParam[3] = new SqlParameter(Properties.Resources.Note, Note);
            objParam[4] = new SqlParameter(Properties.Resources.ModifiedBy, ModifiedBy);
            objParam[5] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "UdpAssetNoteDetailInsert", objParam);
            return ds;
        }
        public DataSet AssetNoteUpdate(string AssetNoteAutoId, string AssetId, string Towhom, string NoteType, string Note, string ModifiedBy,string CompanyCode)
        {
            SqlParameter[] objParam = new SqlParameter[7];
            objParam[0] = new SqlParameter(Properties.Resources.AssetID, AssetId);
            objParam[1] = new SqlParameter(Properties.Resources.ToWhom, Towhom);
            objParam[2] = new SqlParameter(Properties.Resources.NoteType, NoteType);
            objParam[3] = new SqlParameter(Properties.Resources.Note, Note);
            objParam[4] = new SqlParameter(Properties.Resources.ModifiedBy, ModifiedBy);
            objParam[5] = new SqlParameter(Properties.Resources.AssetNoteAutoId, AssetNoteAutoId);
            objParam[6] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "UdpAssetNoteDetailUpdate", objParam);
            return ds;
        }
        public DataSet AssetNoteDelete(string AssetNoteAutoId,string CompanyCode)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(Properties.Resources.AssetNoteAutoId, AssetNoteAutoId);
            objParam[1] = new SqlParameter(Properties.Resources.CompanyCode, CompanyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "UdpAssetNoteDelete", objParam);
            return ds;
        }
        #endregion

        #region Function related to Asset AMC
        public DataSet AssetAMCDetailGet(string AssetId,string CompanyCode)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(DL.Properties.Resources.AssetID, AssetId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.CompanyCode, CompanyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "UdpAssetAMCDetailGet", objParam);
            return ds;
        }
        public DataSet AssetAMCInsert(string assetName, string firmName, string firmEmail, string firmPhone, string firmAddress, string AMCType, string StartDate, string EndDate, decimal Amount, string Terms, string ModifiedBy,string CompanyCode)
        {
            SqlParameter[] objParam = new SqlParameter[12];
            objParam[0] = new SqlParameter(DL.Properties.Resources.StartDate, DL.Common.DateFormat(StartDate, true));
            objParam[1] = new SqlParameter(DL.Properties.Resources.AssetName, assetName);
            objParam[2] = new SqlParameter(DL.Properties.Resources.Name, firmName);
            objParam[3] = new SqlParameter(DL.Properties.Resources.Email, firmEmail);
            objParam[4] = new SqlParameter(DL.Properties.Resources.Phone, firmPhone);
            objParam[5] = new SqlParameter(DL.Properties.Resources.Address, firmAddress);
            objParam[6] = new SqlParameter(DL.Properties.Resources.AMCType, AMCType);
            objParam[7] = new SqlParameter(DL.Properties.Resources.EndDate, DL.Common.DateFormat(EndDate, true));
            objParam[8] = new SqlParameter(DL.Properties.Resources.Amount, Amount);
            objParam[9] = new SqlParameter(DL.Properties.Resources.Terms, Terms);
            objParam[10] = new SqlParameter(DL.Properties.Resources.ModifiedBy, ModifiedBy);
            objParam[11] = new SqlParameter(DL.Properties.Resources.CompanyCode, CompanyCode);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "UdpAssetAMCDetailInsert", objParam);
            return ds;
        }
        public DataSet AssetAMCDelete(string AMCAutoId, string DocType,string CompanyCode)
        {
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.AMCAutoId, AMCAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.type, DocType);
            objParam[2] = new SqlParameter(DL.Properties.Resources.CompanyCode, CompanyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "UdpAssetAMCDelete", objParam);
            return ds;
        }
        public DataSet AssetAMCUpdate(string AMCAutoId, string assetName, string firmName, string firmEmail, string firmPhone, string firmAddress, string AMCType, string StartDate, string EndDate, decimal Amount, string Terms, string ModifiedBy, string CompanyCode)
        {
            SqlParameter[] objParam = new SqlParameter[13];
            objParam[0] = new SqlParameter(DL.Properties.Resources.AMCAutoId, AMCAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.AssetName, assetName);
            objParam[2] = new SqlParameter(DL.Properties.Resources.Name, firmName);
            objParam[3] = new SqlParameter(DL.Properties.Resources.Email, firmEmail);
            objParam[4] = new SqlParameter(DL.Properties.Resources.Phone, firmPhone);
            objParam[5] = new SqlParameter(DL.Properties.Resources.Address, firmAddress);
            objParam[6] = new SqlParameter(DL.Properties.Resources.AMCType, AMCType);
            objParam[7] = new SqlParameter(DL.Properties.Resources.StartDate, DL.Common.DateFormat(StartDate, true));
            objParam[8] = new SqlParameter(DL.Properties.Resources.EndDate, DL.Common.DateFormat(EndDate, true));
            objParam[9] = new SqlParameter(DL.Properties.Resources.Amount, Amount);
            objParam[10] = new SqlParameter(DL.Properties.Resources.Terms, Terms);
            objParam[11] = new SqlParameter(DL.Properties.Resources.ModifiedBy, ModifiedBy);
            objParam[12] = new SqlParameter(DL.Properties.Resources.CompanyCode, CompanyCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "UdpAssetAMCDetailUpdate", objParam);
            return ds;
        }
        #endregion

        #region Function related to Asset Client Mapping
        public DataSet AssetClientMappingInsert(int AssetAutoId, int LocationAutoId, string ClientCode, string AsmtId, int PostAutoId, string Remarks, string Usage, string ModifiedBy)
        {
            SqlParameter[] objParam = new SqlParameter[8];
            objParam[0] = new SqlParameter(Properties.Resources.AssetID, AssetAutoId);
            objParam[1] = new SqlParameter(Properties.Resources.LocationAutoId, LocationAutoId);
            objParam[2] = new SqlParameter(Properties.Resources.ClientCode, ClientCode);
            objParam[3] = new SqlParameter(Properties.Resources.AsmtId, AsmtId);
            objParam[4] = new SqlParameter(Properties.Resources.PostAutoId, PostAutoId);
            objParam[5] = new SqlParameter(Properties.Resources.Remarks, Remarks);
            objParam[6] = new SqlParameter(Properties.Resources.Usage, Usage);
            objParam[7] = new SqlParameter(Properties.Resources.ModifiedBy, ModifiedBy);


            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "UdpAssetClientMappingInsert", objParam);
            return ds;
        }
        public DataSet AssetClientMappingGetRecords(string AssetId)
        {
            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter(Properties.Resources.AssetID, AssetId);
            DataSet ds = SqlHelper.ExecuteDataset("UdpAssetClientMappingDetail", objParam);
            return ds;
        }
        public DataSet AssetClientMappingUpdate(int AssetAutoId, int LocationAutoId, string ClientCode, string AsmtId, int PostAutoId, string Remarks, string Usage, string ModifiedBy)
        {
            SqlParameter[] objParam = new SqlParameter[8];
            objParam[0] = new SqlParameter(Properties.Resources.AssetID, AssetAutoId);
            objParam[1] = new SqlParameter(Properties.Resources.LocationAutoId, LocationAutoId);
            objParam[2] = new SqlParameter(Properties.Resources.ClientCode, ClientCode);
            objParam[3] = new SqlParameter(Properties.Resources.AsmtId, AsmtId);
            objParam[4] = new SqlParameter(Properties.Resources.PostAutoId, PostAutoId);
            objParam[5] = new SqlParameter(Properties.Resources.Remarks, Remarks);
            objParam[6] = new SqlParameter(Properties.Resources.Usage, Usage);
            objParam[7] = new SqlParameter(Properties.Resources.ModifiedBy, ModifiedBy);


            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "UdpAssetClientMappingUpdate", objParam);
            return ds;
        }
        public DataSet AssetClientMappingDelete(int AssetAutoId, int LocationAutoId)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(Properties.Resources.AssetID, AssetAutoId);
            objParam[1] = new SqlParameter(Properties.Resources.LocationAutoId, LocationAutoId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "UdpAssetClientMappingDelete", objParam);
            return ds;
        }
        #endregion
        # region function related to Ticket Master
        public DataSet GetAllTickets(string LocationAutoId, string Status, string TicketNo, string UserId, string Date, string ToDate)
        {
            SqlParameter[] objParam = new SqlParameter[6];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, LocationAutoId);
            objParam[1] = new SqlParameter(DL.Properties.Resources.Status, Status);
            objParam[2] = new SqlParameter(DL.Properties.Resources.TicketNo, TicketNo);
            objParam[3] = new SqlParameter(DL.Properties.Resources.UserId, UserId);
            objParam[4] = new SqlParameter(DL.Properties.Resources.Date, DL.Common.DateFormat(Date));
            objParam[5] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(ToDate));
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_GetAllAssetWorkOrder",objParam);
            return ds;
        }
        public DataSet TicketDetail(string TicketNo, string LocationAutoId)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(Properties.Resources.TicketNo, TicketNo);
            objParam[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, LocationAutoId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_GetTicketDetailWeb", objParam);
            return ds;
        }
        public DataSet UpdateTicketStatus(string TicketNo, string Status, string LocationAutoId, string ModifiedBy)
        {
            SqlParameter[] objParam = new SqlParameter[4];
            objParam[0] = new SqlParameter(Properties.Resources.TicketNo, TicketNo);
            objParam[1] = new SqlParameter(Properties.Resources.Status, Status);
            objParam[2] = new SqlParameter(DL.Properties.Resources.LocationAutoId, LocationAutoId);
            objParam[3] = new SqlParameter(DL.Properties.Resources.ModifiedBy, ModifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_UpdateTicketStatusWeb", objParam);
            return ds;
        }
        public DataSet GetEmployeeAttendence(string LocationAutoId, string Post, string Date, string EmployeeNo, string ToDate)
        {
            SqlParameter[] objParam = new SqlParameter[5];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, Convert.ToInt32(LocationAutoId));
            objParam[1] = new SqlParameter(DL.Properties.Resources.PostAutoId, Post);
            objParam[2] = new SqlParameter(DL.Properties.Resources.Date, DL.Common.DateFormat(Date));
            objParam[3] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, EmployeeNo);
            objParam[4] = new SqlParameter(DL.Properties.Resources.ToDate, DL.Common.DateFormat(ToDate));
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_GetEmployeeAttendenceWeb", objParam);
            return ds;
        }
        #endregion
        #region Function related to Task Master
        public DataSet GetClientCode(string LocationAutoID)
        {
             SqlParameter[] objParam = new SqlParameter[1];
             objParam[0] = new SqlParameter(Properties.Resources.LocationAutoId, Convert.ToInt32(LocationAutoID));
             DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_GetClientCodeWeb", objParam);
            return ds;
        }
        public DataSet GetAsmtId(string ClientCode, string LocationAutoID)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(Properties.Resources.ClientCode, ClientCode);
            objParam[1] = new SqlParameter(Properties.Resources.LocationAutoId,Convert.ToInt32(LocationAutoID));
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_GetSiteIdWeb", objParam);
            return ds;
        }
        public DataSet GetPostCode(string ClientCode, string AsmtId, string LocationAutoID)
        {
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(Properties.Resources.ClientCode, ClientCode);
            objParam[1] = new SqlParameter(Properties.Resources.AsmtId, AsmtId);
            objParam[2] = new SqlParameter(Properties.Resources.LocationAutoId, Convert.ToInt32(LocationAutoID));
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_GetPostIdWeb", objParam);
            return ds;
        }
        public DataSet GetPerformerSiteDetails(string ClientCode, string AsmtId, string PostId, string LocationAutoID, string Date)
        {
            SqlParameter[] objParam = new SqlParameter[5];
            objParam[0] = new SqlParameter(Properties.Resources.ClientCode, ClientCode);
            objParam[1] = new SqlParameter(Properties.Resources.AsmtId, AsmtId);
            objParam[2] = new SqlParameter(Properties.Resources.PostAutoId, PostId);
            objParam[3] = new SqlParameter(Properties.Resources.LocationAutoId, Convert.ToInt32(LocationAutoID));
            objParam[4] = new SqlParameter(Properties.Resources.Date, DL.Common.DateFormat(Date));
          //  objParam[5] = new SqlParameter(Properties.Resources.ToDate, DL.Common.DateFormat(ToDate));
            //DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_GetPerformerSiteDetailsWeb", objParam);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpGetUnsechedulledTask", objParam);
            return ds;
        }
        public DataSet GetDailyTaskDetail(string AutoId, string AsmtId, string LocationAutoID, string Date, string AssetAutoID)
        {
            SqlParameter[] objParam = new SqlParameter[5];
            objParam[0] = new SqlParameter(Properties.Resources.AssetServiceTypeAutoId, Convert.ToInt32(AutoId));
            objParam[1] = new SqlParameter(Properties.Resources.AsmtId, AsmtId);
            objParam[2] = new SqlParameter(Properties.Resources.LocationAutoId, Convert.ToInt32(LocationAutoID));
            objParam[3] = new SqlParameter(Properties.Resources.Date, DL.Common.DateFormat(Date));
            objParam[4] = new SqlParameter(Properties.Resources.AssetAutoId,Convert.ToInt32( AssetAutoID));
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_GetDailyTaskUpdateWeb", objParam);
            return ds;
        }
        public DataSet GetDailyTaskDetailUnSchedulled(string AutoId, string AsmtId, string LocationAutoID)
        {
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(Properties.Resources.AssetServiceTypeAutoId, Convert.ToInt32(AutoId));
            objParam[1] = new SqlParameter(Properties.Resources.AsmtId, AsmtId);
            objParam[2] = new SqlParameter(Properties.Resources.LocationAutoId, Convert.ToInt32(LocationAutoID));
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_GetDailyTaskUpdateUnschedulled", objParam);
            return ds;
        }
        public DataSet UpdateDailyTaskStatus(string AssetScheduleAutoId, string TaskName, string Status, string LocationAutoID, string UserId, string Date)
        {
            SqlParameter[] objParam = new SqlParameter[6];
            objParam[0] = new SqlParameter(Properties.Resources.AssetAutoId, Convert.ToInt32(AssetScheduleAutoId));
            objParam[1] = new SqlParameter(Properties.Resources.ChecklistItem, TaskName);
            objParam[2] = new SqlParameter(Properties.Resources.Status, Status);
            objParam[3] = new SqlParameter(Properties.Resources.LocationAutoId, Convert.ToInt32(LocationAutoID));
            objParam[4] = new SqlParameter(Properties.Resources.Date, DL.Common.DateFormat(Date));
            objParam[5] = new SqlParameter(Properties.Resources.ModifiedBy, UserId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_UpdateDailyTaskStatusWeb", objParam);
            return ds;
        }
        public DataSet GetDailyTaskImage(string CheckListItem, string LocationAutoID, string Date,string FromTime,string ToTime)
        {
            SqlParameter[] objParam = new SqlParameter[5];
            objParam[0] = new SqlParameter(Properties.Resources.ChecklistItem, CheckListItem);
            objParam[1] = new SqlParameter(Properties.Resources.LocationAutoId, Convert.ToInt32(LocationAutoID));
            objParam[2] = new SqlParameter(Properties.Resources.Date, DL.Common.DateFormat(Date));
            objParam[3] = new SqlParameter(Properties.Resources.FromTime, FromTime);
            objParam[4] = new SqlParameter(Properties.Resources.ToTime, ToTime);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_GetTaskImageWeb", objParam);
            return ds;
        }
        #endregion
        #region Function related to Asset Client Mapping
        public DataSet AssetClientMappingInsert(int AssetAutoId, int LocationAutoId, string ClientCode, string AsmtId, int PostAutoId, string Remarks, string Usage, string ModifiedBy, string LocationTagging)
        {
            SqlParameter[] objParam = new SqlParameter[9];
            objParam[0] = new SqlParameter(Properties.Resources.AssetID, AssetAutoId);
            objParam[1] = new SqlParameter(Properties.Resources.LocationAutoId, LocationAutoId);
            objParam[2] = new SqlParameter(Properties.Resources.ClientCode, ClientCode);
            objParam[3] = new SqlParameter(Properties.Resources.AsmtId, AsmtId);
            objParam[4] = new SqlParameter(Properties.Resources.PostAutoId, PostAutoId);
            objParam[5] = new SqlParameter(Properties.Resources.Remarks, Remarks);
            objParam[6] = new SqlParameter(Properties.Resources.Usage, Usage);
            objParam[7] = new SqlParameter(Properties.Resources.ModifiedBy, ModifiedBy);
            objParam[8] = new SqlParameter(Properties.Resources.TagId, LocationTagging);


            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "UdpAssetClientMappingInsert", objParam);
            return ds;
        }
        public DataSet AssetClientMappingUpdate(int AssetAutoId, int LocationAutoId, string ClientCode, string AsmtId, int PostAutoId, string Remarks, string Usage, string ModifiedBy, string LocationTagging)
        {
            SqlParameter[] objParam = new SqlParameter[9];
            objParam[0] = new SqlParameter(Properties.Resources.AssetID, AssetAutoId);
            objParam[1] = new SqlParameter(Properties.Resources.LocationAutoId, LocationAutoId);
            objParam[2] = new SqlParameter(Properties.Resources.ClientCode, ClientCode);
            objParam[3] = new SqlParameter(Properties.Resources.AsmtId, AsmtId);
            objParam[4] = new SqlParameter(Properties.Resources.PostAutoId, PostAutoId);
            objParam[5] = new SqlParameter(Properties.Resources.Remarks, Remarks);
            objParam[6] = new SqlParameter(Properties.Resources.Usage, Usage);
            objParam[7] = new SqlParameter(Properties.Resources.ModifiedBy, ModifiedBy);
            objParam[8] = new SqlParameter(Properties.Resources.TagId, LocationTagging);

            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "UdpAssetClientMappingUpdate", objParam);
            return ds;
        }

        public DataSet GetAssetOwnerMapping(int LocationAutoId, int AssetAutoId)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(Properties.Resources.LocationAutoId, LocationAutoId);
            objParam[1] = new SqlParameter(Properties.Resources.AssetID, AssetAutoId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpGetAssetOwnerMappingOnTheBasisOfAssetId", objParam);
            return ds;
        }
        public DataSet OwnerAssetMappingInsert(int AssetId, string employeeNumber, string locationAutoId, string modifiedBy, string effectiveFrom, string EmpName, string AssetCode)
        {
            SqlParameter[] objParam = new SqlParameter[7];
            objParam[0] = new SqlParameter(Properties.Resources.AssetID, AssetId);
            objParam[1] = new SqlParameter(Properties.Resources.EmployeeNumber, employeeNumber);
            objParam[2] = new SqlParameter(Properties.Resources.LocationAutoId, locationAutoId);
            objParam[3] = new SqlParameter(Properties.Resources.ModifiedBy, modifiedBy);
            objParam[4] = new SqlParameter(Properties.Resources.FromDate, effectiveFrom);
            objParam[5] = new SqlParameter(Properties.Resources.Name, EmpName);
            objParam[6] = new SqlParameter(Properties.Resources.AssetCode, AssetCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpAssetOwnerMappingInsert", objParam);
            return ds;
        }
        public DataSet OwnerAssetMappingDelete(string AssetId, string employeeNumber, string locationAutoId)
        {

            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.AssetAutoId, Convert.ToInt32(AssetId));
            objParam[1] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParam[2] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpAssetOwnerMappingDelete", objParam);
            return ds;

        }

        public DataSet OwnerAssetMappingUpdate(string AssetId, string employeeNumber, string locationAutoId, string areaInchargeAutoId, string effectiveFrom, string effectiveTo, string modifiedBy)
        {
            SqlParameter[] objParam = new SqlParameter[7];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, Convert.ToInt32(locationAutoId));
            objParam[1] = new SqlParameter(DL.Properties.Resources.AssetAutoId, Convert.ToInt32(AssetId));
            objParam[2] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParam[3] = new SqlParameter(DL.Properties.Resources.AutoId, Convert.ToInt32(areaInchargeAutoId));
            objParam[4] = new SqlParameter(DL.Properties.Resources.EffectiveFromDate, DL.Common.DateFormat(effectiveFrom));
            objParam[5] = new SqlParameter(DL.Properties.Resources.EffectiveToDate, DL.Common.DateFormat(effectiveTo));
            objParam[6] = new SqlParameter(DL.Properties.Resources.ModifiedBy, modifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpAssetOwnerMappingUpdate", objParam);
            return ds;

        }
        public DataSet GetAllEmployeeByLocation(string employeeNumber, string employeeName, int locationAutoId)
        {
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.EmployeeNumber, employeeNumber);
            objParam[1] = new SqlParameter(DL.Properties.Resources.Name, employeeName);
            objParam[2] = new SqlParameter(DL.Properties.Resources.LocationAutoId, locationAutoId);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpGetAllEmployeeByLocation", objParam);
            return ds;
        }
        public DataSet GetPendingTasklist(string ClientCode, string AsmtId, string PostId, string LocationAutoID, string Date, string ToDate)
        {
            SqlParameter[] objParam = new SqlParameter[6];
            objParam[0] = new SqlParameter(Properties.Resources.ClientCode, ClientCode);
            objParam[1] = new SqlParameter(Properties.Resources.AsmtId, AsmtId);
            objParam[2] = new SqlParameter(Properties.Resources.PostAutoId, PostId);
            objParam[3] = new SqlParameter(Properties.Resources.LocationAutoId, Convert.ToInt32(LocationAutoID));
            objParam[4] = new SqlParameter(Properties.Resources.Date, DL.Common.DateFormat(Date));
            objParam[5] = new SqlParameter(Properties.Resources.ToDate, DL.Common.DateFormat(ToDate));
            //DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_GetPerformerSiteDetailsWeb", objParam);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpGetPendingTaskList", objParam);
            return ds;
        }
        public DataSet GetCompletedTasklist(string ClientCode, string AsmtId, string PostId, string LocationAutoID, string Date, string ToDate, string Status)
        {
            SqlParameter[] objParam = new SqlParameter[7];
            objParam[0] = new SqlParameter(Properties.Resources.ClientCode, ClientCode);
            objParam[1] = new SqlParameter(Properties.Resources.AsmtId, AsmtId);
            objParam[2] = new SqlParameter(Properties.Resources.PostAutoId, PostId);
            objParam[3] = new SqlParameter(Properties.Resources.LocationAutoId, Convert.ToInt32(LocationAutoID));
            objParam[4] = new SqlParameter(Properties.Resources.Date, DL.Common.DateFormat(Date));
            objParam[5] = new SqlParameter(Properties.Resources.ToDate, DL.Common.DateFormat(ToDate));
            objParam[6] = new SqlParameter(Properties.Resources.Status, Status);
            //DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_GetPerformerSiteDetailsWeb", objParam);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpGetCompletedTaskList", objParam);
            return ds;
        }
        #endregion
        #region function related to Graphical Dashboard
        public DataSet GetGraphTasklist(string ClientCode, string AsmtId, string PostId, string LocationAutoID, string Date, string ToDate, string Status)
        {
            SqlParameter[] objParam = new SqlParameter[7];
            objParam[0] = new SqlParameter(Properties.Resources.ClientCode, ClientCode);
            objParam[1] = new SqlParameter(Properties.Resources.AsmtId, AsmtId);
            objParam[2] = new SqlParameter(Properties.Resources.PostAutoId, PostId);
            objParam[3] = new SqlParameter(Properties.Resources.LocationAutoId, Convert.ToInt32(LocationAutoID));
            objParam[4] = new SqlParameter(Properties.Resources.Date, DL.Common.DateFormat(Date));
            objParam[5] = new SqlParameter(Properties.Resources.ToDate, DL.Common.DateFormat(ToDate));
            objParam[6] = new SqlParameter(Properties.Resources.Status, Status);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpGetGraphTaskList", objParam);
            return ds;
        }
        public DataSet GetGraphTasklistDetail(string ClientCode, string AsmtId, string PostId, string LocationAutoID, string Date, string Status)
        {
            SqlParameter[] objParam = new SqlParameter[6];
            objParam[0] = new SqlParameter(Properties.Resources.ClientCode, ClientCode);
            objParam[1] = new SqlParameter(Properties.Resources.AsmtId, AsmtId);
            objParam[2] = new SqlParameter(Properties.Resources.PostAutoId, PostId);
            objParam[3] = new SqlParameter(Properties.Resources.LocationAutoId, Convert.ToInt32(LocationAutoID));
            objParam[4] = new SqlParameter(Properties.Resources.Date, DL.Common.DateFormat(Date));
            objParam[5] = new SqlParameter(Properties.Resources.Status, Status);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpGetGraphTaskListDetails", objParam);
            return ds;
        }
        #endregion

        public DataSet GetCompletedTasklist_ShiftBasis(string ClientCode, string AsmtId, string PostId, string LocationAutoID, string Date, string ToDate, string Status, string Shift)
        {
            SqlParameter[] objParam = new SqlParameter[8];
            objParam[0] = new SqlParameter(Properties.Resources.ClientCode, ClientCode);
            objParam[1] = new SqlParameter(Properties.Resources.AsmtId, AsmtId);
            objParam[2] = new SqlParameter(Properties.Resources.PostAutoId, PostId);
            objParam[3] = new SqlParameter(Properties.Resources.LocationAutoId, Convert.ToInt32(LocationAutoID));
            objParam[4] = new SqlParameter(Properties.Resources.Date, DL.Common.DateFormat(Date));
            objParam[5] = new SqlParameter(Properties.Resources.ToDate, DL.Common.DateFormat(ToDate));
            objParam[6] = new SqlParameter(Properties.Resources.Status, Status);
            objParam[7] = new SqlParameter(Properties.Resources.Shift, Shift);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udpGetCompletedTaskList_ShiftBasis", objParam);
            return ds;
        }


        public DataSet ElectronicToActualAttendance(string ClientCode, string AsmtId, string Shift, string Date, string LocationId, string ModifiedBy)
        {
            SqlParameter[] objParam = new SqlParameter[6];
            objParam[0] = new SqlParameter(DL.Properties.Resources.ClientCode, ClientCode);
            objParam[1] = new SqlParameter(DL.Properties.Resources.AsmtId, AsmtId);
            objParam[2] = new SqlParameter(DL.Properties.Resources.ShiftCode, Shift);
            objParam[3] = new SqlParameter(DL.Properties.Resources.DutyDate, DL.Common.DateFormat(Date, true));
            objParam[4] = new SqlParameter(DL.Properties.Resources.LocationAutoId, LocationId);
            objParam[5] = new SqlParameter(DL.Properties.Resources.ModifiedBy, ModifiedBy);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_ElectronictoActualAttendance", objParam);
            return ds;
        }

        public DataSet ConvertToActual(string BaseLocationAutoID, string BaseUserID, string Date)
        {
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.DutyDate, DL.Common.DateFormat(Date, true));
            objParam[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, Convert.ToInt32(BaseLocationAutoID));
            objParam[2] = new SqlParameter(DL.Properties.Resources.ModifiedBy, BaseUserID);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_ConvertToActualAttendanceMilkBasket", objParam);
            return ds;
        }

        public DataSet ConvertToActualWithShift(string BaseLocationAutoID, string BaseUserID, string Date)
        {
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.DutyDate, DL.Common.DateFormat(Date, true));
            objParam[1] = new SqlParameter(DL.Properties.Resources.LocationAutoId, Convert.ToInt32(BaseLocationAutoID));
            objParam[2] = new SqlParameter(DL.Properties.Resources.ModifiedBy, BaseUserID);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_ConvertToActualAttendanceMilkBasketWithShift", objParam);
            return ds;
        }
        

              public DataSet AttendanceMusterDataMacquarie(int BaseLocationAutoID, int Year, int Month)
        {
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, BaseLocationAutoID);
            objParam[1] = new SqlParameter(DL.Properties.Resources.Year, Year);
            objParam[2] = new SqlParameter(DL.Properties.Resources.Month, Month);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_GetAttendanceMusterMacquarie", objParam);
            return ds;
        }
        public DataSet AttendanceMusterData(int BaseLocationAutoID, int Year, int Month)
        {
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, BaseLocationAutoID);
            objParam[1] = new SqlParameter(DL.Properties.Resources.Year, Year);
            objParam[2] = new SqlParameter(DL.Properties.Resources.Month, Month);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_GetAttendanceMuster", objParam);
            return ds;
        }

        public DataSet CPMaterialIN(string CP,string MaterialId, string Date, string Quantity, string Vendor, string Type, string LocationId, string Userid)
        {
            SqlParameter[] objParam = new SqlParameter[8];
            objParam[0] = new SqlParameter("@MaterialId",Convert.ToInt32(MaterialId));
            objParam[1] = new SqlParameter("@Date", DL.Common.DateFormat(Date));
            objParam[2] = new SqlParameter("@Quantity", Convert.ToInt32( Quantity));
            objParam[3] = new SqlParameter("@Vendor", Vendor);
            objParam[4] = new SqlParameter("@Type", Type);
            objParam[5] = new SqlParameter("@LocationId",Convert.ToInt32(LocationId));
            objParam[6] = new SqlParameter("@Userid", Userid);
            objParam[7] = new SqlParameter("@CP", CP);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_InsertMaterialCP", objParam);
            return ds;
        }

        public DataSet HUBMaterialIN(string CP, string MaterialId, string Date, string Quantity,  string Type, string LocationId, string Userid,string HUB)
        {
            SqlParameter[] objParam = new SqlParameter[8];
            objParam[0] = new SqlParameter("@MaterialId", Convert.ToInt32(MaterialId));
            objParam[1] = new SqlParameter("@Date", DL.Common.DateFormat(Date));
            objParam[2] = new SqlParameter("@Quantity", Convert.ToInt32(Quantity));        
            objParam[3] = new SqlParameter("@Type", Type);
            objParam[4] = new SqlParameter("@LocationId", Convert.ToInt32(LocationId));
            objParam[5] = new SqlParameter("@Userid", Userid);
            objParam[6] = new SqlParameter("@CP", CP);
            objParam[7] = new SqlParameter("@HUB", HUB);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_InsertMaterialHUB", objParam);
            return ds;
        }

        public DataSet CPMaterialOUT(string CP, string MaterialId, string Date, string Quantity, string Delivery, string Type, string LocationId, string Userid, string HUB)
        {
            SqlParameter[] objParam = new SqlParameter[9];
            objParam[0] = new SqlParameter("@MaterialId", Convert.ToInt32(MaterialId));
            objParam[1] = new SqlParameter("@Date", DL.Common.DateFormat(Date));
            objParam[2] = new SqlParameter("@Quantity", Convert.ToInt32(Quantity));
            objParam[3] = new SqlParameter("@Delivery", Delivery);
            objParam[4] = new SqlParameter("@Type", Type);
            objParam[5] = new SqlParameter("@LocationId", Convert.ToInt32(LocationId));
            objParam[6] = new SqlParameter("@Userid", Userid);
            objParam[7] = new SqlParameter("@CP", CP);
            objParam[8] = new SqlParameter("@HUB", HUB);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_CheckOutMaterialCP", objParam);
            return ds;
        }

        public DataSet BranchMaterialIN( string MaterialId, string Date, string Quantity, string Delivery, string Type, string LocationId, string Userid, string HUB,string BranchCode)
        {
            SqlParameter[] objParam = new SqlParameter[9];
            objParam[0] = new SqlParameter("@MaterialId", Convert.ToInt32(MaterialId));
            objParam[1] = new SqlParameter("@Date", DL.Common.DateFormat(Date));
            objParam[2] = new SqlParameter("@Quantity", Convert.ToInt32(Quantity));
            objParam[3] = new SqlParameter("@Delivery", Delivery);
            objParam[4] = new SqlParameter("@Type", Type);
            objParam[5] = new SqlParameter("@LocationId", Convert.ToInt32(LocationId));
            objParam[6] = new SqlParameter("@Userid", Userid);
            objParam[7] = new SqlParameter("@HUB", HUB);
            objParam[8] = new SqlParameter("@Branch", BranchCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_CheckINMaterialBranch", objParam);
            return ds;
        }

        public DataSet BranchMaterialINOneShot(string Date, string Delivery, string Type, string LocationId, string Userid, string HUB, string BranchCode)
        {
            SqlParameter[] objParam = new SqlParameter[7];
         
            objParam[0] = new SqlParameter("@Date", DL.Common.DateFormat(Date));         
            objParam[1] = new SqlParameter("@Delivery", Delivery);
            objParam[2] = new SqlParameter("@Type", Type);
            objParam[3] = new SqlParameter("@LocationId", Convert.ToInt32(LocationId));
            objParam[4] = new SqlParameter("@Userid", Userid);
            objParam[5] = new SqlParameter("@HUB", HUB);
            objParam[6] = new SqlParameter("@Branch", BranchCode);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_CheckINMaterialBranchAutomate", objParam);
            return ds;
        }

            public DataSet GetCPData(string locationautoid)
        {
            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter("@LocationId", Convert.ToInt32(locationautoid));
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_GetCPData", objParam);
            return ds;
        }
        public DataSet UpdateCPData(string locationautoid, string Quantity, string Date, string AutoId, string MaterialAutoID)
        {
            SqlParameter[] objParam = new SqlParameter[5];
            objParam[0] = new SqlParameter("@LocationId", Convert.ToInt32(locationautoid));
            objParam[1] = new SqlParameter("@Quantity", Convert.ToInt32(Quantity));
            objParam[2] = new SqlParameter("@Date", DL.Common.DateFormat(Date));
            objParam[3] = new SqlParameter("@AutoId", Convert.ToInt32(AutoId));
            objParam[4] = new SqlParameter("@MaterialAutoID", Convert.ToInt32(MaterialAutoID));
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_UpdateCPData", objParam);
            return ds;
        }

        public DataSet DeleteCPData(string locationautoid,  string AutoId, string MaterialAutoID)
        {
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter("@LocationId", Convert.ToInt32(locationautoid));
            objParam[1] = new SqlParameter("@AutoId", Convert.ToInt32(AutoId));
            objParam[2] = new SqlParameter("@MaterialAutoID", Convert.ToInt32(MaterialAutoID));
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_DeleteCPData", objParam);
            return ds;
        }


        public DataSet HUBMaterialOUT( string MaterialId, string Date, string Quantity, string Delivery, string Type, string LocationId, string Userid, string HUB, string HUBName)
        {
            SqlParameter[] objParam = new SqlParameter[9];
            objParam[0] = new SqlParameter("@MaterialId", Convert.ToInt32(MaterialId));
            objParam[1] = new SqlParameter("@Date", DL.Common.DateFormat(Date));
            objParam[2] = new SqlParameter("@Quantity", Convert.ToInt32(Quantity));
            objParam[3] = new SqlParameter("@Delivery", Delivery);
            objParam[4] = new SqlParameter("@Type", Type);
            objParam[5] = new SqlParameter("@LocationId", Convert.ToInt32(LocationId));
            objParam[6] = new SqlParameter("@Userid", Userid);
            objParam[7] = new SqlParameter("@HUB", HUB);
            objParam[8] = new SqlParameter("@HUBName", HUBName);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_CheckOutMaterialHub", objParam);
            return ds;
        }

        public DataSet GetCPItemDetails()
        {
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_GetCPItemDetails");
            return ds;
        }

        public DataSet GetItemStock(string Item, string OfficeName, int LocationAutoID)
        {
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(Properties.Resources.Item, Item);
            objParam[1] = new SqlParameter(Properties.Resources.Name, OfficeName);
            objParam[2] = new SqlParameter(Properties.Resources.LocationAutoId, LocationAutoID);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_GetItemStockALL", objParam);
            return ds;
        }

        public DataSet GetHUBItemStock(string Item, string OfficeName, int LocationAutoID)
        {
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(Properties.Resources.Item, Item);
            objParam[1] = new SqlParameter(Properties.Resources.Name, OfficeName);
            objParam[2] = new SqlParameter(Properties.Resources.LocationAutoId, LocationAutoID);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_GetItemStockALLHUB", objParam);
            return ds; 
        }

        public DataSet GetItemStockLedger(string Item, string OfficeName, int LocationAutoID)
        {
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(Properties.Resources.Item, Item);
            objParam[1] = new SqlParameter(Properties.Resources.Name, OfficeName);
            objParam[2] = new SqlParameter(Properties.Resources.LocationAutoId, LocationAutoID);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_GetItemStock", objParam);
            return ds;
        }

        public DataSet GetBranchItemStock(string BranchCode, int LocationAutoID)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter(Properties.Resources.LocationAutoId, LocationAutoID);
            objParam[1] = new SqlParameter(Properties.Resources.BranchCode, BranchCode);
        
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_GetEquipmentDetailAPSWeb", objParam);
            return ds;
        }


        public DataSet GetItemStockLedgerHub(string Item, string OfficeName, int LocationAutoID)
        {
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(Properties.Resources.Item, Item);
            objParam[1] = new SqlParameter(Properties.Resources.Name, OfficeName);
            objParam[2] = new SqlParameter(Properties.Resources.LocationAutoId, LocationAutoID);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_GetHubItemStock", objParam);
            return ds;
        }

        public DataSet GetHubName()
        {
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_GetHubDetails");
            return ds;
        }

        public DataSet GetHubNameWithID()
        {
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_GetHubDetailsWithID");
            return ds;
        }
        public DataSet GetDistrictDetails(string HubId)
        {
            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter("@HubId", Convert.ToInt32(HubId));
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_GetDistrictDetails", objParam);
            return ds;
        }

        public DataSet GetHubFromBranch(string BranchId)
        {
            SqlParameter[] objParam = new SqlParameter[1];
            objParam[0] = new SqlParameter("@BranchId", Convert.ToInt32(BranchId));
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_GetHubFromBranch", objParam);
            return ds;
        }

        public DataSet GetBranchDetails(string HubId, string District, string city)
        {
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter("@HubId", Convert.ToInt32(HubId));
            objParam[1] = new SqlParameter("@District", District);
            objParam[2] = new SqlParameter("@City", city);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_GetBranchDetailsAPSInventory", objParam);
            return ds;
        }


            public DataSet GetCityDetails(string HubId, string District)
        {
            SqlParameter[] objParam = new SqlParameter[2];
            objParam[0] = new SqlParameter("@HubId", Convert.ToInt32(HubId));
            objParam[1] = new SqlParameter("@District", District);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_GetCityDetails", objParam);
            return ds;
        }

            public DataSet GetBranchName()
        {
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_GetBranchDetails");
            return ds;
        }
        public DataSet MaxMonthlyData(int BaseLocationAutoID, int Year, int Month)
        {
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, BaseLocationAutoID);
            objParam[1] = new SqlParameter(DL.Properties.Resources.Year, Year);
            objParam[2] = new SqlParameter(DL.Properties.Resources.Month, Month);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_GetMaxMonthlyReport", objParam);
            return ds;
        }

        public DataSet MaxMonthlyDataNew(int BaseLocationAutoID, int Year, int Month)
        {
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, BaseLocationAutoID);
            objParam[1] = new SqlParameter(DL.Properties.Resources.Year, Year);
            objParam[2] = new SqlParameter(DL.Properties.Resources.Month, Month);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_GetMaxMonthlyReportNew", objParam);
            return ds;
        }

        public DataSet MaxMonthlyDataNew1(int BaseLocationAutoID, int Year, int Month)
        {
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, BaseLocationAutoID);
            objParam[1] = new SqlParameter(DL.Properties.Resources.Year, Year);
            objParam[2] = new SqlParameter(DL.Properties.Resources.Month, Month);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_GetMaxMonthlyReportNew1", objParam);
            return ds;
        }
        public DataSet AttendanceMusterDataWithShift(int BaseLocationAutoID, int Year, int Month)
        {
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, BaseLocationAutoID);
            objParam[1] = new SqlParameter(DL.Properties.Resources.Year, Year);
            objParam[2] = new SqlParameter(DL.Properties.Resources.Month, Month);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_GetAttendanceMusterWithShift", objParam);
            return ds;
        }

        public DataSet AttendanceMusterDataWithShiftBCFD(int BaseLocationAutoID, int Year, int Month)
        {
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, BaseLocationAutoID);
            objParam[1] = new SqlParameter(DL.Properties.Resources.Year, Year);
            objParam[2] = new SqlParameter(DL.Properties.Resources.Month, Month);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_GetAttendanceMusterWithShiftBCFD", objParam);
            return ds;
        }

        public DataSet AttendanceMusterDataWithShiftPP(int BaseLocationAutoID, int Year, int Month)
        {
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, BaseLocationAutoID);
            objParam[1] = new SqlParameter(DL.Properties.Resources.Year, Year);
            objParam[2] = new SqlParameter(DL.Properties.Resources.Month, Month);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_GetAttendanceMusterWithShiftPPP", objParam);
            return ds;
        }
        public DataSet AttendanceMusterDataWithShiftPPWithTimings(int BaseLocationAutoID, int Year, int Month)
        {
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, BaseLocationAutoID);
            objParam[1] = new SqlParameter(DL.Properties.Resources.Year, Year);
            objParam[2] = new SqlParameter(DL.Properties.Resources.Month, Month);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_GetAttendanceMusterWithShiftPPWithTimingsNew", objParam);
            return ds;
        }
        public DataSet ConsolidateChecklistReport(int BaseLocationAutoID, int Year, int Month)
        {
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, BaseLocationAutoID);
            objParam[1] = new SqlParameter(DL.Properties.Resources.Year, Year);
            objParam[2] = new SqlParameter(DL.Properties.Resources.Month, Month);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_GetTATAAIAMaterialReport", objParam);
            return ds;
        }

        public DataSet MaxMaterialReport(int BaseLocationAutoID, int Year, int Month)
        {
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, BaseLocationAutoID);
            objParam[1] = new SqlParameter(DL.Properties.Resources.Year, Year);
            objParam[2] = new SqlParameter(DL.Properties.Resources.Month, Month);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_GetMaxMaterialReport", objParam);
            return ds;
        }

        public DataSet APSReportNew(int BaseLocationAutoID, int Year, int Month,string Branch)
        {
            SqlParameter[] objParam = new SqlParameter[4];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, BaseLocationAutoID);
            objParam[1] = new SqlParameter(DL.Properties.Resources.Year, Year);
            objParam[2] = new SqlParameter(DL.Properties.Resources.Month, Month);
            objParam[3] = new SqlParameter(DL.Properties.Resources.Branch, Branch);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_GetAttendanceReportAPNew", objParam);
            return ds;
        }

        public DataSet MusterDetails(string BaseLocationAutoID, string Year, string Month, string EmpCode)
        {
            SqlParameter[] objParam = new SqlParameter[4];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, BaseLocationAutoID);
            objParam[1] = new SqlParameter(DL.Properties.Resources.Year, Year);
            objParam[2] = new SqlParameter(DL.Properties.Resources.Month, Month);
            objParam[3] = new SqlParameter(DL.Properties.Resources.Emp, EmpCode);
            // DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_GetAttendanceMuster_MagnumTower", objParam);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_GetMusterDetails", objParam);
            return ds;
        }

        public DataSet AttendanceMusterDataNew(int p1, int p2, int p3)
        {
            SqlParameter[] objParam = new SqlParameter[3];
            objParam[0] = new SqlParameter(DL.Properties.Resources.LocationAutoId, p1);
            objParam[1] = new SqlParameter(DL.Properties.Resources.Year, p2);
            objParam[2] = new SqlParameter(DL.Properties.Resources.Month, p3);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "udp_GetAttendanceMuster_NewMuster", objParam);
            return ds;
        }
    }
}
