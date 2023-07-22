using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    [CLSCompliantAttribute(false)]
    public class AssetManagement

    {

        #region Functions Related to AssetManufacturer

        /// <summary>
        /// To get All the data from AssetManufacturer
        /// </summary>
        /// <returns>Dataset Message with ManufacturerName,ManufacturerEmail,ManufacturerPhone,ManufacturerAddress,</returns>
        public DataSet AssetManufacturerGetRecords(string CompanyCode)
        {
            DL.AssetManagement objdlAssetManagement = new DL.AssetManagement();
            DataSet ds = objdlAssetManagement.AssetManufacturerGetRecords(CompanyCode);
            return ds;

        }

        /// <summary>
        /// To Insert the data of AssetManufacturer
        /// </summary>
        /// <param name="ManufacturerName">ManufacturerName</param>
        /// <param name="ManufacturerEmail">ManufacturerEmail</param>
        /// <param name="ManufacturerPhone">ManufacturerPhone</param>
        /// <param name="ManufacturerAddress">ManufacturerAddress</param>
        /// <param name="modifiedBy">modifiedBy</param>
        /// <returns>Dataset Message String</returns>
        public DataSet AssetManufacturerAddNew(string ManufacturerName, string ManufacturerEmail, string ManufacturerPhone, string ManufacturerAddress, string modifiedBy,string CompanyCode)
        {
            DL.AssetManagement objdlAssetManagement = new DL.AssetManagement();
            DataSet addStatus = objdlAssetManagement.AssetManufacturerAddNew(ManufacturerName, ManufacturerEmail, ManufacturerPhone, ManufacturerAddress, modifiedBy,CompanyCode);
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
        /// <returns>Dataset Message String</returns>
        public DataSet AssetManufacturerUpdate(string ManufacturerName, string ManufacturerEmail, string ManufacturerPhone, string ManufacturerAddress, string modifiedBy,string CompanyCode)
        {
            DL.AssetManagement objdlAssetManagement = new DL.AssetManagement();
            DataSet updateStatus = objdlAssetManagement.AssetManufacturerUpdateRecords(ManufacturerName, ManufacturerEmail, ManufacturerPhone, ManufacturerAddress, modifiedBy, CompanyCode);
            return updateStatus;
        }


        /// <summary>
        /// To Delete data from AssetManufacturer
        /// </summary>
        /// <param name="ManufacturerAutoID">ManufacturerAutoID</param>
        /// <param name="ManufacturerName">ManufacturerName</param>
        /// <returns>Dataset Message String</returns>
        public DataSet AssetManufacturerDelete(string ManufacturerAutoID,string CompanyCode)
        {
            DL.AssetManagement objdlAssetManagement = new DL.AssetManagement();
            DataSet deleteStatus = objdlAssetManagement.AssetManufacturerDelete(ManufacturerAutoID, CompanyCode);
            return deleteStatus;
        }

        #endregion

        # region function related to Asset Category
        public DataSet AssetCategoryInsert(int ID, string CategoryName, string ModifiedBy,string CompanyCode)
        {
            DL.AssetManagement objAssetMgmt = new DL.AssetManagement();
            DataSet ds = objAssetMgmt.AssetCategoryInsert(ID, CategoryName, ModifiedBy, CompanyCode);
            return ds;
        }
        public DataSet AssetCategoryDelete(int ID,string CompanyCode)
        {
            DL.AssetManagement objAssetMgmt = new DL.AssetManagement();
            DataSet ds = objAssetMgmt.AssetCategoryDelete(ID,CompanyCode);
            return ds;
        }

        public DataSet insertempmapping(string baseLocationAutoID, string empcode, string clientcode)
        {
            DL.AssetManagement objAssetMgmt = new DL.AssetManagement();
            DataSet ds = objAssetMgmt.insertempmapping(baseLocationAutoID, empcode, clientcode);
            return ds;
        }

        public DataSet AssetCategoryDetailGet(string CompanyCode)
        {
            DL.AssetManagement objAssetMgmt = new DL.AssetManagement();
            DataSet ds = objAssetMgmt.AssetCategoryDetailGet(CompanyCode);
            return ds;
        }
        #endregion

        # region Function related to Asset Sub Category
        public DataSet AssetSubCategoryDetailGet(int ID,string CompanyCode)
        {
            DL.AssetManagement objAssetMgmt = new DL.AssetManagement();
            DataSet ds = objAssetMgmt.AssetSubCategoryDetailGet(ID,CompanyCode);
            return ds;
        }
        public DataSet AssetSubCategoryInsert(int ID, int CategoryId, string SubCategoryName, string ModifiedBy,string CompanyCode)
        {
            DL.AssetManagement objAssetMgmt = new DL.AssetManagement();
            DataSet ds = objAssetMgmt.AssetSubCategoryInsert(ID, CategoryId, SubCategoryName, ModifiedBy, CompanyCode);
            return ds;
        }
        public DataSet AssetSubCategoryDelete(int ID,string CompanyCode)
        {
            DL.AssetManagement objAssetMgmt = new DL.AssetManagement();
            DataSet ds = objAssetMgmt.AssetSubCategoryDelete(ID, CompanyCode);
            return ds;
        }
        #endregion

        #region Function related to Asset Master
        public DataSet AssetMasterDetailGet(string CompanyCode)
        {
            DL.AssetManagement objAssetMgmt = new DL.AssetManagement();
            DataSet ds = objAssetMgmt.AssetMasterDetailGet(CompanyCode);
            return ds;
        }

        public DataSet UpdateLatLong(string baseLocationAutoID, string Clientcode, string Lat, string Longitude)
        {
            DL.AssetManagement objAssetMgmt = new DL.AssetManagement();
            DataSet ds = objAssetMgmt.UpdateLatLong(baseLocationAutoID,Clientcode,Lat, Longitude);
            return ds;
        }

        public DataSet AssetMasterDetailGetSMCL(int LocationAutoID)
        {
            DL.AssetManagement objAssetMgmt = new DL.AssetManagement();
            DataSet ds = objAssetMgmt.AssetMasterDetailGetSMCL(LocationAutoID);
            return ds;
        }

        public DataSet GetFeedbackSMCL(int LocationAutoID)
        {
            DL.AssetManagement objAssetMgmt = new DL.AssetManagement();
            DataSet ds = objAssetMgmt.GetFeedbackSMCL(LocationAutoID);
            return ds;
        }

        public DataSet GetbreakFixSMCL(int LocationAutoID)
        {
            DL.AssetManagement objAssetMgmt = new DL.AssetManagement();
            DataSet ds = objAssetMgmt.GetbreakFixSMCL(LocationAutoID);
            return ds;
        }

        public DataSet GetCMSSMCL(int LocationAutoID, string FromDate, string ToDate, string EmployeeNumber)
        {
            DL.AssetManagement objAssetMgmt = new DL.AssetManagement();
            DataSet ds = objAssetMgmt.GetCMSSMCL(LocationAutoID, FromDate,ToDate,EmployeeNumber);
            return ds;
        }

        public DataSet ScheduleEmpSMCL(int AutoID, int LocationAutoID, string EmpNo)
        {
            DL.AssetManagement objAssetMgmt = new DL.AssetManagement();
            DataSet ds = objAssetMgmt.ScheduleEmpSMCL(AutoID,LocationAutoID, EmpNo);
            return ds;
        }

        public DataSet ScheduleEmpSMCLCMS(int AutoID, int LocationAutoID, string EmpNo)
        {
            DL.AssetManagement objAssetMgmt = new DL.AssetManagement();
            DataSet ds = objAssetMgmt.ScheduleEmpSMCLCMS(AutoID, LocationAutoID, EmpNo);
            return ds;
        }



        public DataSet GetEmpSMCL(int LocationAutoID)
        {
            DL.AssetManagement objAssetMgmt = new DL.AssetManagement();
            DataSet ds = objAssetMgmt.GetEmpSMCL(LocationAutoID);
            return ds;
        }
        public DataSet GetEmpCMSSMCL(int LocationAutoID)
        {
            DL.AssetManagement objAssetMgmt = new DL.AssetManagement();
            DataSet ds = objAssetMgmt.GetEmpCMSSMCL(LocationAutoID);
            return ds;
        }

        public DataSet GetBreakfixDetailsSMCL(int AutoID, int LocationAutoID)
        {
            DL.AssetManagement objAssetMgmt = new DL.AssetManagement();
            DataSet ds = objAssetMgmt.GetBreakfixDetailsSMCL(AutoID,LocationAutoID);
            return ds;
        }


        public DataSet AssetManufactureDetailGet(string CompanyCode)
        {
            DL.AssetManagement objAssetMgmt = new DL.AssetManagement();
            DataSet ds = objAssetMgmt.AssetManufactureDetailGet(CompanyCode);
            return ds;
        }
        public DataSet AssetMasterDetailForUpdate(string AssetId,string companyCode)
        {
            DL.AssetManagement objAssetMgmt = new DL.AssetManagement();
            DataSet ds = objAssetMgmt.AssetMasterDetailForUpdate(AssetId,companyCode);
            return ds;
        }
        public DataSet AssetMasterDetailInsert(string AssetCode, string AssetName, string AssetCategory, string AssetSubCategory, string AssetManufacture, string ModelNo, string ModelName, string SerialNo, string Description, string AssetOwner, string TagID, string Remarks, string IsActive, string Inactivewef, string Activewef, string status, string Condition, string ImageUrl, string MgmtGuideline, string ModifiedBy,string CompanyCode)
        {
            DL.AssetManagement objAssetMgmt = new DL.AssetManagement();
            DataSet ds = objAssetMgmt.AssetMasterDetailInsert(AssetCode, AssetName, AssetCategory, AssetSubCategory, AssetManufacture, ModelNo, ModelName, SerialNo, Description, AssetOwner, TagID, Remarks, IsActive, Inactivewef, Activewef, status, Condition, ImageUrl, MgmtGuideline, ModifiedBy,CompanyCode);
            return ds;
        }
        public DataSet AssetMasterImageUpload(string AssetId, string ImageUrl, string ModifiedBy,string CompanyCode)
        {
            DL.AssetManagement objAssetMgmt = new DL.AssetManagement();
            DataSet ds = objAssetMgmt.AssetMasterImageUpload(AssetId, ImageUrl, ModifiedBy,CompanyCode);
            return ds;
        }
        public DataSet AssetMasterDetailUpdate(int AssetAutoId, string AssetCode, string AssetName, string AssetCategory, string AssetSubCategory, string AssetManufacture, string ModelNo, string ModelName, string SerialNo, string Description, string AssetOwner, string TagID, string Remarks, string IsActive, string Inactivewef, string Activewef, string status, string Condition, string ImageUrl, string MgmtGuideline, string ModifiedBy,string CompanyCode)
        {
            DL.AssetManagement objAssetMgmt = new DL.AssetManagement();
            DataSet ds = objAssetMgmt.AssetMasterDetailUpdate(AssetAutoId, AssetCode, AssetName, AssetCategory, AssetSubCategory, AssetManufacture, ModelNo, ModelName, SerialNo, Description, AssetOwner, TagID, Remarks, IsActive, Inactivewef, Activewef, status, Condition, ImageUrl, MgmtGuideline, ModifiedBy,CompanyCode);
            return ds;
        }
        #endregion

        #region Function related to Asset Lease
        public DataSet AssetLeaseDetailGet(string AssetId,string CompanyCode)
        {
            DL.AssetManagement objAssetMgmt = new DL.AssetManagement();
            DataSet ds = objAssetMgmt.AssetLeaseDetailGet(AssetId,CompanyCode);
            return ds;
        }
        public DataSet AssetLeaseInsert(int LeaseId, string assetName, string firmName, string firmEmail, string firmPhone, string firmAddress, string typeOfLease, string leaseStartDate, string leaseEndDate, decimal leaseAmount, string remarks, string ModifiedBy,string CompanyCode)
        {
            DL.AssetManagement objAssetMgmt = new DL.AssetManagement();
            DataSet ds = objAssetMgmt.AssetLeaseInsert(LeaseId, assetName, firmName, firmEmail, firmPhone, firmAddress, typeOfLease, leaseStartDate, leaseEndDate, leaseAmount, remarks, ModifiedBy,CompanyCode);
            return ds;
        }
        public DataSet AssetLeaseDelete(int LeaseId, string DocType,string CompanyCode)
        {
            DL.AssetManagement objAssetMgmt = new DL.AssetManagement();
            DataSet ds = objAssetMgmt.AssetLeaseDelete(LeaseId, DocType,CompanyCode);
            return ds;
        }
        public DataSet AssetLeaseUpdate(int LeaseId, string assetName, string firmName, string firmEmail, string firmPhone, string firmAddress, string typeOfLease, string leaseStartDate, string leaseEndDate, decimal leaseAmount, string remarks, string ModifiedBy,string CompanyCode)
        {
            DL.AssetManagement objAssetMgmt = new DL.AssetManagement();
            DataSet ds = objAssetMgmt.AssetLeaseUpdate(LeaseId, assetName, firmName, firmEmail, firmPhone, firmAddress, typeOfLease, leaseStartDate, leaseEndDate, leaseAmount, remarks, ModifiedBy,CompanyCode);
            return ds;
        }
        #endregion Function related to Asset Lease

        #region Function Related To AssetInsurance
        public DataSet AssetInsuranceGetRecords(string AssetId,string CompanyCode)
        {
            DL.AssetManagement objdlAssetManagement = new DL.AssetManagement();

            DataSet ds = objdlAssetManagement.AssetInsuranceGetRecords(AssetId,CompanyCode);
            return ds;

        }
        public DataSet AssetInsuranceAddNew(string AssetName, string PolicyNo, decimal SumInsured, string InsuranceCompanyName, string Email, string Phone, string InsurancePeriodFrom, string InsurancePeriodTo, string modifiedBy,string CompanyCode)
        {
            DL.AssetManagement objdlAssetManagement = new DL.AssetManagement();
            DataSet addStatus = objdlAssetManagement.AssetInsuranceAddNew(AssetName, PolicyNo, SumInsured, InsuranceCompanyName, Email, Phone, InsurancePeriodFrom, InsurancePeriodTo, modifiedBy, CompanyCode);
            return addStatus;
        }
        public DataSet AssetInsuranceUpdate(int AssetInsuranceAutoId, decimal SumInsured, string InsuranceCompanyName, string Email, string PhoneNo, string InsurancePeriodFrom, string InsurancePeriodTo, string modifiedBy,string CompanyCode)
        {
            DL.AssetManagement objdlAssetManagement = new DL.AssetManagement();
            DataSet updateStatus = objdlAssetManagement.AssetInsuranceUpdate(AssetInsuranceAutoId, SumInsured, InsuranceCompanyName, Email, PhoneNo, InsurancePeriodFrom, InsurancePeriodTo, modifiedBy,CompanyCode);
            return updateStatus;
        }
        public DataSet AssetInsuranceDelete(int AssetInsuranceAutoId, string DocType,string CompanyCode)
        {
            DL.AssetManagement objdlMasterManagement = new DL.AssetManagement();
            DataSet deleteStatus = objdlMasterManagement.AssetInsuranceDelete(AssetInsuranceAutoId, DocType,CompanyCode);
            return deleteStatus;
        }
        #endregion Function Related To AssetInsurance

        #region Function Related To AssetGurantee
        public DataSet AssetGuranteeGetRecords(string AssetId,string CompanyCode)
        {
            DL.AssetManagement objdlAssetManagement = new DL.AssetManagement();

            DataSet ds = objdlAssetManagement.AssetGuranteeGetRecords(AssetId,CompanyCode);
            return ds;
        }
        public DataSet AssetGuranteeAddNew(string AssetName, string GuranteeExpDate, string modifiedBy,string CompanyCode)
        {
            DL.AssetManagement objdlAssetManagement = new DL.AssetManagement();
            DataSet addStatus = objdlAssetManagement.AssetGuranteeAddNew(AssetName, GuranteeExpDate, modifiedBy,CompanyCode);
            return addStatus;
        }
        public DataSet AssetGuranteeUpdate(int AssetGuarantyAutoId, string GuranteeExpDate, string modifiedBy,string CompanyCode)
        {
            DL.AssetManagement objdlAssetManagement = new DL.AssetManagement();
            DataSet updateStatus = objdlAssetManagement.AssetGuranteeUpdate(AssetGuarantyAutoId, GuranteeExpDate, modifiedBy,CompanyCode);
            return updateStatus;
        }
        public DataSet AssetGuranteeDelete(int AssetGuarantyAutoId, string DocType,string CompanyCode)
        {
            DL.AssetManagement objdlAssetManagement = new DL.AssetManagement();
            DataSet deleteStatus = objdlAssetManagement.AssetGuranteeDelete(AssetGuarantyAutoId, DocType,CompanyCode);
            return deleteStatus;
        }
        #endregion Function Related To AssetGurantee

        #region Function Related To AssetWarrenty
        public DataSet AssetWarrentyGetRecords(string AssetId,string CompanyCode)
        {
            DL.AssetManagement objdlAssetManagement = new DL.AssetManagement();
            DataSet ds = objdlAssetManagement.AssetWarrentyGetRecords(AssetId,CompanyCode);
            return ds;
        }
        public DataSet AssetWarrentyAddNew(string AssetName, string WarrentyExpDate, string modifiedBy,string CompanyCode)
        {
            DL.AssetManagement objdlAssetManagement = new DL.AssetManagement();
            DataSet addStatus = objdlAssetManagement.AssetWarrentyAddNew(AssetName, WarrentyExpDate, modifiedBy,CompanyCode);
            return addStatus;
        }
        public DataSet AssetWarrentyUpdate(int AssetWarrentyAutoId, string WarrentyExpDate, string modifiedBy,string CompanyCode)
        {
            DL.AssetManagement objdlAssetManagement = new DL.AssetManagement();
            DataSet updateStatus = objdlAssetManagement.AssetWarrentyUpdate(AssetWarrentyAutoId, WarrentyExpDate, modifiedBy,CompanyCode);
            return updateStatus;
        }
        public DataSet AssetWarrentyDelete(int AssetWarrentyAutoId, string DocType,string CompanyCode)
        {
            DL.AssetManagement objdlAssetManagement = new DL.AssetManagement();
            DataSet deleteStatus = objdlAssetManagement.AssetWarrentyDelete(AssetWarrentyAutoId, DocType,CompanyCode);
            return deleteStatus;
        }
        #endregion Function Related To AssetWarrenty

        #region Function related to Asset Purchase
        public DataSet AssetLeaseDeleteAfterPurchaseInsert(int AssetId)
        {
            DL.AssetManagement objAssetMgmt = new DL.AssetManagement();
            DataSet ds = objAssetMgmt.AssetLeaseDeleteAfterPurchaseInsert(AssetId);
            return ds;
        }
        public DataSet AssetPurchaseDetail(string AssetId,string CompanyCode)
        {
            DL.AssetManagement objAssetMgmt = new DL.AssetManagement();
            DataSet ds = objAssetMgmt.AssetPurchaseDetail(AssetId,CompanyCode);
            return ds;
        }
        public DataSet AssetPurchaseDetailUpdate(int AssetAutoId, string CompanyName, string OrderNo, string OrderDate, decimal Price, string SupplierName, string SupplierEmail, string SupplierPhone, string SupplierAddress, string Remarks, string ImageUrl, string ModifiedBy,string CompanyCode)
        {
            DL.AssetManagement objAssetMgmt = new DL.AssetManagement();
            DataSet ds = objAssetMgmt.AssetPurchaseDetailUpdate(AssetAutoId, CompanyName, OrderNo, OrderDate, Price, SupplierName, SupplierEmail, SupplierPhone, SupplierAddress, Remarks, ImageUrl, ModifiedBy,CompanyCode);
            return ds;
        }
        public DataSet AssetPurchaseDetailInsert(int AssetAutoId, string CompanyName, string OrderNo, string OrderDate, decimal Price, string SupplierName, string SupplierEmail, string SupplierPhone, string SupplierAddress, string Remarks, string ImageUrl, string ModifiedBy,string CompanyCode)
        {
            DL.AssetManagement objAssetMgmt = new DL.AssetManagement();
            DataSet ds = objAssetMgmt.AssetPurchaseDetailInsert(AssetAutoId, CompanyName, OrderNo, OrderDate, Price, SupplierName, SupplierEmail, SupplierPhone, SupplierAddress, Remarks, ImageUrl, ModifiedBy,CompanyCode);
            return ds;
        }
        #endregion Function related to Asset Purchase

        #region function related to Document Upload
        public DataSet AssetDocumentInsert(string category, int AssetAutoId, string DocDesc, string DocPath, string ModifiedBy,string CompanyCode)
        {
            DL.AssetManagement objAssetMgmt = new DL.AssetManagement();
            DataSet ds = objAssetMgmt.AssetDocumentInsert(category, AssetAutoId, DocDesc, DocPath, ModifiedBy,CompanyCode);
            return ds;
        }
        public DataSet AssetDocumentDetail(int AutoId, string Category,string CompanyCode)
        {
            DL.AssetManagement objAssetMgmt = new DL.AssetManagement();
            DataSet ds = objAssetMgmt.AssetDocumentDetail(AutoId, Category,CompanyCode);
            return ds;
        }
        public DataSet AssetDocumentDelete(int ID,string CompanyCode)
        {
            DL.AssetManagement objAssetMgmt = new DL.AssetManagement();
            DataSet ds = objAssetMgmt.AssetDocumentDelete(ID,CompanyCode);
            return ds;
        }
        public DataSet GetAssetDocumentsDetail(int AutoId, String Doctype,string CompanyCode)
        {
            DL.AssetManagement objAssetMgmt = new DL.AssetManagement();
            DataSet ds = objAssetMgmt.GetAssetDocumentsDetail(AutoId, Doctype,CompanyCode);
            return ds;
        }

        #endregion function related to Document Upload

        #region Functions Related to AssetPart
        public DataSet AssetManufacturerNameDetailGet(string CompanyCode)
        {
            DL.AssetManagement objAssetMgmt = new DL.AssetManagement();
            DataSet ds = objAssetMgmt.AssetManufacturerNameDetailGet(CompanyCode);
            return ds;
        }
        public DataSet AssetNameDetailGet(int AssetSubCategory, int AssetManufacturer,string CompanyCode)
        {
            DL.AssetManagement objAssetMgmt = new DL.AssetManagement();
            DataSet ds = objAssetMgmt.AssetNameDetailGet(AssetSubCategory, AssetManufacturer,CompanyCode);
            return ds;
        }
        public DataSet AssetModelNoGet(int SubCategoryAutoId, int ManufacturerAutoId, string AssetName,string CompanyCode)
        {
            DL.AssetManagement objAssetMgmt = new DL.AssetManagement();
            DataSet ds = objAssetMgmt.AssetModelNoGet(SubCategoryAutoId, ManufacturerAutoId, AssetName, CompanyCode);
            return ds;
        }
        public DataSet AssetPartGetRecords(string CompanyCode)
        {
            DL.AssetManagement objdlAssetManagement = new DL.AssetManagement();

            DataSet ds = objdlAssetManagement.AssetPartGetRecords(CompanyCode);
            return ds;

        }
        public DataSet AssetPartAddNew(int AssetCategory, int AssetSubCategory, int ManufacturerName, string AssetName, string ModelNo, string AssetPartNo, string AssetPartName, int AssetPartQuantity, string modifiedBy,string CompanyCode)
        {
            DL.AssetManagement objdlMasterManagement = new DL.AssetManagement();
            DataSet addStatus = objdlMasterManagement.AssetPartAddNew(AssetCategory, AssetSubCategory, ManufacturerName, AssetName, ModelNo, AssetPartNo, AssetPartName, AssetPartQuantity, modifiedBy,CompanyCode);
            return addStatus;
        }
        public DataSet AssetPartUpdate(int AssetPartsAutoId, string AssetPartNo, string AssetPartName, int AssetPartQuantity, string modifiedBy,string CompanyCode)
        {
            DL.AssetManagement objdlMasterManagement = new DL.AssetManagement();
            DataSet addStatus = objdlMasterManagement.AssetPartUpdate(AssetPartsAutoId, AssetPartNo, AssetPartName, AssetPartQuantity, modifiedBy,CompanyCode);
            return addStatus;
        }
        public DataSet AssetPartDelete(int AssetPartsAutoId,string CompanyCode)
        {
            DL.AssetManagement objdlMasterManagement = new DL.AssetManagement();
            DataSet deleteStatus = objdlMasterManagement.AssetPartDelete(AssetPartsAutoId,CompanyCode);
            return deleteStatus;
        }
        #endregion Functions Related to AssetPart

        #region Function Related to AssetServiceType
        public DataSet AssetServiceTypeGetRecords(string CompanyCode)
        {
            DL.AssetManagement objdlAssetManagement = new DL.AssetManagement();
            DataSet ds = objdlAssetManagement.AssetServiceTypeGetRecords(CompanyCode);
            return ds;
        }
        public DataSet AssetServiceTypeAddNew(string AssetName, string AssetServiceTypename, string modifiedBy,string CompanyCode)
        {
            DL.AssetManagement objdlAssetManagement = new DL.AssetManagement();
            DataSet addStatus = objdlAssetManagement.AssetServiceTypeAddNew(AssetName, AssetServiceTypename, modifiedBy,CompanyCode);
            return addStatus;
        }

        public DataSet AssetServiceTypeUpdate(int AssetServiceTypeAutoId, string AssetName, string AssetServiceTypename, string modifiedBy,string CompanyCode)
        {
            DL.AssetManagement objdlAssetManagement = new DL.AssetManagement();
            DataSet addStatus = objdlAssetManagement.AssetServiceTypeUpdate(AssetServiceTypeAutoId, AssetName, AssetServiceTypename, modifiedBy,CompanyCode);
            return addStatus;
        }
        public DataSet AssetServiceForDelete(int AssetServiceTypeAutoId,string CompanyCode)
        {
            DL.AssetManagement objdlAssetManagement = new DL.AssetManagement();
            DataSet deleteStatus = objdlAssetManagement.AssetServiceForDelete(AssetServiceTypeAutoId,CompanyCode);
            return deleteStatus;
        }
        public DataSet AssetNameDetailForServiceType(string CompanyCode)
        {
            DL.AssetManagement objAssetMgmt = new DL.AssetManagement();
            DataSet ds = objAssetMgmt.AssetNameDetailForServiceType(CompanyCode);
            return ds;
        }
        #endregion

        #region Function related to Asset Service Checklist
        public DataSet AssetServiceTypeGet(int AssetId,string CompanyCode)
        {
            DL.AssetManagement objAssetMgmt = new DL.AssetManagement();
            DataSet ds = objAssetMgmt.AssetServiceTypeGet(AssetId,CompanyCode);
            return ds;
        }
        public DataSet AssetChecklistNameInsert(int AssetId, int ServiceAutoId, string ChecklistName, string ModifiedBy,string CompanyCode)
        {
            DL.AssetManagement objAssetMgmt = new DL.AssetManagement();
            DataSet ds = objAssetMgmt.AssetChecklistNameInsert(AssetId, ServiceAutoId, ChecklistName, ModifiedBy,CompanyCode);
            return ds;

        }
        public DataSet GetChecklistName(int AssetId, string ServiceAutoId,string CompanyCode)
        {
            DL.AssetManagement objAssetMgmt = new DL.AssetManagement();
            DataSet ds = objAssetMgmt.GetChecklistName(AssetId, ServiceAutoId,CompanyCode);
            return ds;
        }
        public DataSet GetChecklistNameItems(int ChecklistId,string CompanyCode)
        {
            DL.AssetManagement objAssetMgmt = new DL.AssetManagement();
            DataSet ds = objAssetMgmt.GetChecklistNameItems(ChecklistId,CompanyCode);
            return ds;
        }
        public DataSet ChecklistItemNameInsert(int ChecklistId, string ItemName, string ModifiedBy,string CompanyCode)
        {
            DL.AssetManagement objAssetMgmt = new DL.AssetManagement();
            DataSet ds = objAssetMgmt.ChecklistItemNameInsert(ChecklistId, ItemName, ModifiedBy,CompanyCode);
            return ds;
        }
        public DataSet ChecklistItemNameUpdate(int ChecklistId, string ItemName, string ModifiedBy,string CompanyCode)
        {
            DL.AssetManagement objAssetMgmt = new DL.AssetManagement();
            DataSet ds = objAssetMgmt.ChecklistItemNameUpdate(ChecklistId, ItemName, ModifiedBy,CompanyCode);
            return ds;
        }
        public DataSet ChecklistItemNameDelete(int ChecklistId,string CompanyCode)
        {
            DL.AssetManagement objAssetMgmt = new DL.AssetManagement();
            DataSet ds = objAssetMgmt.ChecklistItemNameDelete(ChecklistId,CompanyCode);
            return ds;
        }
        #endregion

        #region Function related to Asset Note
        public DataSet AssetNoteDetailGet(string AssetId,string CompanyCode)
        {
            DL.AssetManagement objAssetMgmt = new DL.AssetManagement();
            DataSet ds = objAssetMgmt.AssetNoteDetailGet(AssetId,CompanyCode);
            return ds;
        }
        public DataSet AssetNoteInsert(string AssetId, string Towhom, string NoteType, string Note, string ModifiedBy,string CompanyCode)
        {
            DL.AssetManagement objAssetMgmt = new DL.AssetManagement();
            DataSet ds = objAssetMgmt.AssetNoteInsert(AssetId, Towhom, NoteType, Note, ModifiedBy,CompanyCode);
            return ds;
        }
        public DataSet AssetNoteUpdate(string AssetNoteAutoId, string AssetId, string Towhom, string NoteType, string Note, string ModifiedBy,string CompanyCode)
        {
            DL.AssetManagement objAssetMgmt = new DL.AssetManagement();
            DataSet ds = objAssetMgmt.AssetNoteUpdate(AssetNoteAutoId, AssetId, Towhom, NoteType, Note, ModifiedBy,CompanyCode);
            return ds;
        }
        public DataSet AssetNoteDelete(string AssetNoteAutoId,string CompanyCode)
        {
            DL.AssetManagement objAssetMgmt = new DL.AssetManagement();
            DataSet ds = objAssetMgmt.AssetNoteDelete(AssetNoteAutoId,CompanyCode);
            return ds;
        }
        #endregion

        #region Function related to Asset AMC
        public DataSet AssetAMCDetailGet(string AssetId,string CompanyCode)
        {
            DL.AssetManagement objAssetMgmt = new DL.AssetManagement();
            DataSet ds = objAssetMgmt.AssetAMCDetailGet(AssetId,CompanyCode);
            return ds;
        }
        public DataSet AssetAMCInsert(string assetName, string firmName, string firmEmail, string firmPhone, string firmAddress, string AMCType, string StartDate, string EndDate, decimal Amount, string Terms, string ModifiedBy,string CompanyCode)
        {
            DL.AssetManagement objAssetMgmt = new DL.AssetManagement();
            DataSet ds = objAssetMgmt.AssetAMCInsert(assetName, firmName, firmEmail, firmPhone, firmAddress, AMCType, StartDate, EndDate, Amount, Terms, ModifiedBy,CompanyCode);
            return ds;
        }
        public DataSet AssetAMCDelete(string AMCAutoId, string DocType,string CompanyCode)
        {
            DL.AssetManagement objAssetMgmt = new DL.AssetManagement();
            DataSet ds = objAssetMgmt.AssetAMCDelete(AMCAutoId, DocType,CompanyCode);
            return ds;
        }
        public DataSet AssetAMCUpdate(string AMCAutoId, string assetName, string firmName, string firmEmail, string firmPhone, string firmAddress, string AMCType, string StartDate, string EndDate, decimal Amount, string Terms, string ModifiedBy,string CompanyCode)
        {
            DL.AssetManagement objAssetMgmt = new DL.AssetManagement();
            DataSet ds = objAssetMgmt.AssetAMCUpdate(AMCAutoId, assetName, firmName, firmEmail, firmPhone, firmAddress, AMCType, StartDate, EndDate, Amount, Terms, ModifiedBy,CompanyCode);
            return ds;
        }
        #endregion

        #region Function related to Asset Client Mapping
        public DataSet AssetClientMappingInsert(int AssetAutoId, int LocationAutoId, string ClientCode, string AsmtId, int PostAutoId, string Remarks, string Usage,string ModifiedBy)
        {
            DL.AssetManagement objAssetMgmt = new DL.AssetManagement();
            DataSet ds = objAssetMgmt.AssetClientMappingInsert(AssetAutoId, LocationAutoId, ClientCode, AsmtId, PostAutoId, Remarks, Usage, ModifiedBy);
            return ds;
        }
        public DataSet AssetClientMappingGetRecords(string AssetId)
        {
            DL.AssetManagement objdlAssetManagement = new DL.AssetManagement();
            DataSet ds = objdlAssetManagement.AssetClientMappingGetRecords(AssetId);
            return ds;
        }
        public DataSet AssetClientMappingUpdate(int AssetAutoId, int LocationAutoId, string ClientCode, string AsmtId, int PostAutoId, string Remarks, string Usage, string ModifiedBy)
        {
            DL.AssetManagement objAssetMgmt = new DL.AssetManagement();
            DataSet ds = objAssetMgmt.AssetClientMappingUpdate(AssetAutoId, LocationAutoId, ClientCode, AsmtId, PostAutoId, Remarks, Usage, ModifiedBy);
            return ds;
        }
        public DataSet AssetClientMappingDelete(int AssetAutoId, int LocationAutoId)
        {
            DL.AssetManagement objAssetMgmt = new DL.AssetManagement();
            DataSet ds = objAssetMgmt.AssetClientMappingDelete(AssetAutoId, LocationAutoId);
            return ds;
        }
        #endregion

        #region Function related to Ticket Master
        public DataSet GetAllTickets(string LocationAutoId,string Status,string TicketNo,string UserId,string Date,string ToDate)
        {
            DL.AssetManagement objAssetMgmt = new DL.AssetManagement();
            DataSet ds = objAssetMgmt.GetAllTickets(LocationAutoId, Status, TicketNo, UserId, Date, ToDate);
            return ds;
        }
        public DataSet TicketDetail(string TicketNo,string LocationAutoId)
        {
            DL.AssetManagement objAssetMgmt = new DL.AssetManagement();
            DataSet ds = objAssetMgmt.TicketDetail(TicketNo, LocationAutoId);
            return ds;
        }
        public DataSet UpdateTicketStatus(string TicketNo,string Status,string LocationAutoId,string ModifiedBy)
        {
            DL.AssetManagement objAssetMgmt = new DL.AssetManagement();
            DataSet ds = objAssetMgmt.UpdateTicketStatus(TicketNo, Status, LocationAutoId, ModifiedBy);
            return ds;
        }
        #endregion
        #region Function related to Task Master
        public DataSet GetClientCode(string LocationAutoID)
        {
            DL.AssetManagement objAssetMgmt = new DL.AssetManagement();
            DataSet ds = objAssetMgmt.GetClientCode(LocationAutoID);
            return ds;
        }
        public DataSet GetAsmtId(string ClientCode, string LocationAutoID)
        {
            DL.AssetManagement objAssetMgmt = new DL.AssetManagement();
            DataSet ds = objAssetMgmt.GetAsmtId(ClientCode, LocationAutoID);
            return ds;
        }
        public DataSet GetPostCode(string ClientCode, string AsmtId, string LocationAutoID)
        {
            DL.AssetManagement objAssetMgmt = new DL.AssetManagement();
            DataSet ds = objAssetMgmt.GetPostCode(ClientCode, AsmtId, LocationAutoID);
            return ds;
        }
        public DataSet GetPerformerSiteDetails(string ClientCode, string AsmtId, string PostId, string LocationAutoID,string Date)
        {
            DL.AssetManagement objAssetMgmt = new DL.AssetManagement();
            DataSet ds = objAssetMgmt.GetPerformerSiteDetails(ClientCode, AsmtId, PostId, LocationAutoID, Date);
            return ds;
        }
        public DataSet GetDailyTaskDetail(string AutoId, string AsmtId, string LocationAutoID, string Date, string AssetAutoID)
        {
            DL.AssetManagement objAssetMgmt = new DL.AssetManagement();
            DataSet ds = objAssetMgmt.GetDailyTaskDetail(AutoId, AsmtId, LocationAutoID, Date, AssetAutoID);
            return ds;
        }
        public DataSet GetDailyTaskDetailUnSchedulled(string AutoId, string AsmtId, string LocationAutoID)
        {
            DL.AssetManagement objAssetMgmt = new DL.AssetManagement();
            DataSet ds = objAssetMgmt.GetDailyTaskDetailUnSchedulled(AutoId, AsmtId, LocationAutoID);
            return ds;
        }
        public DataSet UpdateDailyTaskStatus(string AssetScheduleAutoId, string TaskName, string Status,string LocationAutoId,string UserId,string Date)
        {
            DL.AssetManagement objAssetMgmt = new DL.AssetManagement();
            DataSet ds = objAssetMgmt.UpdateDailyTaskStatus(AssetScheduleAutoId, TaskName, Status, LocationAutoId, UserId, Date);
            return ds;
        }
        public DataSet GetDailyTaskImage(string CheckListItem, string LocationAutoID, string Date,string FromTime,string ToTime)
        {
            DL.AssetManagement objAssetMgmt = new DL.AssetManagement();
            DataSet ds = objAssetMgmt.GetDailyTaskImage(CheckListItem, LocationAutoID, Date, FromTime, ToTime);
            return ds;
        }
        public DataSet GetEmployeeAttendence(string LocationAutoId,string Post,string Date,string EmployeeNo,string ToDate)
        {
            DL.AssetManagement objAssetMgmt = new DL.AssetManagement();
            DataSet ds = objAssetMgmt.GetEmployeeAttendence(LocationAutoId, Post, Date, EmployeeNo, ToDate);
            return ds;
        }
        #endregion

        #region Function related to Asset Client Mapping
        public DataSet AssetClientMappingInsert(int AssetAutoId, int LocationAutoId, string ClientCode, string AsmtId, int PostAutoId, string Remarks, string Usage, string ModifiedBy, string LocationTagging)
        {
            DL.AssetManagement objAssetMgmt = new DL.AssetManagement();
            DataSet ds = objAssetMgmt.AssetClientMappingInsert(AssetAutoId, LocationAutoId, ClientCode, AsmtId, PostAutoId, Remarks, Usage, ModifiedBy, LocationTagging);
            return ds;
        }

        public DataSet AssetClientMappingUpdate(int AssetAutoId, int LocationAutoId, string ClientCode, string AsmtId, int PostAutoId, string Remarks, string Usage, string ModifiedBy, string LocationTagging)
        {
            DL.AssetManagement objAssetMgmt = new DL.AssetManagement();
            DataSet ds = objAssetMgmt.AssetClientMappingUpdate(AssetAutoId, LocationAutoId, ClientCode, AsmtId, PostAutoId, Remarks, Usage, ModifiedBy, LocationTagging);
            return ds;
        }

        public DataSet GetAssetOwnerMappingNew(int LocationAutoId, int AssetAutoId)
        {
            DL.AssetManagement objAssetMgmt = new DL.AssetManagement();
            DataSet ds = objAssetMgmt.GetAssetOwnerMapping(LocationAutoId, AssetAutoId);
            return ds;
        }

        public DataSet OwnerAssetMappingInsert(int AssetId, string employeeNumber, string locationAutoId, string modifiedBy, string effectiveFrom, string EmpName, string AssetCode)
        {

            DL.AssetManagement objAssetMgmt = new DL.AssetManagement();
            DataSet ds = objAssetMgmt.OwnerAssetMappingInsert(AssetId, employeeNumber, locationAutoId, modifiedBy, effectiveFrom, EmpName, AssetCode);
            return ds;
        }

        public DataSet OwnerAssetMappingDelete(string AssetId, string employeeNumber, string locationAutoId)
        {

            DL.AssetManagement objAssetMgmt = new DL.AssetManagement();
            DataSet ds = objAssetMgmt.OwnerAssetMappingDelete(AssetId, employeeNumber, locationAutoId);
            return ds;

        }

        public DataSet OwnerAssetMappingUpdate(string AssetId, string employeeNumber, string locationAutoId, string areaInchargeAutoId, string effectiveFrom, string effectiveTo, string modifiedBy)
        {

            DL.AssetManagement objAssetMgmt = new DL.AssetManagement();
            DataSet ds = objAssetMgmt.OwnerAssetMappingUpdate(AssetId, employeeNumber, locationAutoId, areaInchargeAutoId, effectiveFrom, effectiveTo, modifiedBy);
            return ds;
        }
        public DataSet GetAllEmployeeByLocation(string employeeNumber, string employeeName, int locationAutoId)
        {

            DL.AssetManagement objAssetMgmt = new DL.AssetManagement();
            DataSet ds = objAssetMgmt.GetAllEmployeeByLocation(employeeNumber, employeeName, locationAutoId);
            return ds;

        }
        public DataSet GetPendingTasklist(string ClientCode, string AsmtId, string PostId, string LocationAutoID, string Date,string ToDate)
        {
            DL.AssetManagement objAssetMgmt = new DL.AssetManagement();
            DataSet ds = objAssetMgmt.GetPendingTasklist(ClientCode, AsmtId, PostId, LocationAutoID, Date, ToDate);
            return ds;
        }
        public DataSet GetCompletedTasklist(string ClientCode, string AsmtId, string PostId, string LocationAutoID, string Date,string ToDate,string Status)
        {
            DL.AssetManagement objAssetMgmt = new DL.AssetManagement();
            DataSet ds = objAssetMgmt.GetCompletedTasklist(ClientCode, AsmtId, PostId, LocationAutoID, Date, ToDate, Status);
            return ds;
        }
        #endregion

        #region function related to Graphical Dashboard
        public DataSet GetGraphTasklist(string ClientCode, string AsmtId, string PostId, string LocationAutoID, string Date, string ToDate, string Status)
        {
            DL.AssetManagement objAssetMgmt = new DL.AssetManagement();
            DataSet ds = objAssetMgmt.GetGraphTasklist(ClientCode, AsmtId, PostId, LocationAutoID, Date, ToDate, Status);
            return ds;
        }
        public DataSet GetGraphTasklistDetail(string ClientCode, string AsmtId, string PostId, string LocationAutoID, string Date, string Status)
        {
            DL.AssetManagement objAssetMgmt = new DL.AssetManagement();
            DataSet ds = objAssetMgmt.GetGraphTasklistDetail(ClientCode, AsmtId, PostId, LocationAutoID, Date, Status);
            return ds;
        }
        #endregion

        public DataSet GetCPItemDetails()
        {
            DL.AssetManagement objAssetMgmt = new DL.AssetManagement();
            DataSet ds = objAssetMgmt.GetCPItemDetails();
            return ds;
        }

        public DataSet GetItemStock(string Item, string OfficeName, int LocationAutoID)
        {
            DL.AssetManagement objAssetMgmt = new DL.AssetManagement();
            DataSet ds = objAssetMgmt.GetItemStock(Item, OfficeName, LocationAutoID);
            return ds;
        }
        public DataSet GetHUBItemStock(string Item, string OfficeName, int LocationAutoID)
        {
            DL.AssetManagement objAssetMgmt = new DL.AssetManagement();
            DataSet ds = objAssetMgmt.GetHUBItemStock(Item, OfficeName, LocationAutoID);
            return ds;
        }
        public DataSet GetItemStockLedger(string Item, string OfficeName, int LocationAutoID)
        {
            DL.AssetManagement objAssetMgmt = new DL.AssetManagement();
            DataSet ds = objAssetMgmt.GetItemStockLedger(Item, OfficeName, LocationAutoID);
            return ds;
        }

        public DataSet GetBranchItemStock(string BranchCode, int LocationAutoID)
        {
            DL.AssetManagement objAssetMgmt = new DL.AssetManagement();
            DataSet ds = objAssetMgmt.GetBranchItemStock(BranchCode, LocationAutoID);
            return ds;
        }
        public DataSet GetItemStockLedgerHub(string Item, string OfficeName, int LocationAutoID)
        {
            DL.AssetManagement objAssetMgmt = new DL.AssetManagement();
            DataSet ds = objAssetMgmt.GetItemStockLedgerHub(Item, OfficeName, LocationAutoID);
            return ds;
        }
        public DataSet CPMaterialIN(string CP,string MaterialId, string Date, string Quantity, string Vendor, string Type, string LocationId, string Userid)
        {
            DL.AssetManagement objAssetMgmt = new DL.AssetManagement();
            DataSet ds = objAssetMgmt.CPMaterialIN(CP,MaterialId, Date, Quantity, Vendor, Type, LocationId, Userid);
            return ds;
        }

        public DataSet HUBMaterialIN(string CP, string MaterialId, string Date, string Quantity,  string Type, string LocationId, string Userid, string HUB)
        {
            DL.AssetManagement objAssetMgmt = new DL.AssetManagement();
            DataSet ds = objAssetMgmt.HUBMaterialIN(CP, MaterialId, Date, Quantity, Type, LocationId, Userid, HUB);
            return ds;
        }
        public DataSet CPMaterialOUT(string CP, string MaterialId, string Date, string Quantity, string Delivery, string Type, string LocationId, string Userid,string HUB)
        {
            DL.AssetManagement objAssetMgmt = new DL.AssetManagement();
            DataSet ds = objAssetMgmt.CPMaterialOUT(CP, MaterialId, Date, Quantity, Delivery, Type, LocationId, Userid, HUB);
            return ds;
        }

        public DataSet BranchMaterialIN( string MaterialId, string Date, string Quantity, string Delivery, string Type, string LocationId, string Userid, string HUB, string BranchCode)
        {
            DL.AssetManagement objAssetMgmt = new DL.AssetManagement();
            DataSet ds = objAssetMgmt.BranchMaterialIN( MaterialId, Date, Quantity, Delivery, Type, LocationId, Userid, HUB, BranchCode);
            return ds;
        }

        public DataSet BranchMaterialINOneShot( string Date,  string Delivery, string Type, string LocationId, string Userid, string HUB, string BranchCode)
        {
            DL.AssetManagement objAssetMgmt = new DL.AssetManagement();
            DataSet ds = objAssetMgmt.BranchMaterialINOneShot( Date,  Delivery, Type, LocationId, Userid, HUB, BranchCode);
            return ds;
        }

        public DataSet HUBMaterialOUT( string MaterialId, string Date, string Quantity, string Delivery, string Type, string LocationId, string Userid, string HUB,string HUBName)
        {
            DL.AssetManagement objAssetMgmt = new DL.AssetManagement();
            DataSet ds = objAssetMgmt.HUBMaterialOUT( MaterialId, Date, Quantity, Delivery, Type, LocationId, Userid, HUB, HUBName);
            return ds;
        }
        public DataSet GetCPData(string locationautoid)
        {
            DL.AssetManagement objAssetMgmt = new DL.AssetManagement();
            DataSet ds = objAssetMgmt.GetCPData(locationautoid);
            return ds;
        }

        public DataSet UpdateCPData(string locationautoid,string Quantity,string Date,string AutoId,string MaterialAutoID)
        {
            DL.AssetManagement objAssetMgmt = new DL.AssetManagement();
            DataSet ds = objAssetMgmt.UpdateCPData(locationautoid, Quantity, Date, AutoId, MaterialAutoID);
            return ds;

        }

        public DataSet DeleteCPData(string locationautoid, string AutoId, string MaterialAutoID)
        {
            DL.AssetManagement objAssetMgmt = new DL.AssetManagement();
            DataSet ds = objAssetMgmt.DeleteCPData(locationautoid,  AutoId, MaterialAutoID);
            return ds;

        }

        public DataSet GetHubName()
        {
            DL.AssetManagement objAssetMgmt = new DL.AssetManagement();
            DataSet ds = objAssetMgmt.GetHubName();
            return ds;

        }

        public DataSet GetHubNameWithID()
        {
            DL.AssetManagement objAssetMgmt = new DL.AssetManagement();
            DataSet ds = objAssetMgmt.GetHubNameWithID();
            return ds;

        }

        public DataSet GetDistrictDetails(string HubId)
        {
            DL.AssetManagement objAssetMgmt = new DL.AssetManagement();
            DataSet ds = objAssetMgmt.GetDistrictDetails(HubId);
            return ds;

        }

        public DataSet GetHubFromBranch(string BranchId)
        {
            DL.AssetManagement objAssetMgmt = new DL.AssetManagement();
            DataSet ds = objAssetMgmt.GetHubFromBranch(BranchId);
            return ds;

        }

        public DataSet GetCityDetails(string HubId,string District)
        {
            DL.AssetManagement objAssetMgmt = new DL.AssetManagement();
            DataSet ds = objAssetMgmt.GetCityDetails(HubId, District);
            return ds;

        }

        public DataSet GetBranchDetails(string HubId, string District,string city)
        {
            DL.AssetManagement objAssetMgmt = new DL.AssetManagement();
            DataSet ds = objAssetMgmt.GetBranchDetails(HubId, District, city);
            return ds;

        }

        public DataSet GetBranchName()
        {
            DL.AssetManagement objAssetMgmt = new DL.AssetManagement();
            DataSet ds = objAssetMgmt.GetBranchName();
            return ds;

        }
        public DataSet GetCompletedTasklist_ShiftBasis(string ClientCode, string AsmtId, string PostId, string LocationAutoID, string Date, string ToDate, string Status, string Shift)
        {
            DL.AssetManagement objAssetMgmt = new DL.AssetManagement();
            DataSet ds = objAssetMgmt.GetCompletedTasklist_ShiftBasis(ClientCode, AsmtId, PostId, LocationAutoID, Date, ToDate, Status, Shift);
            return ds;
        }


        public DataSet ElectronicToActualAttendance(string ClientCode, string AsmtId, string Shift, string Date, string LocationId, string ModifiedBy)
        {
            DL.AssetManagement objAssetMgmt = new DL.AssetManagement();
            DataSet ds = objAssetMgmt.ElectronicToActualAttendance(ClientCode, AsmtId, Shift, Date, LocationId, ModifiedBy);
            return ds;
        }



        public DataSet ConvertToActual(string BaseLocationAutoID, string BaseUserID, string Date)
        {
            DL.AssetManagement objAssetMgmt = new DL.AssetManagement();
            DataSet ds = objAssetMgmt.ConvertToActual(BaseLocationAutoID, BaseUserID,Date);
            return ds;
        }

        public DataSet ConvertToActualWithShift(string BaseLocationAutoID, string BaseUserID, string Date)
        {
            DL.AssetManagement objAssetMgmt = new DL.AssetManagement();
            DataSet ds = objAssetMgmt.ConvertToActualWithShift(BaseLocationAutoID, BaseUserID, Date);
            return ds;
        }

        public DataSet AttendanceMusterData(int BaseLocationAutoID, int Year, int Month)
        {
            DL.AssetManagement objAssetMgmt = new DL.AssetManagement();
            DataSet ds = objAssetMgmt.AttendanceMusterData(BaseLocationAutoID, Year, Month);
            return ds;
        }

        public DataSet AttendanceMusterDataMacquarie(int BaseLocationAutoID, int Year, int Month)
        {
            DL.AssetManagement objAssetMgmt = new DL.AssetManagement();
            DataSet ds = objAssetMgmt.AttendanceMusterDataMacquarie(BaseLocationAutoID, Year, Month);
            return ds;
        }

        public DataSet MaxMonthlyData(int BaseLocationAutoID, int Year, int Month)
        {
            DL.AssetManagement objAssetMgmt = new DL.AssetManagement();
            DataSet ds = objAssetMgmt.MaxMonthlyData(BaseLocationAutoID, Year, Month);
            return ds;
        }

        public DataSet MaxMonthlyDataNew(int BaseLocationAutoID, int Year, int Month)
        {
            DL.AssetManagement objAssetMgmt = new DL.AssetManagement();
            DataSet ds = objAssetMgmt.MaxMonthlyDataNew(BaseLocationAutoID, Year, Month);
            return ds;
        }

        public DataSet MaxMonthlyDataNew1(int BaseLocationAutoID, int Year, int Month)
        {
            DL.AssetManagement objAssetMgmt = new DL.AssetManagement();
            DataSet ds = objAssetMgmt.MaxMonthlyDataNew1(BaseLocationAutoID, Year, Month);
            return ds;
        }


        public DataSet AttendanceMusterDataWithShift(int BaseLocationAutoID, int Year, int Month)
        {
            DL.AssetManagement objAssetMgmt = new DL.AssetManagement();
            DataSet ds = objAssetMgmt.AttendanceMusterDataWithShift(BaseLocationAutoID, Year, Month);
            return ds;
        }

        public DataSet AttendanceMusterDataWithShiftBCFD(int BaseLocationAutoID, int Year, int Month)
        {
            DL.AssetManagement objAssetMgmt = new DL.AssetManagement();
            DataSet ds = objAssetMgmt.AttendanceMusterDataWithShiftBCFD(BaseLocationAutoID, Year, Month);
            return ds;
        }

        public DataSet AttendanceMusterDataWithShiftPP(int BaseLocationAutoID, int Year, int Month)
        {
            DL.AssetManagement objAssetMgmt = new DL.AssetManagement();
            DataSet ds = objAssetMgmt.AttendanceMusterDataWithShiftPP(BaseLocationAutoID, Year, Month);
            return ds;
        }
        public DataSet AttendanceMusterDataWithShiftPPWithTimings(int BaseLocationAutoID, int Year, int Month)
        {
            DL.AssetManagement objAssetMgmt = new DL.AssetManagement();
            DataSet ds = objAssetMgmt.AttendanceMusterDataWithShiftPPWithTimings(BaseLocationAutoID, Year, Month);
            return ds;
        }
        public DataSet ConsolidateChecklistReport(int BaseLocationAutoID, int Year, int Month)
        {
            DL.AssetManagement objAssetMgmt = new DL.AssetManagement();
            DataSet ds = objAssetMgmt.ConsolidateChecklistReport(BaseLocationAutoID, Year, Month);
            return ds;
        }

        public DataSet MaxMaterialReport(int BaseLocationAutoID, int Year, int Month)
        {
            DL.AssetManagement objAssetMgmt = new DL.AssetManagement();
            DataSet ds = objAssetMgmt.MaxMaterialReport(BaseLocationAutoID, Year, Month);
            return ds;
        }

        public DataSet APSReportNew(int BaseLocationAutoID, int Year, int Month,string Branch)
        {
            DL.AssetManagement objAssetMgmt = new DL.AssetManagement();
            DataSet ds = objAssetMgmt.APSReportNew(BaseLocationAutoID, Year, Month, Branch);
            return ds;
        }

        public DataSet MusterDetails(string BaseLocationAutoID, string Year, string Month, string EmpCode)
        {
            DL.AssetManagement objAssetMgmt = new DL.AssetManagement();
            DataSet ds = objAssetMgmt.MusterDetails(BaseLocationAutoID, Year, Month, EmpCode);
            return ds;
        }

        public DataSet AttendanceMusterDataNew(int p1, int p2, int p3)
        {
            DL.AssetManagement objAssetMgmt = new DL.AssetManagement();
            DataSet ds = objAssetMgmt.AttendanceMusterDataNew(p1, p2, p3);
            return ds;
        }
    }
}
