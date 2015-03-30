using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using dsProductsTableAdapters;

namespace Pharma.BMD.BLL
{
    [System.ComponentModel.DataObject]
    public class ProductsBLL : MasterClass
    {
        int? RowsCount;

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public dsProducts.dtProductsDataTable SelectProducts(int startRowIndex, int maximumRows, bool ShowAll)
        {
            daProducts da = new daProducts();
            dsProducts.dtProductsDataTable dt;
            RowsCount = 0;
            dt = da.GetData(ShowAll, startRowIndex, ref RowsCount);
            da.Dispose();
            return dt;
        }

        public int GetCertainPageByID(int ProductID, bool ShowAll)
        {
            daProducts da = new daProducts();
            int PageNo = Convert.ToInt32(da.GetCertainProductPage(ShowAll, ProductID, "-1"));
            da.Dispose();
            return PageNo;
        }

        public int GetCertainPageByName(string ProductName, bool ShowAll)
        {
            daProducts da = new daProducts();
            int PageNo = Convert.ToInt32(da.GetCertainProductPage(ShowAll, -1, ProductName));
            da.Dispose();
            return PageNo;
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public int MaxRowCount(int startRowIndex, int maximumRows, bool ShowAll)
        {
            //daProducts da = new daProducts();
            //int Count = Convert.ToInt32(da.GetProductsCount(ShowAll));
            //return RowsCount.Value;
            int result = 0;
            if (RowsCount != null)
                result = RowsCount.Value;
            return result;

        }

        public dsProducts.dtFilteredProductsDataTable SelectFilteredProducts(string productName, int formID)
        {
            daFilteredProducts da = new daFilteredProducts();
            return da.GetFilteredProducts(productName, formID, "", "", false);
        }

        public dsProducts.dtProductsChangesDataTable SelectProductsChanges(int OldID, int NewID)
        {
            daProductsChanges da = new daProductsChanges();
            dsProducts.dtProductsChangesDataTable dt = da.GetData(OldID, NewID);
            da.Dispose();
            return dt;
        }

        public int AddProduct(string ProductName, int ProductFormID, string Composition, string Indication, int Dosage, int PackSize, decimal Price, int DosageUnit, int PackSizeUnit, int CID, out int NewID)
        {
            int result = 0;
            NewID = 0;
            try
            {
                daProducts da = new daProducts();
                if (CurrentUserInfo.UserRole != UsersRoles.User)
                {
                    // SuperAdmin or Admin Manager // Direct Insert in database
                    result = int.Parse(da.Insert(ProductName, ProductFormID, Composition, Indication, Dosage, PackSize, Price, DosageUnit, PackSizeUnit, CID).ToString());
                    if (result > 0)
                    {
                        NewID = result;
                        result = 1;
                    }
                    else
                        result = 0;
                }
                else
                {
                    // Request to Add new Product in database
                    result = int.Parse(da.RequestInsert(ProductName, ProductFormID, Composition, Indication, Dosage, PackSize, Price, DosageUnit, PackSizeUnit, CID, CurrentUserInfo.EmpID).ToString());
                    if (result > 0)
                    {
                        NewID = result;
                        result = 2;
                    }
                    else
                        result = 0;
                }
            }
            catch { }

            return result;
        }
        public static int ResponseAddProduct(int TransID, int TransStatus, int EmpID)
        {
            try
            {
                daProducts da = new daProducts();
                return int.Parse(da.ResponseInsert(TransID, TransStatus, EmpID).ToString());
            }
            catch
            {
                return 3;
            }
        }

        public int UpdateProduct(int ProductID, string ProductName, int ProductFormID, string Composition, string Indication, int Dosage, int PackSize, decimal Price, int DosageUnit, int PackSizeUnit, int CID, out string Msg)
        {
            Msg = "";
            int result = 0;
            try
            {
                daProducts da = new daProducts();
                if (CurrentUserInfo.UserRole != UsersRoles.User)
                {
                    // SuperAdmin or Admin or SuperVisor // Direct Insert in database
                    result = int.Parse(da.Update(ProductID, ProductName, ProductFormID, Composition, Indication, Dosage, PackSize, Price, DosageUnit, PackSizeUnit, CID).ToString()) > 0 ? 1 : 0;
                }
                else
                {
                    dsTransactionLogTableAdapters.daTransactionslog daT = new dsTransactionLogTableAdapters.daTransactionslog();
                    int Existance = Convert.ToInt32(daT.IsUpdatedTransactionExist(ProductID, "BMD_Products"));
                    da.Dispose();
                    if (Existance == 0)
                        // Request to Update Product in database
                        result = int.Parse(da.RequestUpdate(ProductID, ProductName, ProductFormID, Composition, Indication, Dosage, PackSize, Price, DosageUnit, PackSizeUnit, CID, CurrentUserInfo.EmpID).ToString()) > 0 ? 2 : 0;
                    else
                        Msg = msgErrMoreUpdateRequest;
                }
            }
            catch (Exception Exp) { Msg = Exp.Message; }

            return result;
        }
        public static int ResponseUpdateProduct(int TransID, int TransStatus, int EmpID)
        {
            try
            {
                daProducts da = new daProducts();
                return int.Parse(da.ResponseUpdate(TransID, TransStatus, EmpID).ToString());
            }
            catch
            {
                return 3;
            }
        }

        public int DeleteProduct(int ProductID)
        {
            int result = 0;
            try
            {
                daProducts da = new daProducts();
                if (CurrentUserInfo.UserRole == UsersRoles.SuperAdmin)
                {
                    // SuperAdmin or Admin or SuperVisor// Direct Insert in database
                    result = int.Parse(da.Delete(ProductID).ToString()) > 0 ? 1 : 0;
                }
                else
                {
                    // Request to Add new Product in database
                    result = int.Parse(da.RequestDelete(ProductID, CurrentUserInfo.EmpID).ToString()) > 0 ? 2 : 0;
                }
            }
            catch { }

            return result;
        }
        public static int ResponseDelete(int TransID, int TransStatus, int EmpID) 
        {
            try
            {
                daProducts da = new daProducts();
                return int.Parse(da.ResponseDelete(TransID, TransStatus, EmpID).ToString());
            }
            catch
            {
                return 3;
            }
        }
        
        public dsProducts.dtProductsNamesDataTable GetProductsList()
        {
            daProductsNames da = new daProductsNames();
            return da.GetData(false);
            // No Need To Filter Products "Removed as the client require all his user to access all products//
            //if (!CurrentUserInfo.IsUserRank)
            //{
            //    // SuperAdmin
            //    return da.GetData(false);
            //}
            //else
            //{
            //    if (CurrentUserInfo.UserRole == UsersRoles.SuperUser)
            //    {
            //        // Admin
            //        return da.GetDataByAdmin(CurrentUserInfo.UserName, false);
            //    }
            //    else
            //    {
            //        // Normal User
            //        return da.GetDataByUser(CurrentUserInfo.UserName, false);
            //    }
            //}
        }
        public int GetProductIDByName(string productName)
        {
            daProducts da = new daProducts();
            int productID = 0;
            dsProducts.dtProductsDataTable dtProduct = da.GetProductIDByName(productName, false);
            if (dtProduct.Rows.Count != 0)
                productID = Convert.ToInt32(dtProduct.Rows[0]["ProductID"]);
            return productID;
        }

        public bool IsProductNameDuplicated(string ProductName, int ProductForm)
        {
            daProducts da = new daProducts();
            int Existance = Convert.ToInt32(da.IsProductExistInForm(ProductName, ProductForm));
            da.Dispose();
            return Existance > 0;
        }

        public bool IsUpdatedProductNameDuplicated(int ProductID, string ProductName, int ProductForm)
        {
            daProducts da = new daProducts();
            int Existance = Convert.ToInt32(da.IsUpdatedProductExistInForm(ProductID, ProductName, ProductForm));
            da.Dispose();
            return Existance > 0;
        }
    }
}