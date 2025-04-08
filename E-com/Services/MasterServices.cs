using System.ComponentModel.Design;
using System.Data;
using System.Reflection;
using E_com.Data;
using E_com.Model;
using E_com.VeiwModel;
using ExcelDataReader;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using OfficeOpenXml.Export.HtmlExport.StyleCollectors.StyleContracts;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace E_com.Services
{
    public interface IMasterServices

    {
        object CreateCompany(AllCompany company);
        object UpdateJobs(AllJob jobs);
        object GetAllJobs();
        object CreateAllJobs(AllJob jobs);
        object GetAllCompanies(string masterstable, string filterByName);
        object GetJobDetails(int id, bool isEmployeeId);
        //object AddUpdateJobs(JobAddUpdateModel addUpdateModel);
        object GetJobCurrentEmployerid(int employeeid);
        object GetJob();
        //object GetJobEducation();
        object AddUpdateJobEducation(JobEducation add);
        //object GetJobCurrentEmployee();
        object AddUpdateJobCurrentEmployee(JobCurrentemp add);
        object GetSkill();
        object GetCoursecategory();
        object GetEducationKey();
        object GetCurrentemployee();
        object AddUpdateCoursecategory(Coursecate add);
        object AddUpdateSkill(Skill add);
        object AddUpdateCompanyProduct(Add add);
        //object UpdateCompanyProduct(CompanyProducts update);
        object GetCompanyProduct();
        object DeleteCompanyProduct(int productid);

        object GetCompanyServices();
        object DeleteCompanyServices(int serviceid);

        object AddUpdateCompanyTools(Add add);
        object GetCompanyTools();
        object DeleteCompanyTools(int toolid);
        object AddUpdateCompanyServices(Add add);
        object AddUpdateCompany(Companyi add);
        //object GetCompanyToolRelation();
        object GetCompany();
        object AddUpdateCompanyToolRelation(CompanyToolModel add);
        object GetToolRelation();
        object GetToolRelationid(int toolid);
        object AddCompanyService(CompanyServiceModel add);
        object GetCompanyServiceByid(int serviceid);
        object AddComapnyProduct(CompanyProductRequestModel add);

        object GetCompanyProductByid(int productid);
        object AddDummyAccount(AccountRequest add);
        object GetDummyAccount();

       
        object DeleteClassification(int classificationid);
        object AddUpdateClassification(Classficationrequestcs addnew);
        object GetClassificationDetails(LocationsViewModel request);
        object AddUpdateSubClassification(SubClassficationrequestcs addnew);
        object GetSubClassification(string FilterByName);
        object DeleteSubClassification(int Subclassificationid);
        object AddUpdateSuperClassification(SuperClassficationrequestcs addnew);
        object GetSuperClassification(string FilterByName);
        object DeleteSuperClassification(int classificationid);
        object AddUpdateDomains(Domainsreq addnew);
        object GetDomains(string FilterByName);
        object DeleteDomains(int classificationid);
        object AddUpdateIndustries(Industriesreq addnew);
        object GetIndustries(string FilterByName);
        object DeleteIndustries(int Industriesid);
        object AddUpdateSubIndustries(SubIndustriesreq addnew);
        object DeleteSubIndustries(int SubIndustriesid);
        object AddUpdateProducts(Productreq addnew);
        object DeleteProducts(int Productsid);
        object AddUpdateIndustryGroup(Industryreq addnew);
        object DeleteIndustryGroup(int Industryid);
        object AddUpdateService(Servicereq addnew);
        object DeleteService(int Serviceid);
        object AddUpdateProcess(Processreq addnew);
        object DeleteProcess(int Processid);
        object AddUpdateToolandTechnologies(techreq addnew);
        object DeleteToolTechnologies(int tooltechid);
        object AddUpdateFunctionalAreas(functionalreq addnew);
        object DeleteFunctionalAreas(int functionalareaid);
        object AddUpdateSubFunctional(subfuncreq addnew);
        object DeleteSubFunctionalAreas(int subfunctionalareaid);
        object AddUpdateSuperFunctional(supfunreq addnew);
        object DeleteSuperFunctionalAreas(int superfunctionalareaid);
        object AddCompanyIndustryClassRelation(IndustryClassRelation add);
        object AddClassSubClassRelation(ClassificationSubclassificationRelation add);
        object AddSupclassSuperclassRelation(SubClassificationSuperClasiificationRelation add);
        object DeleteSupclassSuperclassRelation(int id);
        object DeleteIndustryClassRelation(int id);
         object DeleteClassSubClassRelation(int id);
         object GetIndustryClassRelation();
        object AddUpdateComapnyProcessRelation(CompanyProcess add);
        object GetCompanyProcess();
        object DeleteCompanyProcess(int id);
        object AddUpdateComapnyToolandtech(ComapnyTooltech add);
        object GetCompanyToolandTech();
        object DeleteCompanyTollandTech(int id);
        object AddUpdateJob(Jobs addnew);
        //object Getjobid(int jobid);
        object DeleteJob(int jobid);
        object DeleteFunctionalsubfunctional(int id);
        object AddUpdateFunctionalSubfunctional(FunctionalSubFunctional add);
        object GetFunctionalSubfunctional();
        object AddUpdateSubFunctionalSuperfunctional(SubfunctionalSuperfunctional add);
        object GetSubFunctionalSuperfunctional();
        object DeleteSubFunctionalsuperfunctional(int id);
        object AddUpdateFunctionalJob(FunctionalJob add);
        object GetFunctionalJobrelational();
        object DeleteFunctionalJob(int id);
        Task<object> ImportClassification(importdatanew MapedField);
        Task<object> UploadAllMastersExcelSheetAsync(UploadExcelSheetViewModel ReqExcelFile);
        Task<object> ImportSubClassification(importdatanew MapedField);
        Task<object> ImportSuperClassification(importdatanew MapedField);
        Task<object> ImportDomains(importdatanew MapedField);
        Task<object> ImportIndustry(importdatanew MapedField);
        Task<object> ImportSubIndustry(importdatanew MapedField);
        Task<object> ImportProducts(importdatanew MapedField);
        Task<object> ImportIndustryGroups(importdatanew MapedField);
        Task<object> ImportServicess(importdatanew MapedField);
        Task<object> ImportProcess(importdatanew MapedField);
        Task<object> ImportToolendTechnologies(importdatanew MapedField);
        Task<object> ImportFunctionalAreas(importdatanew MapedField);
        Task<object> ImportSubFunctionalAreas(importdatanew MapedField);
        Task<object> ImportSuperFunctionalAreas(importdatanew MapedField);
        object AddUpdateCurrentEmployee(Currentemp add);
        object DeleteCurrentEmployee(int employeeid);
        object AddUpdateEducationkey(Educationkey add);
        object AddUpdateCompanyDomain(CompanyDomain add);
        object GetCompanyDomain();

        //object Export();
        //object GetIndustryClassificationrelation();
        //object GetCompanyProductRelation();
        //object AddUser(Adds add);
    }
    public class MasterServices : IMasterServices
    {
        private readonly AppDbContext _appDbContext;
        FinalreturnModel finalreturnModel = new FinalreturnModel();
        private string searchLetter;

        public MasterServices(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public object AddUpdateCompanyProduct(Add add)
        {
            try
            {
                if (add.UserId == 0)
                {
                    finalreturnModel.Message = "id is not found";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }

                if (add.Name == null)
                {
                    finalreturnModel.Message = "company name is equired";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }
                if (add.Id != 0)
                {
                    var userId = add.Id;
                    var IsExist = _appDbContext.CompanyProducts.Where(x => x.Id == userId).FirstOrDefault();
                    if (IsExist != null)
                    {
                        IsExist.Name = add.Name;
                        IsExist.Description = add.Description;
                        IsExist.ModifiedBy = add.UserId;
                        //IsExist.CreatedAt = DateTime.Now;
                        IsExist.ModifiedAt = DateTime.Now;

                        _appDbContext.SaveChanges();

                        finalreturnModel.Message = "update successfully";
                        finalreturnModel.Success = true;
                        return finalreturnModel;
                    }
                    else
                    {
                        finalreturnModel.Message = "Id not found";
                        finalreturnModel.Success = false;
                        return finalreturnModel;
                    }

                }
                else
                {
                    var Exist = _appDbContext.CompanyProducts.Where(x => x.Name == add.Name).FirstOrDefault();
                    if (add.UserId == 0)
                    {
                        finalreturnModel.Message = "id is not found";
                        finalreturnModel.Success = false;
                        return finalreturnModel;
                    }
                    if (Exist == null)
                    {
                        CompanyProducts newGrade = new CompanyProducts();
                        newGrade.Name = add.Name;
                        newGrade.Description = add.Description;
                        newGrade.CreatedBy = add.UserId;
                        newGrade.CreatedAt = DateTime.Now;
                        newGrade.ModifiedAt = DateTime.Now;
                        _appDbContext.CompanyProducts.Add(newGrade);
                        _appDbContext.SaveChanges();

                        finalreturnModel.Message = " add successfully";
                        finalreturnModel.Success = true;
                        return finalreturnModel;
                    }
                    else
                    {
                        finalreturnModel.Message = "allready exist";
                        finalreturnModel.Success = false;
                        return finalreturnModel;
                    }
                }
            }
            catch (System.Exception ex)
            {
                finalreturnModel.Message = ex.Message;
                if (ex.InnerException != null)
                    finalreturnModel.Message = finalreturnModel.Message + "\n" + ex.InnerException.Message.ToString();

                finalreturnModel.Success = false;
                return finalreturnModel;
            }
        }



        public object GetCompanyProduct()
        {
            var product = (from e in _appDbContext.CompanyProducts
                           join u in _appDbContext.Users on e.CreatedBy equals u.UserId into deptGroup
                           from u in deptGroup.DefaultIfEmpty()
                           join um in _appDbContext.Users on e.ModifiedBy equals um.UserId into deptmGroup
                           from um in deptmGroup.DefaultIfEmpty()
                           select new
                           {
                               e.Id,
                               e.Name,
                               e.Description,
                               //e.CreatedBy,
                               //e.CreatedAt,
                               //e.ModifiedBy,
                               //e.ModifiedAt,
                               //e.IsDeleted,
                               //CreatedById = e.CreatedBy,
                               CreatedByName = u.UserName,
                               ModifiedByName = um.UserName,
                               e.ModifiedAt,

                               //Users = u != null ? u.USerName: null
                           }).ToList();
            var data = product.AsQueryable();
            var datanew = data.OrderByDescending(x => x.ModifiedAt).ToList();
            finalreturnModel.Success = true;
            return (datanew);
        }


        public object DeleteCompanyProduct(int productid)
        {
            try
            {
                if (productid == 0)
                {
                    finalreturnModel.Message = "id is required";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }
                var Remove = _appDbContext.CompanyProducts.Where(X => X.Id == productid).FirstOrDefault();
                if (Remove != null)
                {
                    _appDbContext.Remove(Remove);
                    _appDbContext.SaveChanges();
                    finalreturnModel.Success = true;
                    return finalreturnModel;
                }
                else
                {
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }


            }
            catch (System.Exception ex)
            {
                finalreturnModel.Message = ex.Message;
                if (ex.InnerException != null)
                    finalreturnModel.Message = finalreturnModel.Message + "\n" + ex.InnerException.Message.ToString();

                finalreturnModel.Success = false;
                return finalreturnModel;
            }
        }



        public object AddUpdateCompanyServices(Add add)
        {
            try
            {
                if (add.UserId == 0)
                {
                    finalreturnModel.Message = "id is not found";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }

                if (add.Name == null)
                {
                    finalreturnModel.Message = "company name is equired";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }
                if (add.Id != 0)
                {
                    var userId = add.Id;
                    var IsExist = _appDbContext.ComapanyServices.Where(x => x.Id == userId).FirstOrDefault();
                    if (IsExist != null)
                    {
                        IsExist.Name = add.Name;
                        IsExist.Description = add.Description;
                        IsExist.ModifiedBy = add.UserId;
                        //IsExist.CreatedAt = DateTime.Now;
                        IsExist.ModifiedAt = DateTime.Now;

                        _appDbContext.SaveChanges();

                        finalreturnModel.Message = "update successfully";
                        finalreturnModel.Success = true;
                        return finalreturnModel;
                    }
                    else
                    {
                        finalreturnModel.Message = "Id not found";
                        finalreturnModel.Success = false;
                        return finalreturnModel;
                    }

                }
                else
                {
                    var Exist = _appDbContext.ComapanyServices.Where(x => x.Name == add.Name).FirstOrDefault();
                    if (add.UserId == 0)
                    {
                        finalreturnModel.Message = "id is not found";
                        finalreturnModel.Success = false;
                        return finalreturnModel;
                    }
                    if (Exist == null)
                    {
                        ComapanyServices newGrade = new ComapanyServices();
                        newGrade.Name = add.Name;
                        newGrade.Description = add.Description;
                        newGrade.CreatedBy = add.UserId;
                        newGrade.CreatedAt = DateTime.Now;
                        newGrade.ModifiedAt = DateTime.Now;
                        _appDbContext.ComapanyServices.Add(newGrade);
                        _appDbContext.SaveChanges();

                        finalreturnModel.Message = " add successfully";
                        finalreturnModel.Success = true;
                        return finalreturnModel;
                    }
                    else
                    {
                        finalreturnModel.Message = "allready exist";
                        finalreturnModel.Success = false;
                        return finalreturnModel;
                    }
                }
            }
            catch (System.Exception ex)
            {
                finalreturnModel.Message = ex.Message;
                if (ex.InnerException != null)
                    finalreturnModel.Message = finalreturnModel.Message + "\n" + ex.InnerException.Message.ToString();

                finalreturnModel.Success = false;
                return finalreturnModel;
            }
        }

        public object GetCompanyServices()
        {
            var product = (from e in _appDbContext.ComapanyServices
                           join u in _appDbContext.Users on e.CreatedBy equals u.UserId into deptGroup
                           from u in deptGroup.DefaultIfEmpty()
                           join um in _appDbContext.Users on e.ModifiedBy equals um.UserId into deptmGroup
                           from um in deptmGroup.DefaultIfEmpty()
                           select new
                           {
                               e.Id,
                               e.Name,
                               e.Description,
                               ModifiedByName = um.UserName,
                               CreatedByName = u.UserName,
                               e.ModifiedAt,
                               //Users = u != null ? u.USerName: null
                           }).ToList();
            var data = product.AsQueryable();
            var datanew = data.OrderByDescending(x => x.ModifiedAt).ToList();
            finalreturnModel.Success = true;
            return (datanew);
        }

        public object DeleteCompanyServices(int serviceid)
        {
            try
            {
                if (serviceid == 0)
                {
                    finalreturnModel.Message = "id is required";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }
                var Remove = _appDbContext.ComapanyServices.Where(X => X.Id == serviceid).FirstOrDefault();
                if (Remove != null)
                {
                    _appDbContext.Remove(Remove);
                    _appDbContext.SaveChanges();
                    finalreturnModel.Success = true;
                    return finalreturnModel;
                }
                else
                {
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }


            }
            catch (System.Exception ex)
            {
                finalreturnModel.Message = ex.Message;
                if (ex.InnerException != null)
                    finalreturnModel.Message = finalreturnModel.Message + "\n" + ex.InnerException.Message.ToString();

                finalreturnModel.Success = false;
                return finalreturnModel;
            }
        }


        public object AddUpdateCompanyTools(Add add)
        {
            try
            {
                if (add.UserId == 0)
                {
                    finalreturnModel.Message = "id is not found";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }
                if (add.Name == null)
                {
                    finalreturnModel.Message = "company name is equired";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }
                if (add.Id != 0)
                {
                    var userId = add.Id;
                    var IsExist = _appDbContext.CompanyTools.Where(x => x.Id == userId).FirstOrDefault();
                    if (IsExist != null)
                    {
                        IsExist.Name = add.Name;
                        IsExist.Description = add.Description;
                        // IsExist.CreatedBy = add.CreatedBy;
                        //IsExist.CreatedAt = DateTime.Now;
                        IsExist.ModifiedBy = add.UserId;
                        IsExist.ModifiedAt = DateTime.Now;

                        _appDbContext.SaveChanges();

                        finalreturnModel.Message = "update successfully";
                        finalreturnModel.Success = true;
                        return finalreturnModel;
                    }
                    else
                    {
                        finalreturnModel.Message = "Id not found";
                        finalreturnModel.Success = false;
                        return finalreturnModel;
                    }

                }
                else
                {
                    var Exist = _appDbContext.CompanyTools.Where(x => x.Name == add.Name).FirstOrDefault();
                    if (add.UserId == 0)
                    {
                        finalreturnModel.Message = "id is not found";
                        finalreturnModel.Success = false;
                        return finalreturnModel;
                    }
                    if (Exist == null)
                    {
                        CompanyTools newGrade = new CompanyTools();
                        newGrade.Name = add.Name;
                        newGrade.Description = add.Description;
                        newGrade.CreatedBy = add.UserId;
                        newGrade.CreatedAt = DateTime.Now;
                        newGrade.ModifiedAt = DateTime.Now;

                        _appDbContext.CompanyTools.Add(newGrade);
                        _appDbContext.SaveChanges();

                        finalreturnModel.Message = " add successfully";
                        finalreturnModel.Success = true;
                        return finalreturnModel;
                    }
                    else
                    {
                        finalreturnModel.Message = "allready exist";
                        finalreturnModel.Success = false;
                        return finalreturnModel;
                    }
                }
            }
            catch (System.Exception ex)
            {
                finalreturnModel.Message = ex.Message;
                if (ex.InnerException != null)
                    finalreturnModel.Message = finalreturnModel.Message + "\n" + ex.InnerException.Message.ToString();

                finalreturnModel.Success = false;
                return finalreturnModel;
            }
        }

        public object GetCompanyTools()
        {
            var product = (from e in _appDbContext.CompanyTools
                           join u in _appDbContext.Users on e.CreatedBy equals u.UserId into deptGroup
                           from u in deptGroup.DefaultIfEmpty()
                           join um in _appDbContext.Users on e.ModifiedBy equals um.UserId into deptmGroup
                           from um in deptmGroup.DefaultIfEmpty()
                           select new
                           {
                               e.Id,
                               e.Name,
                               e.Description,
                               ModifiedByName = um.UserName,
                               CreatedByName = u.UserName,
                               e.ModifiedAt,

                               //Users = u != null ? u.USerName: null
                           }).ToList();
            var data = product.AsQueryable();
            var datanew = data.OrderByDescending(x => x.ModifiedAt).ToList();
            finalreturnModel.Success = true;
            return (datanew);
        }

        public object DeleteCompanyTools(int toolid)
        {

            try
            {
                if (toolid == 0)
                {
                    finalreturnModel.Message = "id is required";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }
                var Remove = _appDbContext.CompanyTools.Where(X => X.Id == toolid).FirstOrDefault();
                if (Remove != null)
                {
                    _appDbContext.Remove(Remove);
                    _appDbContext.SaveChanges();
                    finalreturnModel.Success = true;
                    return finalreturnModel;
                }
                else
                {
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }


            }
            catch (System.Exception ex)
            {
                finalreturnModel.Message = ex.Message;
                if (ex.InnerException != null)
                    finalreturnModel.Message = finalreturnModel.Message + "\n" + ex.InnerException.Message.ToString();

                finalreturnModel.Success = false;
                return finalreturnModel;
            }

        }

        //public object AddUser(Adds add)
        //{
        //    try
        //    {
        //        if(add.UserId == 0)
        //        {
        //            finalreturnModel.Message = "UserId is required";
        //            finalreturnModel.Success = false;
        //            return finalreturnModel;
        //        }
        //        if(add.UserName == null)
        //        {
        //            finalreturnModel.Message = "Username is required";
        //            finalreturnModel.Success = false;
        //            return finalreturnModel;
        //        }
        //        var Exist = _appDbContext.Users.Where(x => x.UserName == add.Name).FirstOrDefault();
        //        if(Exist == null)
        //        {
        //            Users newGrade = new Users();
        //            newGrade.Name = add.Name;
        //            newGrade.UserEmail = add.UserEmail;
        //            newGrade.Password = add.Password;
        //            newGrade.CreatedBy = add.CreatedBy;
        //            _appDbContext.Users.Add(newGrade);
        //            _appDbContext.SaveChanges();

        //            finalreturnModel.Message = "Add successfully";
        //            finalreturnModel.Success = true;
        //            return finalreturnModel;
        //        }
        //        else
        //        {
        //            finalreturnModel.Message = "User allready exist";
        //            finalreturnModel.Success = false;
        //            return finalreturnModel;
        //        }
        //    }
        //    catch (System.Exception ex)
        //    {
        //        finalreturnModel.Message = ex.Message;
        //        if (ex.InnerException != null)
        //            finalreturnModel.Message = finalreturnModel.Message + "\n" + ex.InnerException.Message.ToString();

        //        finalreturnModel.Success = false;
        //        return finalreturnModel;
        //    }
        //}

        //public object GetCompanyProductRelation()
        //{
        //    var productDetails = from comp in _appDbContext.CompanyProducts

        //                         join relation in _appDbContext.ComapnyProductRelationships
        //                         on comp. equals relation.CompanyId
        //                         //join company in _appDbContext.Companies
        //                         //on relation.CompanyId equals company.CompanyId
        //                         select new
        //                         {
        //                             //product.Id,
        //                             comp.Name,
        //                             comp.Description,
        //                             comp.CreatedBy,
        //                             comp.CreatedAt,
        //                             comp.ModifiedBy,
        //                             comp.ModifiedAt,
        //                             comp.IsDeleted,
        //                             //CompanyId = comp.CompanyId,
        //                             CompanyName = relation.CompanyName
        //                         };

        //    var result = productDetails.ToList();
        //    return result;   

        //}

        public object AddUpdateCompany(Companyi add)
        {
            try
            {
                if (add.UserId == 0)
                {
                    finalreturnModel.Message = "id is not found";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }

                if (add.CompanyName == null)
                {
                    finalreturnModel.Message = "company name is equired";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }
                if (add.CompanyId != 0)
                {
                    var userId = add.CompanyId;
                    var IsExist = _appDbContext.Companies.Where(x => x.CompanyId == userId).FirstOrDefault();
                    if (IsExist != null)
                    {
                        IsExist.CompanyName = add.CompanyName;
                        IsExist.Description = add.Description;
                        IsExist.ModifiedBy = add.UserId;
                        //IsExist.CreatedAt = DateTime.Now;
                        IsExist.ModifiedAt = DateTime.Now;

                        _appDbContext.SaveChanges();

                        finalreturnModel.Message = "update successfully";
                        finalreturnModel.Success = true;
                        return finalreturnModel;
                    }
                    else
                    {
                        finalreturnModel.Message = "Id not found";
                        finalreturnModel.Success = false;
                        return finalreturnModel;
                    }

                }
                else
                {
                    var Exist = _appDbContext.Companies.Where(x => x.CompanyName == add.CompanyName).FirstOrDefault();
                    if (add.UserId == 0)
                    {
                        finalreturnModel.Message = "id is not found";
                        finalreturnModel.Success = false;
                        return finalreturnModel;
                    }
                    if (Exist == null)
                    {
                        Companies newGrade = new Companies();
                        newGrade.CompanyName = add.CompanyName;
                        newGrade.Description = add.Description;
                        newGrade.CreatedBy = add.UserId;
                        //newGrade.CreatedAt = DateTime.Now;
                        //newGrade.ModifiedAt = DateTime.Now;
                        _appDbContext.Companies.Add(newGrade);
                        _appDbContext.SaveChanges();

                        finalreturnModel.Message = " add successfully";
                        finalreturnModel.Success = true;
                        return finalreturnModel;
                    }
                    else
                    {
                        finalreturnModel.Message = "allready exist";
                        finalreturnModel.Success = false;
                        return finalreturnModel;
                    }
                }
            }

            catch (System.Exception ex)
            {
                finalreturnModel.Message = ex.Message;
                if (ex.InnerException != null)
                    finalreturnModel.Message = finalreturnModel.Message + "\n" + ex.InnerException.Message.ToString();

                finalreturnModel.Success = false;
                return finalreturnModel;
            }

        }

        public object GetCompany()
        {
            var product = (from e in _appDbContext.Companies
                           join u in _appDbContext.Users on e.CreatedBy equals u.UserId into deptGroup
                           from u in deptGroup.DefaultIfEmpty()
                           join um in _appDbContext.Users on e.ModifiedBy equals um.UserId into deptmGroup
                           from um in deptmGroup.DefaultIfEmpty()
                           select new
                           {
                               e.CompanyId,
                               e.CompanyName,
                               e.Description,
                               //e.ProductId,
                               //e.ServiceId,
                               //e.ToolId,
                               ModifiedByName = um.UserName,
                               CreatedByName = u.UserName,
                               //e.ModifiedAt,

                               //Users = u != null ? u.USerName: null
                           }).ToList();
            //var data = product.AsQueryable();
            //var datanew = data.OrderByDescending(x => x.ModifiedAt).ToList();
            finalreturnModel.Success = true;
            return (product);
        }

        public object AddUpdateCompanyToolRelation(CompanyToolModel add)
        {
            try
            {
                if (add.CompanyId == null || add.CompanyId == 0)
                {
                    finalreturnModel.Message = "Id is Required";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }

                else
                {
                    var tId = add.ToolId;
                    foreach (var item in tId)
                    {
                        var Exist = _appDbContext.CompanyToolRelationship.Where(x => x.CompanyId == add.CompanyId && x.ToolId == item).FirstOrDefault();
                        if (Exist == null)
                        {
                            CompanyToolRelationship newGrade = new CompanyToolRelationship();
                            newGrade.CompanyId = add.CompanyId;
                            newGrade.ToolId = item;
                            _appDbContext.CompanyToolRelationship.Add(newGrade);
                            _appDbContext.SaveChanges();

                            finalreturnModel.Message = " add successfully";
                            finalreturnModel.Success = true;
                            return finalreturnModel;
                        }
                    }
                    finalreturnModel.Message = "allready exist";
                    finalreturnModel.Success = false;
                    return finalreturnModel;


                }


            }
            catch (System.Exception ex)
            {
                finalreturnModel.Message = ex.Message;
                if (ex.InnerException != null)
                    finalreturnModel.Message = finalreturnModel.Message + "\n" + ex.InnerException.Message.ToString();

                finalreturnModel.Success = false;
                return finalreturnModel;
            }
        }

        public object GetToolRelation()
        {
            var query = from pt in _appDbContext.CompanyToolRelationship
                        join c in _appDbContext.Companies on pt.CompanyId equals c.CompanyId
                        join t in _appDbContext.CompanyTools on pt.ToolId equals t.Id
                        select new
                        {
                            pt.Id,
                            c.CompanyId,
                            pt.ToolId,



                        };

            return query.ToList();

        }

        public object GetToolRelationid(int toolid)
        {
            try
            {
                if (toolid == 0)
                {
                    finalreturnModel.Message = "id is required";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }
                var result = (from pt in _appDbContext.CompanyToolRelationship
                              join c in _appDbContext.Companies on pt.CompanyId equals c.CompanyId
                              join t in _appDbContext.CompanyTools on pt.ToolId equals t.Id
                              select new
                              {
                                  pt.Id,
                                  c.CompanyId,
                                  pt.ToolId,
                              });

                if (result == null)
                {
                    finalreturnModel.Message = "Data not found!";
                    finalreturnModel.Success = true;
                    return finalreturnModel;
                }
                else
                {
                    return result;
                }

            }
            catch (System.Exception ex)
            {
                finalreturnModel.Message = ex.Message;
                if (ex.InnerException != null)
                    finalreturnModel.Message = finalreturnModel.Message + "\n" + ex.InnerException.Message.ToString();

                finalreturnModel.Success = false;
                return finalreturnModel;
            }

        }

        public object AddCompanyService(CompanyServiceModel add)
        {
            try
            {
                if (add.CompanyId == null || add.CompanyId == 0)
                {
                    finalreturnModel.Message = "Id is Required";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }

                else
                {
                    var sID = add.ServiceId;
                    foreach (var item in sID)
                    {
                        var Exist = _appDbContext.CompanyServiceRelationship.Where(x => x.CompanyId == add.CompanyId && x.ServiceId == item).FirstOrDefault();
                        if (Exist == null)
                        {
                            CompanyServiceRelationship newGrade = new CompanyServiceRelationship();
                            newGrade.CompanyId = add.CompanyId;
                            newGrade.ServiceId = item;
                            _appDbContext.CompanyServiceRelationship.Add(newGrade);
                            _appDbContext.SaveChanges();

                            finalreturnModel.Message = " add successfully";
                            finalreturnModel.Success = true;
                            return finalreturnModel;
                        }
                    }
                    finalreturnModel.Message = "allready exist";
                    finalreturnModel.Success = false;
                    return finalreturnModel;


                }


            }
            catch (System.Exception ex)
            {
                finalreturnModel.Message = ex.Message;
                if (ex.InnerException != null)
                    finalreturnModel.Message = finalreturnModel.Message + "\n" + ex.InnerException.Message.ToString();

                finalreturnModel.Success = false;
                return finalreturnModel;
            }
        }

        public object GetCompanyServiceByid(int serviceid)
        {
            try
            {
                if (serviceid == 0)
                {
                    finalreturnModel.Message = "id is required";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }
                var result = (from pt in _appDbContext.CompanyServiceRelationship
                              join c in _appDbContext.Companies on pt.CompanyId equals c.CompanyId
                              join t in _appDbContext.ComapanyServices on pt.ServiceId equals t.Id
                              select new
                              {
                                  pt.Id,
                                  c.CompanyId,
                                  pt.ServiceId,

                              });

                if (result == null)
                {
                    finalreturnModel.Message = "Data not found!";
                    finalreturnModel.Success = true;
                    return finalreturnModel;
                }
                else
                {
                    return result;
                }

            }
            catch (System.Exception ex)
            {
                finalreturnModel.Message = ex.Message;
                if (ex.InnerException != null)
                    finalreturnModel.Message = finalreturnModel.Message + "\n" + ex.InnerException.Message.ToString();

                finalreturnModel.Success = false;
                return finalreturnModel;
            }
        }

        public object AddComapnyProduct(CompanyProductRequestModel add)
        {
            try
            {
                if (add.CompanyId == null || add.CompanyId == 0)
                {
                    finalreturnModel.Message = "Company can't be null or 0";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }
                else
                {
                    var pId = add.ProductId;
                    foreach (var item in pId)
                    {
                        var Exist = _appDbContext.companyProductRelationship.Where(x => x.CompanyId == add.CompanyId && x.ProductId == item).ToList();
                        if (Exist.Count == 0)
                        {
                            CompanyProductRelationship newGrade = new CompanyProductRelationship();
                            newGrade.CompanyId = add.CompanyId;
                            newGrade.ProductId = item;
                            _appDbContext.companyProductRelationship.Add(newGrade);
                            _appDbContext.SaveChanges();
                        }
                    }
                    finalreturnModel.Message = " add successfully";
                    finalreturnModel.Success = true;
                    return finalreturnModel;

                }


            }
            catch (System.Exception ex)
            {
                finalreturnModel.Message = ex.Message;
                if (ex.InnerException != null)
                    finalreturnModel.Message = finalreturnModel.Message + "\n" + ex.InnerException.Message.ToString();

                finalreturnModel.Success = false;
                return finalreturnModel;
            }
        }
        public object AddDummyAccount(AccountRequest add)
        {
            try
            {
                var aId = add.dummy;
                foreach (var item in aId)
                {
                    var Exist = _appDbContext.AccountDummy.Where(x => x.CompanyId == item.CompanyId && x.AccountId == add.AccountId).ToList();
                    if (Exist.Count == 0)
                    {
                        AccountDummy newGrade = new AccountDummy();

                        newGrade.CompanyId = item.CompanyId;
                        newGrade.AccountId = add.AccountId;
                        _appDbContext.AccountDummy.Add(newGrade);
                        _appDbContext.SaveChanges();
                    }
                }
                finalreturnModel.Message = " add successfully";
                finalreturnModel.Success = true;
                return finalreturnModel;
            }
            catch (System.Exception ex)
            {
                finalreturnModel.Message = ex.Message;
                if (ex.InnerException != null)
                    finalreturnModel.Message = finalreturnModel.Message + "\n" + ex.InnerException.Message.ToString();

                finalreturnModel.Success = false;
                return finalreturnModel;
            }
        }

        public object GetCompanyProductByid(int productid)
        {
            try
            {
                if (productid == 0)
                {
                    finalreturnModel.Message = "id is required";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }
                var result = (from pt in _appDbContext.companyProductRelationship
                              join c in _appDbContext.Companies on pt.CompanyId equals c.CompanyId
                              join t in _appDbContext.CompanyProducts on pt.ProductId equals t.Id
                              select new
                              {
                                  pt.Id,
                                  c.CompanyId,
                                  pt.ProductId,

                              });

                if (result == null)
                {
                    finalreturnModel.Message = "Data not found!";
                    finalreturnModel.Success = true;
                    return finalreturnModel;
                }
                else
                {
                    return result;
                }

            }
            catch (System.Exception ex)
            {
                finalreturnModel.Message = ex.Message;
                if (ex.InnerException != null)
                    finalreturnModel.Message = finalreturnModel.Message + "\n" + ex.InnerException.Message.ToString();

                finalreturnModel.Success = false;
                return finalreturnModel;
            }
        }

        public object GetDummyAccount()
        {
            var query = from pt in _appDbContext.AccountDummy
                        join c in _appDbContext.Companies on pt.CompanyId equals c.CompanyId
                        select new
                        {
                            pt.Id,
                            c.CompanyId,
                            pt.AccountId,

                        };

            return query.ToList();
        }



        public object AddUpdateClassification(Classficationrequestcs addnew)
        {
            try
            {
                if (addnew.Name == null)
                {
                    finalreturnModel.Message = "name not found";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }
                if (addnew.Id != 0)
                {
                    var id = addnew.Id;
                    var IsExist = _appDbContext.Classification.Where(x => x.Id == id && x.IsDeleted == false).FirstOrDefault();
                    if (IsExist != null)
                    {
                        IsExist.Name = addnew.Name;
                        IsExist.Description = addnew.Description;
                        IsExist.ModifiedBy = addnew.UserId;
                        //IsExist.ModifiedAt = DateTime.Now;
                        //IsExist.PublicId = addnew.PublicId;
                        _appDbContext.SaveChanges();
                        finalreturnModel.Message = "Update successfully";
                        finalreturnModel.Success = true;
                        return finalreturnModel;
                    }
                    else
                    {
                        finalreturnModel.Message = "Id not found";
                        finalreturnModel.Success = false;
                        return finalreturnModel;
                    }

                }
                else
                {
                    var Exist = _appDbContext.Classification.Where(x => x.Name == addnew.Name && x.IsDeleted == false).FirstOrDefault();
                    if (Exist == null)
                    {
                        Classification newclass = new Classification();
                        newclass.Name = addnew.Name;
                        newclass.Description = addnew.Description;
                        newclass.CreatedBy = addnew.UserId;
                        newclass.CreatedAt = DateTime.Now;
                        Guid newguid = new Guid();
                        newclass.PublicId = Guid.NewGuid();
                        //newclass.ModifiedAt = DateTime.Now;
                        //newclass.PublicId = addnew.PublicId;
                        _appDbContext.Classification.Add(newclass);
                        _appDbContext.SaveChanges();
                        finalreturnModel.Message = "add suceesfully";
                        finalreturnModel.Success = true;
                        return finalreturnModel;
                    }
                    else
                    {
                        finalreturnModel.Message = "allready exist";
                        finalreturnModel.Success = false;
                        return finalreturnModel;
                    }
                }


            }
            catch (System.Exception ex)
            {
                finalreturnModel.Message = ex.Message;
                if (ex.InnerException != null)
                    finalreturnModel.Message = finalreturnModel.Message + "\n" + ex.InnerException.Message.ToString();

                finalreturnModel.Success = false;
                return finalreturnModel;
            }
        }

        public object GetClassificationDetails(LocationsViewModel request)
        {
            try
            {
                var result = (from ct in _appDbContext.Classification
                              join us in _appDbContext.Userss on ct.CreatedBy equals us.UserId into deptGroup
                              from us in deptGroup.DefaultIfEmpty()
                              join us1 in _appDbContext.Userss on ct.ModifiedBy equals us1.UserId into deptaGroup
                              from us1 in deptaGroup.DefaultIfEmpty()
                              where ct.IsDeleted == false
                              select new
                              {
                                  ct.Description,
                                  ct.Name,
                                  ct.Id,
                                  CreatedBy = us != null ? us.UserssName : null,
                                  ModifiedBy = us1 != null ? us1.UserssName : null,

                              });

                #region Filter
                if (request.filter != null)
                {
                    string[] strFilteString = Convert.ToString(request.filter).Split(new string[] { "\"key\":" }, StringSplitOptions.None);
                    foreach (var item in strFilteString)
                    {
                        if (item.Contains("startwith"))
                        {
                            string fieldName = item.Split(':')[0].Split(',')[1].Replace("\r\n", "").Replace("\"", "").Trim();
                            string fieldValue = item.Split(new string[] { "\":" }, StringSplitOptions.None)[1].Replace("\r\n", "").Replace("\"", "").Replace("},", "").Replace("{", "").Replace("}", "").Replace("]", "").Trim();

                            fieldValue = fieldValue.ToUpper();

                            if (String.Equals(fieldName, "name"))
                                result = result.Where(x => x.Name.ToUpper().StartsWith(fieldValue));
                            if (String.Equals(fieldName, "createdBy"))
                                result = result.Where(x => x.CreatedBy.ToUpper().StartsWith(fieldValue));
                            if (String.Equals(fieldName, "modifiedBy"))
                                result = result.Where(x => x.ModifiedBy.ToUpper().StartsWith(fieldValue));
                        }
                    }
                }
                if (request.sort != null)
                {
                    if (request.sort.desc == true)
                    {
                        string selector = request.sort.selector;
                        switch (selector)
                        {
                            case "name":
                                result = result.OrderByDescending(x => x.Name);
                                break;
                            case "createdBy":
                                result = result.OrderByDescending(x => x.CreatedBy);
                                break;
                            case "modifiedBy":
                                result = result.OrderByDescending(x => x.ModifiedBy);
                                break;
                            case "id":
                                result = result.OrderByDescending(x => x.Id);
                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        string selector = request.sort.selector;
                        switch (selector)
                        {
                            case "name":
                                result = result.OrderBy(x => x.Name);
                                break;
                            case "createdBy":
                                result = result.OrderBy(x => x.CreatedBy);
                                break;
                            case "modifiedBy":
                                result = result.OrderBy(x => x.ModifiedBy);
                                break;
                            case "id":
                                result = result.OrderBy(x => x.Id);
                                break;
                            default:
                                break;
                        }
                    }
                }
                else
                {
                    result = result.OrderByDescending(x => x.Id);

                }
                var Count1 = result.ToList();
                var count = Count1.Count();
                #endregion filter
                var data1 = result.Skip((request.pageNo - 1) * request.pagesize)
                 .Take(request.pagesize)
                 .ToList();
                var finalResult = new { Count = count, tsmv = data1 };
                return finalResult;



                //if (!result.Any())
                //{

                //    return new { Success = false, Message = "No data found in the Classification table" };
                //}


                //var filteredClass = result.Where(p => p.Name.Contains(FilterByName)).DistinctBy(p => p.Name).ToList();

                //if (!filteredClass.Any())
                //{
                //    return new { Success = false, Message = "No matching records found for the provided search letter" };
                //}

                //return new { Success = true, Data = filteredClass };


            }
            catch (System.Exception ex)
            {
                finalreturnModel.Message = ex.Message;
                if (ex.InnerException != null)
                    finalreturnModel.Message = finalreturnModel.Message + "\n" + ex.InnerException.Message.ToString();

                finalreturnModel.Success = false;
                return finalreturnModel;
            }



        }

        public object DeleteClassification(int classificationid)
        {
            try
            {
                if (classificationid == 0)
                {
                    finalreturnModel.Message = "id is required";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }
                var Remove = _appDbContext.Classification.Where(X => X.Id == classificationid).FirstOrDefault();
                if (Remove != null)
                {
                    _appDbContext.Remove(Remove);
                    _appDbContext.SaveChanges();
                    finalreturnModel.Success = true;
                    return finalreturnModel;
                }
                else
                {
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }


            }
            catch (System.Exception ex)
            {
                finalreturnModel.Message = ex.Message;
                if (ex.InnerException != null)
                    finalreturnModel.Message = finalreturnModel.Message + "\n" + ex.InnerException.Message.ToString();

                finalreturnModel.Success = false;
                return finalreturnModel;
            }

        }


        public object AddUpdateSubClassification(SubClassficationrequestcs addnew)
        {
            try
            {
                if (addnew.Name == null)
                {
                    finalreturnModel.Message = "name not found";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }
                if (addnew.Id != 0)
                {
                    var id = addnew.Id;
                    var IsExist = _appDbContext.SubClassification.Where(x => x.Id == id && x.IsDeleted == false).FirstOrDefault();
                    if (IsExist != null)
                    {
                        IsExist.Name = addnew.Name;
                        IsExist.Description = addnew.Description;
                        IsExist.ModifiedBy = addnew.UserId;
                        IsExist.ModifiedAt = DateTime.Now;
                        //IsExist.PublicId = addnew.PublicId;
                        _appDbContext.SaveChanges();
                        finalreturnModel.Message = "Update successfully";
                        finalreturnModel.Success = true;
                        return finalreturnModel;
                    }
                    else
                    {
                        finalreturnModel.Message = "Id not found";
                        finalreturnModel.Success = false;
                        return finalreturnModel;
                    }

                }
                else
                {
                    var Exist = _appDbContext.Classification.Where(x => x.Name == addnew.Name && x.IsDeleted == false).FirstOrDefault();
                    if (Exist == null)
                    {
                        SubClassification newclass = new SubClassification();
                        newclass.Name = addnew.Name;
                        newclass.Description = addnew.Description;
                        newclass.CreatedBy = addnew.UserId;
                        newclass.CreatedAt = DateTime.Now;
                        Guid newguid = new Guid();
                        //newclass.PublicId = addnew.PublicId;
                        newclass.PublicId = Guid.NewGuid();
                        _appDbContext.SubClassification.Add(newclass);
                        _appDbContext.SaveChanges();
                        finalreturnModel.Message = "add suceesfully";
                        finalreturnModel.Success = true;
                        return finalreturnModel;
                    }
                    else
                    {
                        finalreturnModel.Message = "allready exist";
                        finalreturnModel.Success = false;
                        return finalreturnModel;
                    }
                }


            }
            catch (System.Exception ex)
            {
                finalreturnModel.Message = ex.Message;
                if (ex.InnerException != null)
                    finalreturnModel.Message = finalreturnModel.Message + "\n" + ex.InnerException.Message.ToString();

                finalreturnModel.Success = false;
                return finalreturnModel;
            }
        }

        public object DeleteSubClassification(int Subclassificationid)
        {
            try
            {
                if (Subclassificationid == 0)
                {
                    finalreturnModel.Message = "id is required";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }
                var Remove = _appDbContext.SubClassification.Where(X => X.Id == Subclassificationid).FirstOrDefault();
                if (Remove != null)
                {
                    _appDbContext.Remove(Remove);
                    _appDbContext.SaveChanges();
                    finalreturnModel.Success = true;
                    return finalreturnModel;
                }
                else
                {
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }


            }
            catch (System.Exception ex)
            {
                finalreturnModel.Message = ex.Message;
                if (ex.InnerException != null)
                    finalreturnModel.Message = finalreturnModel.Message + "\n" + ex.InnerException.Message.ToString();

                finalreturnModel.Success = false;
                return finalreturnModel;
            }

        }

        public object GetSubClassification(string FilterByName)
        {
            try
            {
                var result = (from ct in _appDbContext.SubClassification
                              join us in _appDbContext.Userss on ct.CreatedBy equals us.UserId into deptGroup
                              from us in deptGroup.DefaultIfEmpty()
                              join us1 in _appDbContext.Userss on ct.ModifiedBy equals us1.UserId into deptaGroup
                              from us1 in deptaGroup.DefaultIfEmpty()
                              select new
                              {
                                  ct.Description,
                                  ct.Name,
                                  ct.Id,
                                  CreatedBy = us != null ? us.UserssName : null,
                                  ModifiedBy = us != null ? us.UserssName : null,

                              }).ToList();


                if (!result.Any())
                {

                    return new { Success = false, Message = "No data found in the Classification table" };
                }


                var filteredClass = result.Where(p => p.Name.Contains(FilterByName)).DistinctBy(p => p.Name).ToList();

                if (!filteredClass.Any())
                {
                    return new { Success = false, Message = "No matching records found for the provided search letter" };
                }

                return new { Success = true, Data = filteredClass };


            }
            catch (System.Exception ex)
            {
                finalreturnModel.Message = ex.Message;
                if (ex.InnerException != null)
                    finalreturnModel.Message = finalreturnModel.Message + "\n" + ex.InnerException.Message.ToString();

                finalreturnModel.Success = false;
                return finalreturnModel;
            }



        }

        public object AddUpdateSuperClassification(SuperClassficationrequestcs addnew)
        {
            try
            {
                if (addnew.Name == null)
                {
                    finalreturnModel.Message = "name not found";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }
                if (addnew.Id != 0)
                {
                    var id = addnew.Id;
                    var IsExist = _appDbContext.SuperClassification.Where(x => x.Id == id && x.IsDeleted == false).FirstOrDefault();
                    if (IsExist != null)
                    {
                        IsExist.Name = addnew.Name;
                        IsExist.Description = addnew.Description;
                        IsExist.ModifiedBy = addnew.UserId;
                        //IsExist.ModifiedAt = DateTime.Now;
                        //IsExist.PublicId = addnew.PublicId;
                        _appDbContext.SaveChanges();
                        finalreturnModel.Message = "Update successfully";
                        finalreturnModel.Success = true;
                        return finalreturnModel;
                    }
                    else
                    {
                        finalreturnModel.Message = "Id not found";
                        finalreturnModel.Success = false;
                        return finalreturnModel;
                    }

                }
                else
                {
                    var Exist = _appDbContext.SuperClassification.Where(x => x.Name == addnew.Name && x.IsDeleted == false).FirstOrDefault();
                    if (Exist == null)
                    {
                        SuperClassification newclass = new SuperClassification();
                        newclass.Name = addnew.Name;
                        newclass.Description = addnew.Description;
                        newclass.CreatedBy = addnew.UserId;
                        newclass.CreatedAt = DateTime.Now;
                        //Guid newguid = new Guid();
                        newclass.PublicId = Guid.NewGuid();

                        //newclass.ModifiedAt = DateTime.Now;
                        //newclass.PublicId = addnew.PublicId;
                        _appDbContext.SuperClassification.Add(newclass);
                        _appDbContext.SaveChanges();
                        finalreturnModel.Message = "add suceesfully";
                        finalreturnModel.Success = true;
                        return finalreturnModel;
                    }
                    else
                    {
                        finalreturnModel.Message = "allready exist";
                        finalreturnModel.Success = false;
                        return finalreturnModel;
                    }
                }


            }
            catch (System.Exception ex)
            {
                finalreturnModel.Message = ex.Message;
                if (ex.InnerException != null)
                    finalreturnModel.Message = finalreturnModel.Message + "\n" + ex.InnerException.Message.ToString();

                finalreturnModel.Success = false;
                return finalreturnModel;
            }
        }

        public object GetSuperClassification(string FilterByName)
        {
            try
            {
                var result = (from ct in _appDbContext.SuperClassification
                              join us in _appDbContext.Userss on ct.CreatedBy equals us.UserId into deptGroup
                              from us in deptGroup.DefaultIfEmpty()
                              join us1 in _appDbContext.Userss on ct.ModifiedBy equals us1.UserId into deptaGroup
                              from us1 in deptaGroup.DefaultIfEmpty()
                              where ct.IsDeleted == false
                              select new
                              {
                                  ct.Description,
                                  ct.Name,
                                  ct.Id,
                                  CreatedBy = us != null ? us.UserssName : null,
                                  ModifiedBy = us1 != null ? us1.UserssName : null,

                              }).ToList();


                if (!result.Any())
                {

                    return new { Success = false, Message = "No data found in the Classification table" };
                }


                var filteredClass = result.Where(p => p.Name.Contains(FilterByName)).DistinctBy(p => p.Name).ToList();

                if (!filteredClass.Any())
                {
                    return new { Success = false, Message = "No matching records found for the provided search letter" };
                }

                return new { Success = true, Data = filteredClass };


            }
            catch (System.Exception ex)
            {
                finalreturnModel.Message = ex.Message;
                if (ex.InnerException != null)
                    finalreturnModel.Message = finalreturnModel.Message + "\n" + ex.InnerException.Message.ToString();

                finalreturnModel.Success = false;
                return finalreturnModel;
            }

        }

        public object DeleteSuperClassification(int classificationid)
        {
            try
            {
                if (classificationid == 0)
                {
                    finalreturnModel.Message = "id is required";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }
                var Remove = _appDbContext.SuperClassification.Where(X => X.Id == classificationid).FirstOrDefault();
                if (Remove != null)
                {
                    _appDbContext.Remove(Remove);
                    _appDbContext.SaveChanges();
                    finalreturnModel.Success = true;
                    return finalreturnModel;
                }
                else
                {
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }


            }
            catch (System.Exception ex)
            {
                finalreturnModel.Message = ex.Message;
                if (ex.InnerException != null)
                    finalreturnModel.Message = finalreturnModel.Message + "\n" + ex.InnerException.Message.ToString();

                finalreturnModel.Success = false;
                return finalreturnModel;
            }

        }

        public object AddUpdateDomains(Domainsreq addnew)
        {
            try
            {
                if (addnew.Name == null)
                {
                    finalreturnModel.Message = "name not found";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }
                if (addnew.Id != 0)
                {
                    var id = addnew.Id;
                    var IsExist = _appDbContext.Domains.Where(x => x.Id == id && x.IsDeleted == false).FirstOrDefault();
                    if (IsExist != null)
                    {
                        IsExist.Name = addnew.Name;
                        IsExist.Description = addnew.Description;
                        IsExist.ModifiedBy = addnew.UserId;
                        //IsExist.ModifiedAt = DateTime.Now;
                        //IsExist.PublicId = addnew.PublicId;
                        _appDbContext.SaveChanges();
                        finalreturnModel.Message = "Update successfully";
                        finalreturnModel.Success = true;
                        return finalreturnModel;
                    }
                    else
                    {
                        finalreturnModel.Message = "Id not found";
                        finalreturnModel.Success = false;
                        return finalreturnModel;
                    }

                }
                else
                {
                    var Exist = _appDbContext.Domains.Where(x => x.Name == addnew.Name && x.IsDeleted == false).FirstOrDefault();
                    if (Exist == null)
                    {
                        Domains newclass = new Domains();
                        newclass.Name = addnew.Name;
                        newclass.Description = addnew.Description;
                        newclass.CreatedBy = addnew.UserId;
                        newclass.CreatedAt = DateTime.Now;
                        //Guid newguid = new Guid();
                        newclass.PublicId = Guid.NewGuid();

                        //newclass.ModifiedAt = DateTime.Now;
                        //newclass.PublicId = addnew.PublicId;
                        _appDbContext.Domains.Add(newclass);
                        _appDbContext.SaveChanges();
                        finalreturnModel.Message = "add suceesfully";
                        finalreturnModel.Success = true;
                        return finalreturnModel;
                    }
                    else
                    {
                        finalreturnModel.Message = "allready exist";
                        finalreturnModel.Success = false;
                        return finalreturnModel;
                    }
                }

            }
            catch (System.Exception ex)
            {
                finalreturnModel.Message = ex.Message;
                if (ex.InnerException != null)
                    finalreturnModel.Message = finalreturnModel.Message + "\n" + ex.InnerException.Message.ToString();

                finalreturnModel.Success = false;
                return finalreturnModel;
            }
        }

        public object GetDomains(string FilterByName)
        {

            try
            {
                var result = (from ct in _appDbContext.Domains
                              join us in _appDbContext.Userss on ct.CreatedBy equals us.UserId into deptGroup
                              from us in deptGroup.DefaultIfEmpty()
                              join us1 in _appDbContext.Userss on ct.ModifiedBy equals us1.UserId into deptaGroup
                              from us1 in deptaGroup.DefaultIfEmpty()
                              where ct.IsDeleted == false
                              select new
                              {
                                  ct.Description,
                                  ct.Name,
                                  ct.Id,
                                  CreatedBy = us != null ? us.UserssName : null,
                                  ModifiedBy = us1 != null ? us1.UserssName : null,

                              }).ToList();


                if (!result.Any())
                {

                    return new { Success = false, Message = "No data found in the Classification table" };
                }


                var filteredClass = result.Where(p => p.Name.Contains(FilterByName)).DistinctBy(p => p.Name).ToList();

                if (!filteredClass.Any())
                {
                    return new { Success = false, Message = "No matching records found for the provided search letter" };
                }

                return new { Success = true, Data = filteredClass };


            }
            catch (System.Exception ex)
            {
                finalreturnModel.Message = ex.Message;
                if (ex.InnerException != null)
                    finalreturnModel.Message = finalreturnModel.Message + "\n" + ex.InnerException.Message.ToString();

                finalreturnModel.Success = false;
                return finalreturnModel;
            }
        }

        public object DeleteDomains(int classificationid)
        {
            try
            {
                if (classificationid == 0)
                {
                    finalreturnModel.Message = "id is required";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }
                var Remove = _appDbContext.Domains.Where(X => X.Id == classificationid).FirstOrDefault();
                if (Remove != null)
                {
                    _appDbContext.Remove(Remove);
                    _appDbContext.SaveChanges();
                    finalreturnModel.Success = true;
                    return finalreturnModel;
                }
                else
                {
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }


            }
            catch (System.Exception ex)
            {
                finalreturnModel.Message = ex.Message;
                if (ex.InnerException != null)
                    finalreturnModel.Message = finalreturnModel.Message + "\n" + ex.InnerException.Message.ToString();

                finalreturnModel.Success = false;
                return finalreturnModel;
            }

        }

        public object AddUpdateIndustries(Industriesreq addnew)
        {
            try
            {
                if (addnew.Name == null)
                {
                    finalreturnModel.Message = "name not found";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }
                if (addnew.Id != 0)
                {
                    var id = addnew.Id;
                    var IsExist = _appDbContext.Industries.Where(x => x.Id == id && x.IsDeleted == false).FirstOrDefault();
                    if (IsExist != null)
                    {
                        IsExist.Name = addnew.Name;
                        IsExist.Description = addnew.Description;
                        IsExist.ModifiedBy = addnew.UserId;
                        //IsExist.ModifiedAt = DateTime.Now;
                        //IsExist.PublicId = addnew.PublicId;
                        _appDbContext.SaveChanges();
                        finalreturnModel.Message = "Update successfully";
                        finalreturnModel.Success = true;
                        return finalreturnModel;
                    }
                    else
                    {
                        finalreturnModel.Message = "Id not found";
                        finalreturnModel.Success = false;
                        return finalreturnModel;
                    }

                }
                else
                {
                    var Exist = _appDbContext.Industries.Where(x => x.Name == addnew.Name && x.IsDeleted == false).FirstOrDefault();
                    if (Exist == null)
                    {
                        Industries newclass = new Industries();
                        newclass.Name = addnew.Name;
                        newclass.Description = addnew.Description;
                        newclass.CreatedBy = addnew.UserId;
                        newclass.CreatedAt = DateTime.Now;
                        Guid newguid = new Guid();
                        newclass.PublicId = Guid.NewGuid();
                        //newclass.ModifiedAt = DateTime.Now;
                        //newclass.PublicId = addnew.PublicId;
                        _appDbContext.Industries.Add(newclass);
                        _appDbContext.SaveChanges();
                        finalreturnModel.Message = "add suceesfully";
                        finalreturnModel.Success = true;
                        return finalreturnModel;
                    }
                    else
                    {
                        finalreturnModel.Message = "allready exist";
                        finalreturnModel.Success = false;
                        return finalreturnModel;
                    }
                }


            }
            catch (System.Exception ex)
            {
                finalreturnModel.Message = ex.Message;
                if (ex.InnerException != null)
                    finalreturnModel.Message = finalreturnModel.Message + "\n" + ex.InnerException.Message.ToString();

                finalreturnModel.Success = false;
                return finalreturnModel;
            }
        }

        public object GetIndustries(string FilterByName)
        {
            try
            {
                var result = (from ct in _appDbContext.Industries
                              join us in _appDbContext.Userss on ct.CreatedBy equals us.UserId into deptGroup
                              from us in deptGroup.DefaultIfEmpty()
                              join us1 in _appDbContext.Userss on ct.ModifiedBy equals us1.UserId into deptaGroup
                              from us1 in deptaGroup.DefaultIfEmpty()
                              where ct.IsDeleted == false
                              select new
                              {
                                  ct.Description,
                                  ct.Name,
                                  ct.Id,
                                  CreatedBy = us != null ? us.UserssName : null,
                                  ModifiedBy = us1 != null ? us1.UserssName : null,

                              }).ToList();


                if (!result.Any())
                {

                    return new { Success = false, Message = "No data found in the Classification table" };
                }


                var filteredClass = result.Where(p => p.Name.Contains(FilterByName)).DistinctBy(p => p.Name).ToList();

                if (!filteredClass.Any())
                {
                    return new { Success = false, Message = "No matching records found for the provided search letter" };
                }

                return new { Success = true, Data = filteredClass };


            }
            catch (System.Exception ex)
            {
                finalreturnModel.Message = ex.Message;
                if (ex.InnerException != null)
                    finalreturnModel.Message = finalreturnModel.Message + "\n" + ex.InnerException.Message.ToString();

                finalreturnModel.Success = false;
                return finalreturnModel;
            }



        }

        public object DeleteIndustries(int Industriesid)
        {
            try
            {
                if (Industriesid == 0)
                {
                    finalreturnModel.Message = "id is required";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }
                var Remove = _appDbContext.Domains.Where(X => X.Id == Industriesid).FirstOrDefault();
                if (Remove != null)
                {
                    _appDbContext.Remove(Remove);
                    _appDbContext.SaveChanges();
                    finalreturnModel.Success = true;
                    return finalreturnModel;
                }
                else
                {
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }


            }
            catch (System.Exception ex)
            {
                finalreturnModel.Message = ex.Message;
                if (ex.InnerException != null)
                    finalreturnModel.Message = finalreturnModel.Message + "\n" + ex.InnerException.Message.ToString();

                finalreturnModel.Success = false;
                return finalreturnModel;
            }

        }


        public object AddUpdateSubIndustries(SubIndustriesreq addnew)
        {
            try
            {
                if (addnew.Name == null)
                {
                    finalreturnModel.Message = "name not found";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }
                if (addnew.Id != 0)
                {
                    var id = addnew.Id;
                    var IsExist = _appDbContext.SubIndustries.Where(x => x.Id == id && x.IsDeleted == false).FirstOrDefault();
                    if (IsExist != null)
                    {
                        IsExist.Name = addnew.Name;
                        IsExist.Description = addnew.Description;
                        IsExist.ModifiedBy = addnew.UserId;
                        //IsExist.ModifiedAt = DateTime.Now;
                        //IsExist.PublicId = addnew.PublicId;
                        _appDbContext.SaveChanges();
                        finalreturnModel.Message = "Update successfully";
                        finalreturnModel.Success = true;
                        return finalreturnModel;
                    }
                    else
                    {
                        finalreturnModel.Message = "Id not found";
                        finalreturnModel.Success = false;
                        return finalreturnModel;
                    }

                }
                else
                {
                    var Exist = _appDbContext.SubIndustries.Where(x => x.Name == addnew.Name && x.IsDeleted == false).FirstOrDefault();
                    if (Exist == null)
                    {
                        SubIndustries newclass = new SubIndustries();
                        newclass.Name = addnew.Name;
                        newclass.Description = addnew.Description;
                        newclass.CreatedBy = addnew.UserId;
                        newclass.CreatedAt = DateTime.Now;
                        Guid newguid = new Guid();
                        newclass.PublicId = Guid.NewGuid();
                        //newclass.ModifiedAt = DateTime.Now;
                        //newclass.PublicId = addnew.PublicId;
                        _appDbContext.SubIndustries.Add(newclass);
                        _appDbContext.SaveChanges();
                        finalreturnModel.Message = "add suceesfully";
                        finalreturnModel.Success = true;
                        return finalreturnModel;
                    }
                    else
                    {
                        finalreturnModel.Message = "allready exist";
                        finalreturnModel.Success = false;
                        return finalreturnModel;
                    }
                }


            }
            catch (System.Exception ex)
            {
                finalreturnModel.Message = ex.Message;
                if (ex.InnerException != null)
                    finalreturnModel.Message = finalreturnModel.Message + "\n" + ex.InnerException.Message.ToString();

                finalreturnModel.Success = false;
                return finalreturnModel;
            }
        }

        public object DeleteSubIndustries(int SubIndustriesid)
        {
            try
            {
                if (SubIndustriesid == 0)
                {
                    finalreturnModel.Message = "id is required";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }
                var Remove = _appDbContext.Domains.Where(X => X.Id == SubIndustriesid).FirstOrDefault();
                if (Remove != null)
                {
                    _appDbContext.Remove(Remove);
                    _appDbContext.SaveChanges();
                    finalreturnModel.Success = true;
                    return finalreturnModel;
                }
                else
                {
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }


            }
            catch (System.Exception ex)
            {
                finalreturnModel.Message = ex.Message;
                if (ex.InnerException != null)
                    finalreturnModel.Message = finalreturnModel.Message + "\n" + ex.InnerException.Message.ToString();

                finalreturnModel.Success = false;
                return finalreturnModel;
            }

        }



        public object AddUpdateProducts(Productreq addnew)
        {
            try
            {
                if (addnew.Name == null)
                {
                    finalreturnModel.Message = "name not found";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }
                if (addnew.Id != 0)
                {
                    var id = addnew.Id;
                    var IsExist = _appDbContext.Product.Where(x => x.Id == id && x.IsDeleted == false).FirstOrDefault();
                    if (IsExist != null)
                    {
                        IsExist.Name = addnew.Name;
                        IsExist.Description = addnew.Description;
                        IsExist.ModifiedBy = addnew.UserId;
                        //IsExist.ModifiedAt = DateTime.Now;
                        //IsExist.PublicId = addnew.PublicId;
                        _appDbContext.SaveChanges();
                        finalreturnModel.Message = "Update successfully";
                        finalreturnModel.Success = true;
                        return finalreturnModel;
                    }
                    else
                    {
                        finalreturnModel.Message = "Id not found";
                        finalreturnModel.Success = false;
                        return finalreturnModel;
                    }

                }
                else
                {
                    var Exist = _appDbContext.Product.Where(x => x.Name == addnew.Name && x.IsDeleted == false).FirstOrDefault();
                    if (Exist == null)
                    {
                        Product newclass = new Product();
                        newclass.Name = addnew.Name;
                        newclass.Description = addnew.Description;
                        newclass.CreatedBy = addnew.UserId;
                        newclass.CreatedAt = DateTime.Now;
                        Guid newguid = new Guid();
                        newclass.PublicId = Guid.NewGuid();
                        //newclass.ModifiedAt = DateTime.Now;
                        //newclass.PublicId = addnew.PublicId;
                        _appDbContext.Product.Add(newclass);
                        _appDbContext.SaveChanges();
                        finalreturnModel.Message = "add suceesfully";
                        finalreturnModel.Success = true;
                        return finalreturnModel;
                    }
                    else
                    {
                        finalreturnModel.Message = "allready exist";
                        finalreturnModel.Success = false;
                        return finalreturnModel;
                    }
                }


            }
            catch (System.Exception ex)
            {
                finalreturnModel.Message = ex.Message;
                if (ex.InnerException != null)
                    finalreturnModel.Message = finalreturnModel.Message + "\n" + ex.InnerException.Message.ToString();

                finalreturnModel.Success = false;
                return finalreturnModel;
            }
        }

        public object DeleteProducts(int Productsid)
        {
            try
            {
                if (Productsid == 0)
                {
                    finalreturnModel.Message = "id is required";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }
                var Remove = _appDbContext.Domains.Where(X => X.Id == Productsid).FirstOrDefault();
                if (Remove != null)
                {
                    _appDbContext.Remove(Remove);
                    _appDbContext.SaveChanges();
                    finalreturnModel.Success = true;
                    return finalreturnModel;
                }
                else
                {
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }


            }
            catch (System.Exception ex)
            {
                finalreturnModel.Message = ex.Message;
                if (ex.InnerException != null)
                    finalreturnModel.Message = finalreturnModel.Message + "\n" + ex.InnerException.Message.ToString();

                finalreturnModel.Success = false;
                return finalreturnModel;
            }

        }

        public object AddUpdateIndustryGroup(Industryreq addnew)
        {
            try
            {
                if (addnew.Name == null)
                {
                    finalreturnModel.Message = "name not found";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }
                if (addnew.Id != 0)
                {
                    var id = addnew.Id;
                    var IsExist = _appDbContext.IndustryGroup.Where(x => x.Id == id && x.IsDeleted == false).FirstOrDefault();
                    if (IsExist != null)
                    {
                        IsExist.Name = addnew.Name;
                        IsExist.Description = addnew.Description;
                        IsExist.ModifiedBy = addnew.UserId;
                        //IsExist.ModifiedAt = DateTime.Now;
                        //IsExist.PublicId = addnew.PublicId;
                        _appDbContext.SaveChanges();
                        finalreturnModel.Message = "Update successfully";
                        finalreturnModel.Success = true;
                        return finalreturnModel;
                    }
                    else
                    {
                        finalreturnModel.Message = "Id not found";
                        finalreturnModel.Success = false;
                        return finalreturnModel;
                    }

                }
                else
                {
                    var Exist = _appDbContext.IndustryGroup.Where(x => x.Name == addnew.Name && x.IsDeleted == false).FirstOrDefault();
                    if (Exist == null)
                    {
                        IndustryGroup newclass = new IndustryGroup();
                        newclass.Name = addnew.Name;
                        newclass.Description = addnew.Description;
                        newclass.CreatedBy = addnew.UserId;
                        newclass.CreatedAt = DateTime.Now;
                        Guid newguid = new Guid();
                        newclass.PublicId = Guid.NewGuid();
                        //newclass.ModifiedAt = DateTime.Now;
                        //newclass.PublicId = addnew.PublicId;
                        _appDbContext.IndustryGroup.Add(newclass);
                        _appDbContext.SaveChanges();
                        finalreturnModel.Message = "add suceesfully";
                        finalreturnModel.Success = true;
                        return finalreturnModel;
                    }
                    else
                    {
                        finalreturnModel.Message = "allready exist";
                        finalreturnModel.Success = false;
                        return finalreturnModel;
                    }
                }


            }
            catch (System.Exception ex)
            {
                finalreturnModel.Message = ex.Message;
                if (ex.InnerException != null)
                    finalreturnModel.Message = finalreturnModel.Message + "\n" + ex.InnerException.Message.ToString();

                finalreturnModel.Success = false;
                return finalreturnModel;
            }
        }
        public object DeleteIndustryGroup(int Industryid)
        {
            try
            {
                if (Industryid == 0)
                {
                    finalreturnModel.Message = "id is required";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }
                var Remove = _appDbContext.IndustryGroup.Where(X => X.Id == Industryid).FirstOrDefault();
                if (Remove != null)
                {
                    _appDbContext.Remove(Remove);
                    _appDbContext.SaveChanges();
                    finalreturnModel.Success = true;
                    return finalreturnModel;
                }
                else
                {
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }


            }
            catch (System.Exception ex)
            {
                finalreturnModel.Message = ex.Message;
                if (ex.InnerException != null)
                    finalreturnModel.Message = finalreturnModel.Message + "\n" + ex.InnerException.Message.ToString();

                finalreturnModel.Success = false;
                return finalreturnModel;
            }

        }

        public object AddUpdateService(Servicereq addnew)
        {
            try
            {
                if (addnew.Name == null)
                {
                    finalreturnModel.Message = "name not found";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }
                if (addnew.Id != 0)
                {
                    var id = addnew.Id;
                    var IsExist = _appDbContext.Service.Where(x => x.Id == id && x.IsDeleted == false).FirstOrDefault();
                    if (IsExist != null)
                    {
                        IsExist.Name = addnew.Name;
                        IsExist.Description = addnew.Description;
                        IsExist.ModifiedBy = addnew.UserId;
                        //IsExist.ModifiedAt = DateTime.Now;
                        //IsExist.PublicId = addnew.PublicId;
                        _appDbContext.SaveChanges();
                        finalreturnModel.Message = "Update successfully";
                        finalreturnModel.Success = true;
                        return finalreturnModel;
                    }
                    else
                    {
                        finalreturnModel.Message = "Id not found";
                        finalreturnModel.Success = false;
                        return finalreturnModel;
                    }

                }
                else
                {
                    var Exist = _appDbContext.Service.Where(x => x.Name == addnew.Name && x.IsDeleted == false).FirstOrDefault();
                    if (Exist == null)
                    {
                        Service newclass = new Service();
                        newclass.Name = addnew.Name;
                        newclass.Description = addnew.Description;
                        newclass.CreatedBy = addnew.UserId;
                        newclass.CreatedAt = DateTime.Now;
                        Guid newguid = new Guid();
                        newclass.PublicId = Guid.NewGuid();
                        //newclass.ModifiedAt = DateTime.Now;
                        //newclass.PublicId = addnew.PublicId;
                        _appDbContext.Service.Add(newclass);
                        _appDbContext.SaveChanges();
                        finalreturnModel.Message = "add suceesfully";
                        finalreturnModel.Success = true;
                        return finalreturnModel;
                    }
                    else
                    {
                        finalreturnModel.Message = "allready exist";
                        finalreturnModel.Success = false;
                        return finalreturnModel;
                    }
                }


            }
            catch (System.Exception ex)
            {
                finalreturnModel.Message = ex.Message;
                if (ex.InnerException != null)
                    finalreturnModel.Message = finalreturnModel.Message + "\n" + ex.InnerException.Message.ToString();

                finalreturnModel.Success = false;
                return finalreturnModel;
            }
        }

        public object DeleteService(int Serviceid)
        {
            try
            {
                if (Serviceid == 0)
                {
                    finalreturnModel.Message = "id is required";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }
                var Remove = _appDbContext.Service.Where(X => X.Id == Serviceid).FirstOrDefault();
                if (Remove != null)
                {
                    _appDbContext.Remove(Remove);
                    _appDbContext.SaveChanges();
                    finalreturnModel.Success = true;
                    return finalreturnModel;
                }
                else
                {
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }


            }
            catch (System.Exception ex)
            {
                finalreturnModel.Message = ex.Message;
                if (ex.InnerException != null)
                    finalreturnModel.Message = finalreturnModel.Message + "\n" + ex.InnerException.Message.ToString();

                finalreturnModel.Success = false;
                return finalreturnModel;
            }

        }

        public object AddUpdateProcess(Processreq addnew)
        {
            try
            {
                if (addnew.Name == null)
                {
                    finalreturnModel.Message = "name not found";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }
                if (addnew.Id != 0)
                {
                    var id = addnew.Id;
                    var IsExist = _appDbContext.Process.Where(x => x.Id == id && x.IsDeleted == false).FirstOrDefault();
                    if (IsExist != null)
                    {
                        IsExist.Name = addnew.Name;
                        IsExist.Description = addnew.Description;
                        IsExist.ModifiedBy = addnew.UserId;
                        //IsExist.ModifiedAt = DateTime.Now;
                        //IsExist.PublicId = addnew.PublicId;
                        _appDbContext.SaveChanges();
                        finalreturnModel.Message = "Update successfully";
                        finalreturnModel.Success = true;
                        return finalreturnModel;
                    }
                    else
                    {
                        finalreturnModel.Message = "Id not found";
                        finalreturnModel.Success = false;
                        return finalreturnModel;
                    }

                }
                else
                {
                    var Exist = _appDbContext.Process.Where(x => x.Name == addnew.Name && x.IsDeleted == false).FirstOrDefault();
                    if (Exist == null)
                    {
                        Process newclass = new Process();
                        newclass.Name = addnew.Name;
                        newclass.Description = addnew.Description;
                        newclass.CreatedBy = addnew.UserId;
                        newclass.CreatedAt = DateTime.Now;
                        Guid newguid = new Guid();
                        newclass.PublicId = Guid.NewGuid();
                        //newclass.ModifiedAt = DateTime.Now;
                        //newclass.PublicId = addnew.PublicId;
                        _appDbContext.Process.Add(newclass);
                        _appDbContext.SaveChanges();
                        finalreturnModel.Message = "add suceesfully";
                        finalreturnModel.Success = true;
                        return finalreturnModel;
                    }
                    else
                    {
                        finalreturnModel.Message = "allready exist";
                        finalreturnModel.Success = false;
                        return finalreturnModel;
                    }
                }


            }
            catch (System.Exception ex)
            {
                finalreturnModel.Message = ex.Message;
                if (ex.InnerException != null)
                    finalreturnModel.Message = finalreturnModel.Message + "\n" + ex.InnerException.Message.ToString();

                finalreturnModel.Success = false;
                return finalreturnModel;
            }
        }

        public object DeleteProcess(int Processid)
        {
            try
            {
                if (Processid == 0)
                {
                    finalreturnModel.Message = "id is required";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }
                var Remove = _appDbContext.Process.Where(X => X.Id == Processid).FirstOrDefault();
                if (Remove != null)
                {
                    _appDbContext.Remove(Remove);
                    _appDbContext.SaveChanges();
                    finalreturnModel.Success = true;
                    return finalreturnModel;
                }
                else
                {
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }


            }
            catch (System.Exception ex)
            {
                finalreturnModel.Message = ex.Message;
                if (ex.InnerException != null)
                    finalreturnModel.Message = finalreturnModel.Message + "\n" + ex.InnerException.Message.ToString();

                finalreturnModel.Success = false;
                return finalreturnModel;
            }

        }

        public object AddUpdateToolandTechnologies(techreq addnew)
        {
            try
            {
                if (addnew.Name == null)
                {
                    finalreturnModel.Message = "name not found";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }
                if (addnew.Id != 0)
                {
                    var id = addnew.Id;
                    var IsExist = _appDbContext.ToolandtechTechnologies.Where(x => x.Id == id && x.IsDeleted == false).FirstOrDefault();
                    if (IsExist != null)
                    {
                        IsExist.Name = addnew.Name;
                        IsExist.Description = addnew.Description;
                        IsExist.ModifiedBy = addnew.UserId;
                        //IsExist.ModifiedAt = DateTime.Now;
                        //IsExist.PublicId = addnew.PublicId;
                        _appDbContext.SaveChanges();
                        finalreturnModel.Message = "Update successfully";
                        finalreturnModel.Success = true;
                        return finalreturnModel;
                    }
                    else
                    {
                        finalreturnModel.Message = "Id not found";
                        finalreturnModel.Success = false;
                        return finalreturnModel;
                    }

                }
                else
                {
                    var Exist = _appDbContext.ToolandtechTechnologies.Where(x => x.Name == addnew.Name && x.IsDeleted == false).FirstOrDefault();
                    if (Exist == null)
                    {
                        ToolandtechTechnologies newclass = new ToolandtechTechnologies();
                        newclass.Name = addnew.Name;
                        newclass.Description = addnew.Description;
                        newclass.CreatedBy = addnew.UserId;
                        newclass.CreatedAt = DateTime.Now;
                        Guid newguid = new Guid();
                        newclass.PublicId = Guid.NewGuid();
                        //newclass.ModifiedAt = DateTime.Now;
                        //newclass.PublicId = addnew.PublicId;
                        _appDbContext.ToolandtechTechnologies.Add(newclass);
                        _appDbContext.SaveChanges();
                        finalreturnModel.Message = "add suceesfully";
                        finalreturnModel.Success = true;
                        return finalreturnModel;
                    }
                    else
                    {
                        finalreturnModel.Message = "allready exist";
                        finalreturnModel.Success = false;
                        return finalreturnModel;
                    }
                }


            }
            catch (System.Exception ex)
            {
                finalreturnModel.Message = ex.Message;
                if (ex.InnerException != null)
                    finalreturnModel.Message = finalreturnModel.Message + "\n" + ex.InnerException.Message.ToString();

                finalreturnModel.Success = false;
                return finalreturnModel;
            }
        }

        public object DeleteToolTechnologies(int tooltechid)
        {
            try
            {
                if (tooltechid == 0)
                {
                    finalreturnModel.Message = "id is required";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }
                var Remove = _appDbContext.ToolandtechTechnologies.Where(X => X.Id == tooltechid).FirstOrDefault();
                if (Remove != null)
                {
                    _appDbContext.Remove(Remove);
                    _appDbContext.SaveChanges();
                    finalreturnModel.Success = true;
                    return finalreturnModel;
                }
                else
                {
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }


            }
            catch (System.Exception ex)
            {
                finalreturnModel.Message = ex.Message;
                if (ex.InnerException != null)
                    finalreturnModel.Message = finalreturnModel.Message + "\n" + ex.InnerException.Message.ToString();

                finalreturnModel.Success = false;
                return finalreturnModel;
            }

        }

        public object AddUpdateFunctionalAreas(functionalreq addnew)
        {
            try
            {
                if (addnew.Name == null)
                {
                    finalreturnModel.Message = "name not found";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }
                if (addnew.Id != 0)
                {
                    var id = addnew.Id;
                    var IsExist = _appDbContext.FunctionalAreas.Where(x => x.Id == id && x.IsDeleted == false).FirstOrDefault();
                    if (IsExist != null)
                    {
                        IsExist.Name = addnew.Name;
                        IsExist.Description = addnew.Description;
                        IsExist.ModifiedBy = addnew.UserId;
                        //IsExist.ModifiedAt = DateTime.Now;
                        //IsExist.PublicId = addnew.PublicId;
                        _appDbContext.SaveChanges();
                        finalreturnModel.Message = "Update successfully";
                        finalreturnModel.Success = true;
                        return finalreturnModel;
                    }
                    else
                    {
                        finalreturnModel.Message = "Id not found";
                        finalreturnModel.Success = false;
                        return finalreturnModel;
                    }

                }
                else
                {
                    var Exist = _appDbContext.FunctionalAreas.Where(x => x.Name == addnew.Name && x.IsDeleted == false).FirstOrDefault();
                    if (Exist == null)
                    {
                        FunctionalAreas newclass = new FunctionalAreas();
                        newclass.Name = addnew.Name;
                        newclass.Description = addnew.Description;
                        newclass.CreatedBy = addnew.UserId;
                        newclass.CreatedAt = DateTime.Now;
                        Guid newguid = new Guid();
                        newclass.PublicId = Guid.NewGuid();
                        //newclass.ModifiedAt = DateTime.Now;
                        //newclass.PublicId = addnew.PublicId;
                        _appDbContext.FunctionalAreas.Add(newclass);
                        _appDbContext.SaveChanges();
                        finalreturnModel.Message = "add suceesfully";
                        finalreturnModel.Success = true;
                        return finalreturnModel;
                    }
                    else
                    {
                        finalreturnModel.Message = "allready exist";
                        finalreturnModel.Success = false;
                        return finalreturnModel;
                    }
                }


            }
            catch (System.Exception ex)
            {
                finalreturnModel.Message = ex.Message;
                if (ex.InnerException != null)
                    finalreturnModel.Message = finalreturnModel.Message + "\n" + ex.InnerException.Message.ToString();

                finalreturnModel.Success = false;
                return finalreturnModel;
            }
        }

        public object DeleteFunctionalAreas(int functionalareaid)
        {
            try
            {
                if (functionalareaid == 0)
                {
                    finalreturnModel.Message = "id is required";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }
                var Remove = _appDbContext.FunctionalAreas.Where(X => X.Id == functionalareaid).FirstOrDefault();
                if (Remove != null)
                {
                    _appDbContext.Remove(Remove);
                    _appDbContext.SaveChanges();
                    finalreturnModel.Success = true;
                    return finalreturnModel;
                }
                else
                {
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }


            }
            catch (System.Exception ex)
            {
                finalreturnModel.Message = ex.Message;
                if (ex.InnerException != null)
                    finalreturnModel.Message = finalreturnModel.Message + "\n" + ex.InnerException.Message.ToString();

                finalreturnModel.Success = false;
                return finalreturnModel;
            }

        }

        public object AddUpdateSubFunctional(subfuncreq addnew)
        {
            try
            {
                if (addnew.Name == null)
                {
                    finalreturnModel.Message = "name not found";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }
                if (addnew.Id != 0)
                {
                    var id = addnew.Id;
                    var IsExist = _appDbContext.SubFunctionalAreas.Where(x => x.Id == id && x.IsDeleted == false).FirstOrDefault();
                    if (IsExist != null)
                    {
                        IsExist.Name = addnew.Name;
                        IsExist.Description = addnew.Description;
                        IsExist.ModifiedBy = addnew.UserId;
                        //IsExist.ModifiedAt = DateTime.Now;
                        //IsExist.PublicId = addnew.PublicId;
                        _appDbContext.SaveChanges();
                        finalreturnModel.Message = "Update successfully";
                        finalreturnModel.Success = true;
                        return finalreturnModel;
                    }
                    else
                    {
                        finalreturnModel.Message = "Id not found";
                        finalreturnModel.Success = false;
                        return finalreturnModel;
                    }

                }
                else
                {
                    var Exist = _appDbContext.SubFunctionalAreas.Where(x => x.Name == addnew.Name && x.IsDeleted == false).FirstOrDefault();
                    if (Exist == null)
                    {
                        SubFunctionalAreas newclass = new SubFunctionalAreas();
                        newclass.Name = addnew.Name;
                        newclass.Description = addnew.Description;
                        newclass.CreatedBy = addnew.UserId;
                        newclass.CreatedAt = DateTime.Now;
                        Guid newguid = new Guid();
                        newclass.PublicId = Guid.NewGuid();
                        //newclass.ModifiedAt = DateTime.Now;
                        //newclass.PublicId = addnew.PublicId;
                        _appDbContext.SubFunctionalAreas.Add(newclass);
                        _appDbContext.SaveChanges();
                        finalreturnModel.Message = "add suceesfully";
                        finalreturnModel.Success = true;
                        return finalreturnModel;
                    }
                    else
                    {
                        finalreturnModel.Message = "allready exist";
                        finalreturnModel.Success = false;
                        return finalreturnModel;
                    }
                }


            }
            catch (System.Exception ex)
            {
                finalreturnModel.Message = ex.Message;
                if (ex.InnerException != null)
                    finalreturnModel.Message = finalreturnModel.Message + "\n" + ex.InnerException.Message.ToString();

                finalreturnModel.Success = false;
                return finalreturnModel;
            }
        }

        public object DeleteSubFunctionalAreas(int subfunctionalareaid)
        {
            try
            {
                if (subfunctionalareaid == 0)
                {
                    finalreturnModel.Message = "id is required";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }
                var Remove = _appDbContext.SubFunctionalAreas.Where(X => X.Id == subfunctionalareaid).FirstOrDefault();
                if (Remove != null)
                {
                    _appDbContext.Remove(Remove);
                    _appDbContext.SaveChanges();
                    finalreturnModel.Success = true;
                    return finalreturnModel;
                }
                else
                {
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }


            }
            catch (System.Exception ex)
            {
                finalreturnModel.Message = ex.Message;
                if (ex.InnerException != null)
                    finalreturnModel.Message = finalreturnModel.Message + "\n" + ex.InnerException.Message.ToString();

                finalreturnModel.Success = false;
                return finalreturnModel;
            }

        }


        public object AddUpdateSuperFunctional(supfunreq addnew)
        {
            try
            {
                if (addnew.Name == null)
                {
                    finalreturnModel.Message = "name not found";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }
                if (addnew.Id != 0)
                {
                    var id = addnew.Id;
                    var IsExist = _appDbContext.SuperFunctionalAreas.Where(x => x.Id == id && x.IsDeleted == false).FirstOrDefault();
                    if (IsExist != null)
                    {
                        IsExist.Name = addnew.Name;
                        IsExist.Description = addnew.Description;
                        IsExist.ModifiedBy = addnew.UserId;
                        //IsExist.ModifiedAt = DateTime.Now;
                        //IsExist.PublicId = addnew.PublicId;
                        _appDbContext.SaveChanges();
                        finalreturnModel.Message = "Update successfully";
                        finalreturnModel.Success = true;
                        return finalreturnModel;
                    }
                    else
                    {
                        finalreturnModel.Message = "Id not found";
                        finalreturnModel.Success = false;
                        return finalreturnModel;
                    }

                }
                else
                {
                    var Exist = _appDbContext.SubFunctionalAreas.Where(x => x.Name == addnew.Name && x.IsDeleted == false).FirstOrDefault();
                    if (Exist == null)
                    {
                        SuperFunctionalAreas newclass = new SuperFunctionalAreas();
                        newclass.Name = addnew.Name;
                        newclass.Description = addnew.Description;
                        newclass.CreatedBy = addnew.UserId;
                        newclass.CreatedAt = DateTime.Now;
                        Guid newguid = new Guid();
                        newclass.PublicId = Guid.NewGuid();
                        //newclass.ModifiedAt = DateTime.Now;
                        //newclass.PublicId = addnew.PublicId;
                        _appDbContext.SuperFunctionalAreas.Add(newclass);
                        _appDbContext.SaveChanges();
                        finalreturnModel.Message = "add suceesfully";
                        finalreturnModel.Success = true;
                        return finalreturnModel;
                    }
                    else
                    {
                        finalreturnModel.Message = "allready exist";
                        finalreturnModel.Success = false;
                        return finalreturnModel;
                    }
                }


            }
            catch (System.Exception ex)
            {
                finalreturnModel.Message = ex.Message;
                if (ex.InnerException != null)
                    finalreturnModel.Message = finalreturnModel.Message + "\n" + ex.InnerException.Message.ToString();

                finalreturnModel.Success = false;
                return finalreturnModel;
            }
        }

        public object DeleteSuperFunctionalAreas(int superfunctionalareaid)
        {
            try
            {
                if (superfunctionalareaid == 0)
                {
                    finalreturnModel.Message = "id is required";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }
                var Remove = _appDbContext.SuperFunctionalAreas.Where(X => X.Id == superfunctionalareaid).FirstOrDefault();
                if (Remove != null)
                {
                    _appDbContext.Remove(Remove);
                    _appDbContext.SaveChanges();
                    finalreturnModel.Success = true;
                    return finalreturnModel;
                }
                else
                {
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }


            }
            catch (System.Exception ex)
            {
                finalreturnModel.Message = ex.Message;
                if (ex.InnerException != null)
                    finalreturnModel.Message = finalreturnModel.Message + "\n" + ex.InnerException.Message.ToString();

                finalreturnModel.Success = false;
                return finalreturnModel;
            }

        }

        public object AddCompanyIndustryClassRelation(IndustryClassRelation add)
        {
            var Addnew = _appDbContext.IndustryClassRelation.Where(x => x.Id == add.Id).FirstOrDefault();
            if (Addnew == null)
            {
                IndustryClassRelation newGrade = new IndustryClassRelation();
                newGrade.IndustryID = add.IndustryID;
                newGrade.ClassificationID = add.ClassificationID;

                _appDbContext.IndustryClassRelation.Add(newGrade);
                _appDbContext.SaveChanges();

                finalreturnModel.Message = " add successfully";
                finalreturnModel.Success = true;
                return finalreturnModel;
            }
            else
            {
                finalreturnModel.Message = "allready exist";
                finalreturnModel.Success = false;
                return finalreturnModel;
            }
        }

        public object AddClassSubClassRelation(ClassificationSubclassificationRelation add)
        {
            var Addnew = _appDbContext.ClassificationSubclassificationRelation.Where(x => x.Id == add.Id).FirstOrDefault();
            if (Addnew == null)
            {
                ClassificationSubclassificationRelation newGrade = new ClassificationSubclassificationRelation();
                newGrade.ClasssificationId = add.ClasssificationId;
                newGrade.SubClassificationId = add.SubClassificationId;
               
                _appDbContext.ClassificationSubclassificationRelation.Add(newGrade);
                _appDbContext.SaveChanges();

                finalreturnModel.Message = " add successfully";
                finalreturnModel.Success = true;
                return finalreturnModel;
            }
            else
            {
                finalreturnModel.Message = "allready exist";
                finalreturnModel.Success = false;
                return finalreturnModel;
            }
        }


        public object AddSupclassSuperclassRelation(SubClassificationSuperClasiificationRelation add)
        {
            var Addnew = _appDbContext.SubClassificationSuperClasiificationRelation.Where(x => x.Id == add.Id).FirstOrDefault();
            if (Addnew == null)
            {
                SubClassificationSuperClasiificationRelation newGrade = new SubClassificationSuperClasiificationRelation();
                newGrade.SuperClassificationID = add.SuperClassificationID;
                newGrade.SubClassificationId = add.SubClassificationId;

                _appDbContext.SubClassificationSuperClasiificationRelation.Add(newGrade);
                _appDbContext.SaveChanges();

                finalreturnModel.Message = " add successfully";
                finalreturnModel.Success = true;
                return finalreturnModel;
            }
            else
            {
                finalreturnModel.Message = "allready exist";
                finalreturnModel.Success = false;
                return finalreturnModel;
            }
        }

        public object DeleteSupclassSuperclassRelation(int id)
        {
            try
            {
                if (id == 0)
                {
                    finalreturnModel.Message = "id is required";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }
                var Remove = _appDbContext.SubClassificationSuperClasiificationRelation.Where(X => X.Id == id).FirstOrDefault();
                if (Remove != null)
                {
                    _appDbContext.Remove(Remove);
                    _appDbContext.SaveChanges();
                    finalreturnModel.Success = true;
                    return finalreturnModel;
                }
                else
                {
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }


            }
            catch (System.Exception ex)
            {
                finalreturnModel.Message = ex.Message;
                if (ex.InnerException != null)
                    finalreturnModel.Message = finalreturnModel.Message + "\n" + ex.InnerException.Message.ToString();

                finalreturnModel.Success = false;
                return finalreturnModel;
            }

        }



        public object DeleteClassSubClassRelation(int id)
        {
            try
            {
                if (id == 0)
                {
                    finalreturnModel.Message = "id is required";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }
                var Remove = _appDbContext.ClassificationSubclassificationRelation.Where(X => X.Id == id).FirstOrDefault();
                if (Remove != null)
                {
                    _appDbContext.Remove(Remove);
                    _appDbContext.SaveChanges();
                    finalreturnModel.Success = true;
                    return finalreturnModel;
                }
                else
                {
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }


            }
            catch (System.Exception ex)
            {
                finalreturnModel.Message = ex.Message;
                if (ex.InnerException != null)
                    finalreturnModel.Message = finalreturnModel.Message + "\n" + ex.InnerException.Message.ToString();

                finalreturnModel.Success = false;
                return finalreturnModel;
            }

        }

        public object DeleteIndustryClassRelation(int id)
        {
            try
            {
                if (id == 0)
                {
                    finalreturnModel.Message = "id is required";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }
                var Remove = _appDbContext.IndustryClassRelation.Where(X => X.Id == id).FirstOrDefault();
                if (Remove != null)
                {
                    _appDbContext.Remove(Remove);
                    _appDbContext.SaveChanges();
                    finalreturnModel.Success = true;
                    return finalreturnModel;
                }
                else
                {
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }


            }
            catch (System.Exception ex)
            {
                finalreturnModel.Message = ex.Message;
                if (ex.InnerException != null)
                    finalreturnModel.Message = finalreturnModel.Message + "\n" + ex.InnerException.Message.ToString();

                finalreturnModel.Success = false;
                return finalreturnModel;
            }

        }

        public object GetIndustryClassRelation()
        {
            var product = (from e in _appDbContext.IndustryClassRelation
                           join u in _appDbContext.Industries on e.Id equals u.Id into deptGroup
                           from u in deptGroup.DefaultIfEmpty()
                           join um in _appDbContext.Classification on e.Id equals um.Id into deptmGroup
                           from um in deptmGroup.DefaultIfEmpty()
                           select new
                           {
                               e.Id,
                             

                               
                               IndustryId = u.Id,
                               ClassificationId = um.Id,
                              
                               //Users = u != null ? u.USerName: null
                           }).FirstOrDefault();
            //var data = product.AsQueryable();
            //var datanew = data.OrderByDescending(x => x.ModifiedAt).ToList();
            finalreturnModel.Success = true;
            return (product);
        }


        public object AddUpdateComapnyProcessRelation(CompanyProcess add)
        {
            try
            {
                if (add.Id == 0)
                {
                    finalreturnModel.Message = "Id is Required";
                  
                }

                if (add.Id != 0)
                {
                    var processId = add.ProcessId;
                    foreach (var item in processId)
                    {
                        var IsExist = _appDbContext.ComapnyProcessRelation.Where(x => x.Id == add.Id && x.ProcessId == item).FirstOrDefault();
                        if (IsExist != null)
                        {
                            IsExist.ComapnyId = add.CompanyId;
                            IsExist.ProcessId = item;

                            _appDbContext.SaveChanges();


                        }
                        else
                        {
                            finalreturnModel.Message = "Id not found";
                            finalreturnModel.Success = false;
                            return finalreturnModel;
                        }
                    }
                    finalreturnModel.Message = "update successfully";
                    finalreturnModel.Success = true;
                    return finalreturnModel;
                }

                else
                {
                    var tId = add.ProcessId;
                    foreach (var item in tId)
                    {
                        var Exist = _appDbContext.ComapnyProcessRelation.Where(x => x.ComapnyId == add.CompanyId && x.ProcessId == item).FirstOrDefault();
                        if (Exist == null)
                        {
                            ComapnyProcessRelation newGrade = new ComapnyProcessRelation();
                            newGrade.ComapnyId = add.CompanyId;
                            newGrade.ProcessId = item;
                            _appDbContext.ComapnyProcessRelation.Add(newGrade);
                            _appDbContext.SaveChanges();

                           
                        }
                        else
                        {
                            finalreturnModel.Message = "Allready exist";
                            finalreturnModel.Success = false;
                            return finalreturnModel;
                        }
                    }
                    finalreturnModel.Message = " add successfully";
                    finalreturnModel.Success = true;
                    return finalreturnModel;


                }
                


            }
            catch (System.Exception ex)
            {
                finalreturnModel.Message = ex.Message;
                if (ex.InnerException != null)
                    finalreturnModel.Message = finalreturnModel.Message + "\n" + ex.InnerException.Message.ToString();

                finalreturnModel.Success = false;
                return finalreturnModel;
            }
        }

        public object GetCompanyProcess()
        {
            var product = (from e in _appDbContext.ComapnyProcessRelation
                           join u in _appDbContext.Companies on e.ComapnyId equals u.CompanyId into deptGroup
                           from u in deptGroup.DefaultIfEmpty()
                           join um in _appDbContext.Process on e.ProcessId equals um.Id into deptmGroup
                           from um in deptmGroup.DefaultIfEmpty()
                           select new
                           {
                               e.Id,
                               e.ComapnyId,
                               e.ProcessId

                           }).ToList();
            finalreturnModel.Success = true;
            return (product);
        }

        public object DeleteCompanyProcess(int id)
        {
            try
            {
                if (id == 0)
                {
                    finalreturnModel.Message = "id is required";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }
                var Remove = _appDbContext.ComapnyProcessRelation.Where(X => X.Id == id).FirstOrDefault();
                if (Remove != null)
                {
                    _appDbContext.Remove(Remove);
                    _appDbContext.SaveChanges();
                    finalreturnModel.Success = true;
                    return finalreturnModel;
                }
                else
                {
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }


            }
            catch (System.Exception ex)
            {
                finalreturnModel.Message = ex.Message;
                if (ex.InnerException != null)
                    finalreturnModel.Message = finalreturnModel.Message + "\n" + ex.InnerException.Message.ToString();

                finalreturnModel.Success = false;
                return finalreturnModel;
            }

        }

        public object AddUpdateComapnyToolandtech(ComapnyTooltech add)
        {
            try
            {
                if (add.Id == 0)
                {
                    finalreturnModel.Message = "Id is Required";
                   
                }

                if (add.Id != 0)
                {
                    var toolId = add.ToolandTechId;
                    foreach (var item in toolId)
                    {
                        var IsExist = _appDbContext.CompanyToolandtechnologies.Where(x => x.Id == add.Id && x.ToolandTechId == item).FirstOrDefault();
                        if (IsExist != null)
                        {
                            IsExist.CompanyId = add.CompanyId;
                            IsExist.ToolandTechId = item;

                            _appDbContext.SaveChanges();


                        }
                        else
                        {
                            finalreturnModel.Message = "Id not found";
                            finalreturnModel.Success = false;
                            return finalreturnModel;
                        }
                    }
                    finalreturnModel.Message = "update successfully";
                    finalreturnModel.Success = true;
                    return finalreturnModel;
                }

                else
                {
                    var tId = add.ToolandTechId;
                    foreach (var item in tId)
                    {
                        var Exist = _appDbContext.CompanyToolandtechnologies.Where(x => x.CompanyId == add.CompanyId && x.ToolandTechId == item).FirstOrDefault();
                        if (Exist == null)
                        {
                            CompanyToolandtechnologies newGrade = new CompanyToolandtechnologies();
                            newGrade.CompanyId = add.CompanyId;
                            newGrade.ToolandTechId = item;
                            _appDbContext.CompanyToolandtechnologies.Add(newGrade);
                            _appDbContext.SaveChanges();
                            finalreturnModel.Message = " add successfully";
                            finalreturnModel.Success = true;
                            return finalreturnModel;
                        }
                    }
                    finalreturnModel.Message = "allready exist";
                    finalreturnModel.Success = false;
                    return finalreturnModel;

                }


            }
            catch (System.Exception ex)
            {
                finalreturnModel.Message = ex.Message;
                if (ex.InnerException != null)
                    finalreturnModel.Message = finalreturnModel.Message + "\n" + ex.InnerException.Message.ToString();

                finalreturnModel.Success = false;
                return finalreturnModel;
            }
        }


        public object GetCompanyToolandTech()
        {
            var product = (from e in _appDbContext.CompanyToolandtechnologies
                           join u in _appDbContext.Companies on e.CompanyId equals u.CompanyId into deptGroup
                           from u in deptGroup.DefaultIfEmpty()
                           join um in _appDbContext.ToolandtechTechnologies on e.ToolandTechId equals um.Id into deptmGroup
                           from um in deptmGroup.DefaultIfEmpty()                         
                           select new
                           {
                               e.Id,
                               e.CompanyId,
                             
                               e.ToolandTechId,
                               

                           }).ToList();
            
            return (product);
        }

        public object DeleteCompanyTollandTech(int id)
        {
            try
            {
                if (id == 0)
                {
                    finalreturnModel.Message = "id is required";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }
                var Remove = _appDbContext.CompanyToolandtechnologies.Where(X => X.Id == id).FirstOrDefault();
                if (Remove != null)
                {
                    _appDbContext.Remove(Remove);
                    _appDbContext.SaveChanges();
                    finalreturnModel.Success = true;
                    return finalreturnModel;
                }
                else
                {
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }


            }
            catch (System.Exception ex)
            {
                finalreturnModel.Message = ex.Message;
                if (ex.InnerException != null)
                    finalreturnModel.Message = finalreturnModel.Message + "\n" + ex.InnerException.Message.ToString();

                finalreturnModel.Success = false;
                return finalreturnModel;
            }

        }

        public object AddUpdateJob(Jobs addnew)
        {
            try
            {
                if (addnew.UserId == 0)
                {
                    finalreturnModel.Message = "id is Required";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }
                if (addnew.Id != 0)
                {
                    var jobId = addnew.Id;
                    var IsExist = _appDbContext.Job.Where(x => x.Id == jobId).FirstOrDefault();
                    if (IsExist != null)
                    {
                        IsExist.Name = addnew.Name;
                        IsExist.Description = addnew.Description;
                        IsExist.ModifiedAt = DateTime.Now;
                        IsExist.ModifiedBy = addnew.UserId;
                        //IsExist.CreatedAt = DateTime.Now;

                        _appDbContext.SaveChanges();

                        finalreturnModel.Message = "update successfully";
                        finalreturnModel.Success = true;
                        return finalreturnModel;
                    }
                    else
                    {
                        finalreturnModel.Message = "Id not found";
                        finalreturnModel.Success = false;
                        return finalreturnModel;
                    }

                }
                else
                {
                    var Exist = _appDbContext.Job.Where(x => x.Name == addnew.Name).FirstOrDefault();
                    if (Exist == null)
                    {
                       Job newGrade = new Job();
                        newGrade.Name = addnew.Name;
                        newGrade.Description = addnew.Description;
                        newGrade.CreatedAt = DateTime.Now;
                        newGrade.CreatedBy = addnew.UserId;
                        //newGrade.ModifiedAt = DateTime.Now;
                       _appDbContext.Job.Add(newGrade);
                        _appDbContext.SaveChanges();

                        finalreturnModel.Message = " add successfully";
                        finalreturnModel.Success = true;
                        return finalreturnModel;
                    }
                    else
                    {
                        finalreturnModel.Message = "allready exist";
                        finalreturnModel.Success = false;
                        return finalreturnModel;
                    }
                }


            }
            catch (System.Exception ex)
            {
                finalreturnModel.Message = ex.Message;
                if (ex.InnerException != null)
                    finalreturnModel.Message = finalreturnModel.Message + "\n" + ex.InnerException.Message.ToString();

                finalreturnModel.Success = false;
                return finalreturnModel;
            }
        }

        //public object Getjobid(int jobid)
        //{
        //    try
        //    {
        //        if (jobid == 0)
        //        {
        //            finalreturnModel.Message = "id is required";
        //            finalreturnModel.Success = false;
        //            return finalreturnModel;
        //        }
        //        var result = (from pt in _appDbContext.Job
        //                      select new
        //                      {
        //                          pt.Id,
        //                          pt.Name,pt.Description,
        //                      });

        //        if (result == null)
        //        {
        //            finalreturnModel.Message = "Data not found!";
        //            finalreturnModel.Success = true;
        //            return finalreturnModel;
        //        }
        //        else
        //        {
        //            return result;
        //        }

        //    }
        //    catch (System.Exception ex)
        //    {
        //        finalreturnModel.Message = ex.Message;
        //        if (ex.InnerException != null)
        //            finalreturnModel.Message = finalreturnModel.Message + "\n" + ex.InnerException.Message.ToString();

        //        finalreturnModel.Success = false;
        //        return finalreturnModel;
        //    }

        //}

        public object GetJob()
        {
            var product = (from e in _appDbContext.Job
                           join u in _appDbContext.Users on e.CreatedBy equals u.UserId into deptGroup
                           from u in deptGroup.DefaultIfEmpty()
                           join um in _appDbContext.Users on e.ModifiedBy equals um.UserId into deptmGroup
                           from um in deptmGroup.DefaultIfEmpty()
                           select new
                           {
                               e.Id,
                               e.Name,
                               e.Description,
                               ModifiedByName = um.UserName,
                               CreatedByName = u.UserName,
                               e.ModifiedAt,
                               //Users = u != null ? u.USerName: null
                           }).ToList();
            var data = product.AsQueryable();
            var datanew = data.OrderByDescending(x => x.ModifiedAt).ToList();
            finalreturnModel.Success = true;
            return (datanew);
        }



        public object DeleteJob(int jobid)
        {
            try
            {
                if (jobid == 0)
                {
                    finalreturnModel.Message = "id is required";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }
                var Remove = _appDbContext.Job.Where(X => X.Id == jobid).FirstOrDefault();
                if (Remove != null)
                {
                    _appDbContext.Remove(Remove);
                    _appDbContext.SaveChanges();
                    finalreturnModel.Success = true;
                    return finalreturnModel;
                }
                else
                {
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }


            }
            catch (System.Exception ex)
            {
                finalreturnModel.Message = ex.Message;
                if (ex.InnerException != null)
                    finalreturnModel.Message = finalreturnModel.Message + "\n" + ex.InnerException.Message.ToString();

                finalreturnModel.Success = false;
                return finalreturnModel;
            }
        }

        public object AddUpdateFunctionalSubfunctional(FunctionalSubFunctional add)
        {
            try
            {
                if (add.Id == 0)
                {
                    finalreturnModel.Message = "Id is Required";
                    //finalreturnModel.Success = false;
                    //return finalreturnModel;

                }
                
                
                if (add.Id != 0)
                {
                    var subFunctionId = add.SubfunctionalId;
                    foreach(var item in subFunctionId)
                    {
                        var IsExist = _appDbContext.FunctionalSubRelational.Where(x => x.Id == add.Id && x.SubfunctionalId == item ).FirstOrDefault();
                        if (IsExist != null)
                        {
                            IsExist.FunctionalId = add.FunctionalId;
                            IsExist.SubfunctionalId = item;

                            _appDbContext.SaveChanges();

                            
                        }
                        else
                        {
                            finalreturnModel.Message = "Id not found";
                            finalreturnModel.Success = false;
                            return finalreturnModel;
                        }
                    }
                    finalreturnModel.Message = "update successfully";
                    finalreturnModel.Success = true;
                    return finalreturnModel;
                }
                else
                {
                    var tId = add.SubfunctionalId;
                    foreach (var item in tId)
                    {
                        var Exist = _appDbContext.FunctionalSubRelational.Where(x => x.FunctionalId == add.FunctionalId && x.SubfunctionalId == item).FirstOrDefault();
                        if (Exist == null)
                        {
                            FunctionalSubRelational newGrade = new FunctionalSubRelational();
                            newGrade.FunctionalId = add.FunctionalId;
                            newGrade.SubfunctionalId = item;
                            _appDbContext.FunctionalSubRelational.Add(newGrade);
                            _appDbContext.SaveChanges();

                            //finalreturnModel.Message = " add successfully";
                            //finalreturnModel.Success = true;
                            //return finalreturnModel;
                        }
                        
                    }
                    finalreturnModel.Message = " add successfully";
                    finalreturnModel.Success = true;
                    return finalreturnModel;

                }


            }
            catch (System.Exception ex)
            {
                finalreturnModel.Message = ex.Message;
                if (ex.InnerException != null)
                    finalreturnModel.Message = finalreturnModel.Message + "\n" + ex.InnerException.Message.ToString();

                finalreturnModel.Success = false;
                return finalreturnModel;
            }
        }

        public object GetFunctionalSubfunctional()
        {
            var product = (from e in _appDbContext.FunctionalSubRelational
                           join u in _appDbContext.FunctionalAreas on e.FunctionalId equals u.Id into deptGroup
                           from u in deptGroup.DefaultIfEmpty()
                           join um in _appDbContext.SubFunctionalAreas on e.SubfunctionalId equals um.Id into deptmGroup
                           from um in deptmGroup.DefaultIfEmpty()
                           select new
                           {
                               e.Id,
                               e.FunctionalId,

                               e.SubfunctionalId,


                           }).ToList();

            return (product);
        }

        public object DeleteFunctionalsubfunctional(int id)
        {
            try
            {
                if (id == 0)
                {
                    finalreturnModel.Message = "id is required";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }
                var Remove = _appDbContext.FunctionalSubRelational.Where(X => X.Id == id).FirstOrDefault();
                if (Remove != null)
                {
                    _appDbContext.Remove(Remove);
                    _appDbContext.SaveChanges();
                    finalreturnModel.Success = true;
                    return finalreturnModel;
                }
                else
                {
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }


            }
            catch (System.Exception ex)
            {
                finalreturnModel.Message = ex.Message;
                if (ex.InnerException != null)
                    finalreturnModel.Message = finalreturnModel.Message + "\n" + ex.InnerException.Message.ToString();

                finalreturnModel.Success = false;
                return finalreturnModel;
            }

        }


        public object AddUpdateSubFunctionalSuperfunctional(SubfunctionalSuperfunctional add)
        {
            try
            {
                if (add.SubfunctionalId == 0)
                {
                    finalreturnModel.Message = "Id is Required";
                  
                }

                if (add.Id != 0)
                {
                    var superfunctionId = add.SuperfunctionalId;
                    foreach (var item in superfunctionId)
                    {
                        var IsExist = _appDbContext.SubFunctionalSuperRelational.Where(x => x.Id == add.Id && x.SuperfunctionalId == item).FirstOrDefault();
                        if (IsExist != null)
                        {
                            IsExist.SubfunctionalId = add.SubfunctionalId;
                            IsExist.SuperfunctionalId = item;

                            _appDbContext.SaveChanges();


                        }
                        else
                        {
                            finalreturnModel.Message = "Id not found";
                            finalreturnModel.Success = false;
                            return finalreturnModel;
                        }
                    }
                    finalreturnModel.Message = "update successfully";
                    finalreturnModel.Success = true;
                    return finalreturnModel;
                }

                else
                {
                    var tId = add.SuperfunctionalId;
                    foreach (var item in tId)
                    {
                        var Exist = _appDbContext.SubFunctionalSuperRelational.Where(x => x.SubfunctionalId == add.SubfunctionalId && x.SuperfunctionalId == item).FirstOrDefault();
                        if (Exist == null)
                        {
                            SubFunctionalSuperRelational  newGrade = new SubFunctionalSuperRelational();
                            newGrade.SubfunctionalId = add.SubfunctionalId;
                            newGrade.SuperfunctionalId = item;
                            _appDbContext.SubFunctionalSuperRelational.Add(newGrade);
                            _appDbContext.SaveChanges();
                            finalreturnModel.Message = " add successfully";
                            finalreturnModel.Success = true;
                            return finalreturnModel;
                        }
                    }
                    finalreturnModel.Message = "allready exist";
                    finalreturnModel.Success = false;
                    return finalreturnModel;

                }


            }
            catch (System.Exception ex)
            {
                finalreturnModel.Message = ex.Message;
                if (ex.InnerException != null)
                    finalreturnModel.Message = finalreturnModel.Message + "\n" + ex.InnerException.Message.ToString();

                finalreturnModel.Success = false;
                return finalreturnModel;
            }
        }


        public object GetSubFunctionalSuperfunctional()
        {
            var product = (from e in _appDbContext.SubFunctionalSuperRelational
                           join u in _appDbContext.SuperFunctionalAreas on e.SuperfunctionalId equals u.Id into deptGroup
                           from u in deptGroup.DefaultIfEmpty()
                           join um in _appDbContext.SubFunctionalAreas on e.SubfunctionalId equals um.Id into deptmGroup
                           from um in deptmGroup.DefaultIfEmpty()
                           select new
                           {
                               e.Id,
                               e.SuperfunctionalId,

                               e.SubfunctionalId,


                           }).ToList();

            return (product);
        }

        public object DeleteSubFunctionalsuperfunctional(int id)
        {
            try
            {
                if (id == 0)
                {
                    finalreturnModel.Message = "id is required";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }
                var Remove = _appDbContext.SubFunctionalSuperRelational.Where(X => X.Id == id).FirstOrDefault();
                if (Remove != null)
                {
                    _appDbContext.Remove(Remove);
                    _appDbContext.SaveChanges();
                    finalreturnModel.Success = true;
                    return finalreturnModel;
                }
                else
                {
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }


            }
            catch (System.Exception ex)
            {
                finalreturnModel.Message = ex.Message;
                if (ex.InnerException != null)
                    finalreturnModel.Message = finalreturnModel.Message + "\n" + ex.InnerException.Message.ToString();

                finalreturnModel.Success = false;
                return finalreturnModel;
            }

        }

        public object AddUpdateFunctionalJob(FunctionalJob add)
        {
            try
            {
                if (add.FunctionalId == 0)
                {
                    finalreturnModel.Message = "Id is Required";
                   
                }

                if (add.Id != 0)
                {
                    var jobId = add.JobId;
                    foreach (var item in jobId)
                    {
                        var IsExist = _appDbContext.FunctionalJobRelational.Where(x => x.Id == add.Id && x.JobId == item).FirstOrDefault();
                        if (IsExist != null)
                        {
                            IsExist.FunctionalId = add.FunctionalId;
                            IsExist.JobId = item;

                            _appDbContext.SaveChanges();


                        }
                        else
                        {
                            finalreturnModel.Message = "Id not found";
                            finalreturnModel.Success = false;
                            return finalreturnModel;
                        }
                    }
                    finalreturnModel.Message = "update successfully";
                    finalreturnModel.Success = true;
                    return finalreturnModel;
                }

                else
                {
                    var tId = add.JobId;
                    foreach (var item in tId)
                    {
                        var Exist = _appDbContext.FunctionalJobRelational.Where(x => x.FunctionalId == add.FunctionalId && x.JobId == item).FirstOrDefault();
                        if (Exist == null)
                        {
                            FunctionalJobRelational newGrade = new FunctionalJobRelational();
                            newGrade.FunctionalId = add.FunctionalId;
                            newGrade.JobId = item;
                            _appDbContext.FunctionalJobRelational.Add(newGrade);
                            _appDbContext.SaveChanges();
                            finalreturnModel.Message = " add successfully";
                            finalreturnModel.Success = true;
                            return finalreturnModel;
                        }
                    }
                    finalreturnModel.Message = "allready exist";
                    finalreturnModel.Success = false;
                    return finalreturnModel;

                }


            }
            catch (System.Exception ex)
            {
                finalreturnModel.Message = ex.Message;
                if (ex.InnerException != null)
                    finalreturnModel.Message = finalreturnModel.Message + "\n" + ex.InnerException.Message.ToString();

                finalreturnModel.Success = false;
                return finalreturnModel;
            }
        }

        public object GetFunctionalJobrelational()
        {
            var product = (from e in _appDbContext.FunctionalJobRelational
                           join u in _appDbContext.FunctionalAreas on e.FunctionalId equals u.Id into deptGroup
                           from u in deptGroup.DefaultIfEmpty()
                           join um in _appDbContext.Job on e.JobId equals um.Id into deptmGroup
                           from um in deptmGroup.DefaultIfEmpty()
                           select new
                           {
                               e.Id,
                               e.FunctionalId,

                               e.JobId,


                           }).ToList();

            return (product);
        }



        public object DeleteFunctionalJob(int id)
        {
            try
            {
                if (id == 0)
                {
                    finalreturnModel.Message = "id is required";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }
                var Remove = _appDbContext.FunctionalJobRelational.Where(X => X.Id == id).FirstOrDefault();
                if (Remove != null)
                {
                    _appDbContext.Remove(Remove);
                    _appDbContext.SaveChanges();
                    finalreturnModel.Success = true;
                    return finalreturnModel;
                }
                else
                {
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }


            }
            catch (System.Exception ex)
            {
                finalreturnModel.Message = ex.Message;
                if (ex.InnerException != null)
                    finalreturnModel.Message = finalreturnModel.Message + "\n" + ex.InnerException.Message.ToString();

                finalreturnModel.Success = false;
                return finalreturnModel;
            }

        }


        //upload excel file 

        public async Task<object> UploadAllMastersExcelSheetAsync(UploadExcelSheetViewModel ReqExcelFile)
        {
            try
            {
                var Data = new List<MapedColumm>();
                if (ReqExcelFile.ExcelFile != null && ReqExcelFile.ExcelFile.Length > 0)
                {
                    var fileInfo = new FileInfo(ReqExcelFile.ExcelFile.FileName);

                    if (fileInfo.Extension != ".xlsx")
                    {
                        finalreturnModel.Message = "Select Excel (.xlsx) File!";
                        finalreturnModel.Success = false;
                        return finalreturnModel;
                    }
                    var fileName = "Master_" + Guid.NewGuid() + fileInfo.Extension;
                    var uploadDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Uploads", "Masters", "ImportHistory");
                    if (!Directory.Exists(uploadDirectory))
                    {
                        Directory.CreateDirectory(uploadDirectory);
                    }

                    var filePath = Path.Combine(uploadDirectory, fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                    {
                        await ReqExcelFile.ExcelFile.CopyToAsync(stream);
                    }
                    using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
                    {
                        System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                        IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream);
                        DataSet dataSet = reader.AsDataSet(
                            configuration: new ExcelExcelDataSetConfiguation()
                            {

                                UseColumnDataType = false,
                                ConfigureDataTable = (IExcelDataReader) => new ExcelDataTableConfiguration()
                                {
                                    UseHeaderRow = true
                                }

                            });

                        var dataBaseEntities = new List<string>
                         {
                            "Name","Description"
                         };

                        List<string> Csv_Column = new List<string>();
                        var ColumnIndex = new List<Csv_Column>();
                        var EmptyRow = reader.RowCount;
                        for (int t = 0; t < EmptyRow; t++)
                        {
                            var hederRow = dataSet.Tables[0].Rows[t];
                            if (hederRow.Table.Rows != null)
                            {
                                for (int i = 0; i < hederRow.ItemArray.Length; i++)
                                {
                                    string columnHeader = hederRow.ItemArray[i]?.ToString() ?? "";
                                    Csv_Column column = new Csv_Column();
                                    column.IndexName = columnHeader;
                                    column.IndexValue = i;
                                    ColumnIndex.Add(column);
                                }
                                for (int i = 0; i < dataBaseEntities.Count; i++)
                                {
                                    var currentDbEntity = dataBaseEntities[i];
                                    bool isConditionMet = false;
                                    foreach (var item in ColumnIndex)
                                    {
                                        if (item.IndexName == currentDbEntity)
                                        {
                                            //var myDictinary = new Dictionary<string, string>();
                                            MapedColumm mapedColumn = new MapedColumm();
                                            mapedColumn.csv_column = item.IndexName;
                                            mapedColumn.csv_columnIndexId = item.IndexValue;
                                            mapedColumn.entity_column = currentDbEntity;
                                            mapedColumn.entity_column_label = currentDbEntity;

                                            Data.Add(mapedColumn);
                                            isConditionMet = true;
                                        }
                                    }
                                    if (isConditionMet == false)
                                    {
                                        //var myDictinary = new Dictionary<string, string>();
                                        MapedColumm mapedColumn = new MapedColumm();
                                        mapedColumn.csv_column = "";
                                        mapedColumn.csv_columnIndexId = null;
                                        mapedColumn.entity_column = currentDbEntity;
                                        mapedColumn.entity_column_label = currentDbEntity;
                                        Data.Add(mapedColumn);

                                    }
                                }
                                stream.Position = 0;
                                return new { CsvColumn = ColumnIndex, mappedCcolumn = Data, excelFile = fileName };
                                
                            }
                        }
                    }
                    return false;

                }
                else
                {
                    finalreturnModel.Message = "Select excel file first!";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }
            }
            catch (Exception ex)
            {
                finalreturnModel.Message = "An error occurred while processing the file.";
                finalreturnModel.Message += $"\nError: {ex.Message}";
                if (ex.InnerException != null)
                    finalreturnModel.Message += $"\nInner Error: {ex.InnerException.Message}";

                // Log the exception (use a logging framework)
                //_appDbContext.LogError(ex, "File upload error");

                finalreturnModel.Success = false;
                return finalreturnModel;
            }


        }

        public async Task<object> ImportClassification(importdatanew MapedField)
        {
            try
            {
                if (MapedField.File.FileName == null)
                {
                    finalreturnModel.Message = "File not found!";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }
                if (MapedField == null)
                {
                    finalreturnModel.Message = "Model can not be null!";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }
                if (MapedField.importmasters.NameIndexId == null)
                {
                    finalreturnModel.Message = "Required field not maped!";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }
                if (MapedField.importmasters.Name == "")
                {
                    finalreturnModel.Message = "masters field not maped!";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }
                if (MapedField.importmasters.Name == "string")
                {
                    finalreturnModel.Message = "masters field not maped!";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }

                int SkipedMasters = 0;
                //int ImportedMasters = 0;
                int Overwritemasters = 0;

                var filePatth = GetFilePath1(MapedField.File.FileName); //Common.
                var Provider = new FileExtensionContentTypeProvider();
                if (!Provider.TryGetContentType(filePatth, out var _contentType))
                {
                    _contentType = "application/octet-stream";

                }
                var _ReadAllBytesAsync = await File.ReadAllBytesAsync(filePatth);
                var data = (_ReadAllBytesAsync, _contentType, Path.GetFileName(filePatth));

                FileStream stream = new FileStream(filePatth, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream);
                DataSet dataSet = reader.AsDataSet(
                    configuration: new ExcelExcelDataSetConfiguation()
                    {

                        UseColumnDataType = false,
                        ConfigureDataTable = (IExcelDataReader) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true
                        }

                    });
                var count = reader.RowCount;
                while (reader.Read())
                {
                    var ExcelFieldCount1 = reader.FieldCount;
                    for (int n = 0; n < ExcelFieldCount1; n++)
                    {
                        var ExcelRowColumnisNull = (reader.GetValue(n) == null) ? null : reader.GetValue(n).ToString();
                        if (ExcelRowColumnisNull != null)
                        {
                            for (int i = 0; i < count; i++)
                            {
                                if (i == n)
                                {
                                    var finalMappedColumnsIndex = new List<Dictionary<string, int>>();
                                    var ExcelFieldCount = reader.FieldCount;
                                    for (int f = 0; f < ExcelFieldCount; f++)
                                    {
                                        var ExcelColumn = (reader.GetValue(f) == null) ? null : reader.GetValue(f).ToString();
                                        var myDictinary = new Dictionary<string, int>();
                                        myDictinary.Add(ExcelColumn, f);
                                        finalMappedColumnsIndex.Add(myDictinary);
                                    }
                                    int NameIndex = -1;
                                    int DescriptionIndex = -1;

                                    foreach (var item in finalMappedColumnsIndex)
                                    {
                                        #region Cheak Columns
                                        if (item.ContainsKey(MapedField.importmasters.Name))
                                        {
                                            NameIndex = item["Name"];
                                        }
                                        else if (item.ContainsKey(MapedField.importmasters.Description))
                                        {
                                            DescriptionIndex = item["Description"];
                                        }
                                        #endregion
                                    }
                                    while (reader.Read())

                                    {
                                        #region Insert Date In DataBase
                                        var ExcelRowColumnisNull1 = (reader.GetValue(n) == null) ? null : reader.GetValue(n).ToString();
                                        if (ExcelRowColumnisNull1 == null)
                                        {



                                        }
                                        var field = reader;
                                       Classification  ImportMaster = new Classification();

                                        var IsnullMaster = (reader.GetValue(NameIndex) == null) ? null : reader.GetValue(NameIndex).ToString();
                                        if (IsnullMaster!= null)
                                        {
                                            var ExistMaster = _appDbContext.Classification.Where(x => x.IsDeleted == false && x.Name == IsnullMaster).FirstOrDefault();
                                            if (ExistMaster == null)
                                            {


                                                if (NameIndex != -1)
                                                {
                                                    var Com = (reader.GetValue(NameIndex) == null) ? null : reader.GetValue(NameIndex).ToString();
                                                    if (Com != null)
                                                    {
                                                        ImportMaster.Name = (reader.GetValue(NameIndex) == null) ? null : reader.GetValue(NameIndex).ToString();
                                                    }
                                                    if (DescriptionIndex != -1)
                                                    {
                                                        ImportMaster.Description = (reader.GetValue(DescriptionIndex) == null) ? null : reader.GetValue(DescriptionIndex).ToString();
                                                    }
                                                    ImportMaster.IsDeleted = false;
                                                    ImportMaster.CreatedAt = DateTime.Now;
                                                    ImportMaster.PublicId = Guid.NewGuid();
                                                    ImportMaster.CreatedBy = (long)MapedField.File.CreatedBy;
                                                    _appDbContext.Classification.Add(ImportMaster);
                                                    _appDbContext.SaveChanges();
                                                }
                                                
                                            }
                                            else if (MapedField.File.SkipDuplicate == true)
                                            {
                                                var MasterId = ExistMaster.Id;
                                                if (NameIndex != -1)
                                                {

                                                    var UpdateMaster = _appDbContext.Classification.Where(x => x.IsDeleted == false && x.Id == MasterId).FirstOrDefault();
                                                    if (UpdateMaster != null)
                                                    {
                                                        UpdateMaster.Name = (reader.GetValue(NameIndex) == null) ? null : reader.GetValue(NameIndex).ToString();
                                                        //ImportCompany.RegistrationNo = (reader.GetValue(RegistrationNoIndex) == null) ? null : reader.GetValue(RegistrationNoIndex).ToString();
                                                        if (NameIndex != -1)
                                                        {
                                                            var name = reader.GetValue(NameIndex);
                                                            if (name != "")
                                                            {

                                                                if (UpdateMaster.Name == null)
                                                                {
                                                                    UpdateMaster.Name = (reader.GetValue(NameIndex) == null) ? null : reader.GetValue(NameIndex).ToString();
                                                                }

                                                            }

                                                        }
                                                        if (DescriptionIndex != -1)
                                                        {
                                                            var desr = reader.GetValue(DescriptionIndex);
                                                            if (desr != "")
                                                            {
                                                                if (UpdateMaster.Description == null)
                                                                {
                                                                    UpdateMaster.Name = (reader.GetValue(NameIndex) == null) ? null : reader.GetValue(NameIndex).ToString();
                                                                }
                                                            }



                                                        }
                                                        UpdateMaster.IsDeleted = false;
                                                        UpdateMaster.ModifiedAt = DateTime.Now;
                                                        UpdateMaster.PublicId = Guid.NewGuid();
                                                        UpdateMaster.ModifiedBy = MapedField.File.CreatedBy;
                                                        await _appDbContext.SaveChangesAsync();

                                                        SkipedMasters = SkipedMasters + 1;

                                                    }

                                                }
                                            }
                                            else if (MapedField.File.OverwriteDuplicate == true)
                                            {
                                                var MasterId = ExistMaster.Id;
                                                if (NameIndex != -1)
                                                {
                                                    var UpdateMaster = _appDbContext.Classification.Where(x => x.IsDeleted == false && x.Id == MasterId).FirstOrDefault();
                                                    if (UpdateMaster != null)
                                                    {
                                                        var Com = (reader.GetValue(NameIndex) == null) ? null : reader.GetValue(NameIndex).ToString();
                                                        if (Com != null)
                                                        {
                                                            UpdateMaster.Name = (reader.GetValue(NameIndex) == null) ? null : reader.GetValue(NameIndex).ToString();
                                                            //ImportCompany.RegistrationNo = (reader.GetValue(RegistrationNoIndex) == null) ? null : reader.GetValue(RegistrationNoIndex).ToString();
                                                            if (DescriptionIndex != -1)
                                                            {
                                                                var regsi = reader.GetValue(DescriptionIndex);
                                                                if (regsi != "")
                                                                {
                                                                    UpdateMaster.Description = (reader.GetValue(DescriptionIndex) == null) ? null : reader.GetValue(DescriptionIndex).ToString();
                                                                }

                                                            }
                                                            UpdateMaster.IsDeleted = false;
                                                            UpdateMaster.PublicId = Guid.NewGuid();
                                                            UpdateMaster.ModifiedAt = DateTime.Now;
                                                            UpdateMaster.ModifiedBy = MapedField.File.CreatedBy;
                                                            await _appDbContext.SaveChangesAsync();

                                                            Overwritemasters = Overwritemasters + 1;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        #endregion
                                    }
                                    while (reader.NextResult()) ;
                                   
                                }
                               

                            }
                            #region Maitain Import History
                            // to maintain excel sheet history                  
                            //ImportHistory addnew = new ImportHistory();
                            //addnew.ImportedAt = DateTime.Now;
                            //addnew.ImportedBy = MapedField.File.CreatedBy;
                            //addnew.FilePath = filePatth;
                            ////addnew.ExcelFileName = MapedField.File.FileName.Trim(0,_).;
                            //addnew.ModuleId = 3;
                            //addnew.ExcelNameBySystem = MapedField.File.FileName;
                            //_appDbContext.ImportHistory.Add(addnew);
                            //_appDbContext.SaveChanges();
                            #endregion

                            finalreturnModel.Message = "Masters Imported Successfully!";
                            finalreturnModel.Success = true;
                        }
                        return finalreturnModel;
                    }
                   
                }
                while (reader.NextResult()) ;

                finalreturnModel.Message = "Something went wrong!";
                finalreturnModel.Success = false;
                return finalreturnModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<object> ImportSubClassification(importdatanew MapedField)
        {
            try
            {
                if (MapedField.File.FileName == null)
                {
                    finalreturnModel.Message = "File not found!";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }
                if (MapedField == null)
                {
                    finalreturnModel.Message = "Model can not be null!";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }
                if (MapedField.importmasters.NameIndexId == null)
                {
                    finalreturnModel.Message = "Required field not maped!";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }
                if (MapedField.importmasters.Name == "")
                {
                    finalreturnModel.Message = "masters field not maped!";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }
                if (MapedField.importmasters.Name == "string")
                {
                    finalreturnModel.Message = "masters field not maped!";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }

                int SkipedMasters = 0;
                //int ImportedMasters = 0;
                int Overwritemasters = 0;

                var filePatth = GetFilePath1(MapedField.File.FileName); //Common.
                var Provider = new FileExtensionContentTypeProvider();
                if (!Provider.TryGetContentType(filePatth, out var _contentType))
                {
                    _contentType = "application/octet-stream";

                }
                var _ReadAllBytesAsync = await File.ReadAllBytesAsync(filePatth);
                var data = (_ReadAllBytesAsync, _contentType, Path.GetFileName(filePatth));

                FileStream stream = new FileStream(filePatth, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream);
                DataSet dataSet = reader.AsDataSet(
                    configuration: new ExcelExcelDataSetConfiguation()
                    {

                        UseColumnDataType = false,
                        ConfigureDataTable = (IExcelDataReader) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true
                        }

                    });
                var count = reader.RowCount;
                while (reader.Read())
                {
                    var ExcelFieldCount1 = reader.FieldCount;
                    for (int n = 0; n < ExcelFieldCount1; n++)
                    {
                        var ExcelRowColumnisNull = (reader.GetValue(n) == null) ? null : reader.GetValue(n).ToString();
                        if (ExcelRowColumnisNull != null)
                        {
                            for (int i = 0; i < count; i++)
                            {
                                if (i == n)
                                {
                                    var finalMappedColumnsIndex = new List<Dictionary<string, int>>();
                                    var ExcelFieldCount = reader.FieldCount;
                                    for (int f = 0; f < ExcelFieldCount; f++)
                                    {
                                        var ExcelColumn = (reader.GetValue(f) == null) ? null : reader.GetValue(f).ToString();
                                        var myDictinary = new Dictionary<string, int>();
                                        myDictinary.Add(ExcelColumn, f);
                                        finalMappedColumnsIndex.Add(myDictinary);
                                    }
                                    int NameIndex = -1;
                                    int DescriptionIndex = -1;

                                    foreach (var item in finalMappedColumnsIndex)
                                    {
                                        #region Cheak Columns
                                        if (item.ContainsKey(MapedField.importmasters.Name))
                                        {
                                            NameIndex = item["Name"];
                                        }
                                        else if (item.ContainsKey(MapedField.importmasters.Description))
                                        {
                                            DescriptionIndex = item["Description"];
                                        }
                                        #endregion
                                    }
                                    while (reader.Read())

                                    {
                                        #region Insert Date In DataBase
                                        var ExcelRowColumnisNull1 = (reader.GetValue(n) == null) ? null : reader.GetValue(n).ToString();
                                        if (ExcelRowColumnisNull1 == null)
                                        {



                                        }
                                        var field = reader;
                                        SubClassification ImportMaster = new SubClassification();

                                        var IsnullMaster = (reader.GetValue(NameIndex) == null) ? null : reader.GetValue(NameIndex).ToString();
                                        if (IsnullMaster != null)
                                        {
                                            var ExistMaster = _appDbContext.SubClassification.Where(x => x.IsDeleted == false && x.Name == IsnullMaster).FirstOrDefault();
                                            if (ExistMaster == null)
                                            {


                                                if (NameIndex != -1)
                                                {
                                                    var Com = (reader.GetValue(NameIndex) == null) ? null : reader.GetValue(NameIndex).ToString();
                                                    if (Com != null)
                                                    {
                                                        ImportMaster.Name = (reader.GetValue(NameIndex) == null) ? null : reader.GetValue(NameIndex).ToString();
                                                    }
                                                    if (DescriptionIndex != -1)
                                                    {
                                                        ImportMaster.Description = (reader.GetValue(DescriptionIndex) == null) ? null : reader.GetValue(DescriptionIndex).ToString();
                                                    }
                                                    ImportMaster.IsDeleted = false;
                                                    ImportMaster.CreatedAt = DateTime.Now;
                                                    ImportMaster.PublicId = Guid.NewGuid();
                                                    ImportMaster.CreatedBy = (long)MapedField.File.CreatedBy;
                                                    _appDbContext.SubClassification.Add(ImportMaster);
                                                    _appDbContext.SaveChanges();
                                                }

                                            }
                                            else if (MapedField.File.SkipDuplicate == true)
                                            {
                                                var MasterId = ExistMaster.Id;
                                                if (NameIndex != -1)
                                                {

                                                    var UpdateMaster = _appDbContext.SubClassification.Where(x => x.IsDeleted == false && x.Id == MasterId).FirstOrDefault();
                                                    if (UpdateMaster != null)
                                                    {
                                                        UpdateMaster.Name = (reader.GetValue(NameIndex) == null) ? null : reader.GetValue(NameIndex).ToString();
                                                        //ImportCompany.RegistrationNo = (reader.GetValue(RegistrationNoIndex) == null) ? null : reader.GetValue(RegistrationNoIndex).ToString();
                                                        if (NameIndex != -1)
                                                        {
                                                            var name = reader.GetValue(NameIndex);
                                                            if (name != "")
                                                            {

                                                                if (UpdateMaster.Name == null)
                                                                {
                                                                    UpdateMaster.Name = (reader.GetValue(NameIndex) == null) ? null : reader.GetValue(NameIndex).ToString();
                                                                }

                                                            }

                                                        }
                                                        if (DescriptionIndex != -1)
                                                        {
                                                            var desr = reader.GetValue(DescriptionIndex);
                                                            if (desr != "")
                                                            {
                                                                if (UpdateMaster.Description == null)
                                                                {
                                                                    UpdateMaster.Name = (reader.GetValue(NameIndex) == null) ? null : reader.GetValue(NameIndex).ToString();
                                                                }
                                                            }



                                                        }
                                                        UpdateMaster.IsDeleted = false;
                                                        UpdateMaster.ModifiedAt = DateTime.Now;
                                                        UpdateMaster.PublicId = Guid.NewGuid();
                                                        UpdateMaster.ModifiedBy = MapedField.File.CreatedBy;
                                                        await _appDbContext.SaveChangesAsync();

                                                        SkipedMasters = SkipedMasters + 1;

                                                    }

                                                }
                                            }
                                            else if (MapedField.File.OverwriteDuplicate == true)
                                            {
                                                var MasterId = ExistMaster.Id;
                                                if (NameIndex != -1)
                                                {
                                                    var UpdateMaster = _appDbContext.SubClassification.Where(x => x.IsDeleted == false && x.Id == MasterId).FirstOrDefault();
                                                    if (UpdateMaster != null)
                                                    {
                                                        var Com = (reader.GetValue(NameIndex) == null) ? null : reader.GetValue(NameIndex).ToString();
                                                        if (Com != null)
                                                        {
                                                            UpdateMaster.Name = (reader.GetValue(NameIndex) == null) ? null : reader.GetValue(NameIndex).ToString();
                                                            //ImportCompany.RegistrationNo = (reader.GetValue(RegistrationNoIndex) == null) ? null : reader.GetValue(RegistrationNoIndex).ToString();
                                                            if (DescriptionIndex != -1)
                                                            {
                                                                var regsi = reader.GetValue(DescriptionIndex);
                                                                if (regsi != "")
                                                                {
                                                                    UpdateMaster.Description = (reader.GetValue(DescriptionIndex) == null) ? null : reader.GetValue(DescriptionIndex).ToString();
                                                                }

                                                            }
                                                            UpdateMaster.IsDeleted = false;
                                                            UpdateMaster.PublicId = Guid.NewGuid();
                                                            UpdateMaster.ModifiedAt = DateTime.Now;
                                                            UpdateMaster.ModifiedBy = MapedField.File.CreatedBy;
                                                            await _appDbContext.SaveChangesAsync();

                                                            Overwritemasters = Overwritemasters + 1;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        #endregion
                                    }
                                    while (reader.NextResult()) ;

                                }


                            }
                            #region Maitain Import History
                            // to maintain excel sheet history                  
                            //ImportHistory addnew = new ImportHistory();
                            //addnew.ImportedAt = DateTime.Now;
                            //addnew.ImportedBy = MapedField.File.CreatedBy;
                            //addnew.FilePath = filePatth;
                            ////addnew.ExcelFileName = MapedField.File.FileName.Trim(0,_).;
                            //addnew.ModuleId = 3;
                            //addnew.ExcelNameBySystem = MapedField.File.FileName;
                            //_appDbContext.ImportHistory.Add(addnew);
                            //_appDbContext.SaveChanges();
                            #endregion

                            finalreturnModel.Message = "Masters Imported Successfully!";
                            finalreturnModel.Success = true;
                        }
                        return finalreturnModel;
                    }

                }
                while (reader.NextResult()) ;

                finalreturnModel.Message = "Something went wrong!";
                finalreturnModel.Success = false;
                return finalreturnModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<object> ImportSuperClassification(importdatanew MapedField)
        {
            try
            {
                if (MapedField.File.FileName == null)
                {
                    finalreturnModel.Message = "File not found!";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }
                if (MapedField == null)
                {
                    finalreturnModel.Message = "Model can not be null!";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }
                if (MapedField.importmasters.NameIndexId == null)
                {
                    finalreturnModel.Message = "Required field not maped!";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }
                if (MapedField.importmasters.Name == "")
                {
                    finalreturnModel.Message = "masters field not maped!";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }
                if (MapedField.importmasters.Name == "string")
                {
                    finalreturnModel.Message = "masters field not maped!";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }

                int SkipedMasters = 0;
                //int ImportedMasters = 0;
                int Overwritemasters = 0;

                var filePatth = GetFilePath1(MapedField.File.FileName); //Common.
                var Provider = new FileExtensionContentTypeProvider();
                if (!Provider.TryGetContentType(filePatth, out var _contentType))
                {
                    _contentType = "application/octet-stream";

                }
                var _ReadAllBytesAsync = await File.ReadAllBytesAsync(filePatth);
                var data = (_ReadAllBytesAsync, _contentType, Path.GetFileName(filePatth));

                FileStream stream = new FileStream(filePatth, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream);
                DataSet dataSet = reader.AsDataSet(
                    configuration: new ExcelExcelDataSetConfiguation()
                    {

                        UseColumnDataType = false,
                        ConfigureDataTable = (IExcelDataReader) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true
                        }

                    });
                var count = reader.RowCount;
                while (reader.Read())
                {
                    var ExcelFieldCount1 = reader.FieldCount;
                    for (int n = 0; n < ExcelFieldCount1; n++)
                    {
                        var ExcelRowColumnisNull = (reader.GetValue(n) == null) ? null : reader.GetValue(n).ToString();
                        if (ExcelRowColumnisNull != null)
                        {
                            for (int i = 0; i < count; i++)
                            {
                                if (i == n)
                                {
                                    var finalMappedColumnsIndex = new List<Dictionary<string, int>>();
                                    var ExcelFieldCount = reader.FieldCount;
                                    for (int f = 0; f < ExcelFieldCount; f++)
                                    {
                                        var ExcelColumn = (reader.GetValue(f) == null) ? null : reader.GetValue(f).ToString();
                                        var myDictinary = new Dictionary<string, int>();
                                        myDictinary.Add(ExcelColumn, f);
                                        finalMappedColumnsIndex.Add(myDictinary);
                                    }
                                    int NameIndex = -1;
                                    int DescriptionIndex = -1;

                                    foreach (var item in finalMappedColumnsIndex)
                                    {
                                        #region Cheak Columns
                                        if (item.ContainsKey(MapedField.importmasters.Name))
                                        {
                                            NameIndex = item["Name"];
                                        }
                                        else if (item.ContainsKey(MapedField.importmasters.Description))
                                        {
                                            DescriptionIndex = item["Description"];
                                        }
                                        #endregion
                                    }
                                    while (reader.Read())

                                    {
                                        #region Insert Date In DataBase
                                        var ExcelRowColumnisNull1 = (reader.GetValue(n) == null) ? null : reader.GetValue(n).ToString();
                                        if (ExcelRowColumnisNull1 == null)
                                        {



                                        }
                                        var field = reader;
                                        SuperClassification ImportMaster = new SuperClassification();

                                        var IsnullMaster = (reader.GetValue(NameIndex) == null) ? null : reader.GetValue(NameIndex).ToString();
                                        if (IsnullMaster != null)
                                        {
                                            var ExistMaster = _appDbContext.SuperClassification.Where(x => x.IsDeleted == false && x.Name == IsnullMaster).FirstOrDefault();
                                            if (ExistMaster == null)
                                            {


                                                if (NameIndex != -1)
                                                {
                                                    var Com = (reader.GetValue(NameIndex) == null) ? null : reader.GetValue(NameIndex).ToString();
                                                    if (Com != null)
                                                    {
                                                        ImportMaster.Name = (reader.GetValue(NameIndex) == null) ? null : reader.GetValue(NameIndex).ToString();
                                                    }
                                                    if (DescriptionIndex != -1)
                                                    {
                                                        ImportMaster.Description = (reader.GetValue(DescriptionIndex) == null) ? null : reader.GetValue(DescriptionIndex).ToString();
                                                    }
                                                    ImportMaster.IsDeleted = false;
                                                    ImportMaster.CreatedAt = DateTime.Now;
                                                    ImportMaster.PublicId = Guid.NewGuid();
                                                    ImportMaster.CreatedBy = (long)MapedField.File.CreatedBy;
                                                    _appDbContext.SuperClassification.Add(ImportMaster);
                                                    _appDbContext.SaveChanges();
                                                }

                                            }
                                            else if (MapedField.File.SkipDuplicate == true)
                                            {
                                                var MasterId = ExistMaster.Id;
                                                if (NameIndex != -1)
                                                {

                                                    var UpdateMaster = _appDbContext.SuperClassification.Where(x => x.IsDeleted == false && x.Id == MasterId).FirstOrDefault();
                                                    if (UpdateMaster != null)
                                                    {
                                                        UpdateMaster.Name = (reader.GetValue(NameIndex) == null) ? null : reader.GetValue(NameIndex).ToString();
                                                        //ImportCompany.RegistrationNo = (reader.GetValue(RegistrationNoIndex) == null) ? null : reader.GetValue(RegistrationNoIndex).ToString();
                                                        if (NameIndex != -1)
                                                        {
                                                            var name = reader.GetValue(NameIndex);
                                                            if (name != "")
                                                            {

                                                                if (UpdateMaster.Name == null)
                                                                {
                                                                    UpdateMaster.Name = (reader.GetValue(NameIndex) == null) ? null : reader.GetValue(NameIndex).ToString();
                                                                }

                                                            }

                                                        }
                                                        if (DescriptionIndex != -1)
                                                        {
                                                            var desr = reader.GetValue(DescriptionIndex);
                                                            if (desr != "")
                                                            {
                                                                if (UpdateMaster.Description == null)
                                                                {
                                                                    UpdateMaster.Name = (reader.GetValue(NameIndex) == null) ? null : reader.GetValue(NameIndex).ToString();
                                                                }
                                                            }



                                                        }
                                                        UpdateMaster.IsDeleted = false;
                                                        UpdateMaster.ModifiedAt = DateTime.Now;
                                                        UpdateMaster.PublicId = Guid.NewGuid();
                                                        UpdateMaster.ModifiedBy = MapedField.File.CreatedBy;
                                                        await _appDbContext.SaveChangesAsync();

                                                        SkipedMasters = SkipedMasters + 1;

                                                    }

                                                }
                                            }
                                            else if (MapedField.File.OverwriteDuplicate == true)
                                            {
                                                var MasterId = ExistMaster.Id;
                                                if (NameIndex != -1)
                                                {
                                                    var UpdateMaster = _appDbContext.SuperClassification.Where(x => x.IsDeleted == false && x.Id == MasterId).FirstOrDefault();
                                                    if (UpdateMaster != null)
                                                    {
                                                        var Com = (reader.GetValue(NameIndex) == null) ? null : reader.GetValue(NameIndex).ToString();
                                                        if (Com != null)
                                                        {
                                                            UpdateMaster.Name = (reader.GetValue(NameIndex) == null) ? null : reader.GetValue(NameIndex).ToString();
                                                            //ImportCompany.RegistrationNo = (reader.GetValue(RegistrationNoIndex) == null) ? null : reader.GetValue(RegistrationNoIndex).ToString();
                                                            if (DescriptionIndex != -1)
                                                            {
                                                                var regsi = reader.GetValue(DescriptionIndex);
                                                                if (regsi != "")
                                                                {
                                                                    UpdateMaster.Description = (reader.GetValue(DescriptionIndex) == null) ? null : reader.GetValue(DescriptionIndex).ToString();
                                                                }

                                                            }
                                                            UpdateMaster.IsDeleted = false;
                                                            UpdateMaster.PublicId = Guid.NewGuid();
                                                            UpdateMaster.ModifiedAt = DateTime.Now;
                                                            UpdateMaster.ModifiedBy = MapedField.File.CreatedBy;
                                                            await _appDbContext.SaveChangesAsync();

                                                            Overwritemasters = Overwritemasters + 1;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        #endregion
                                    }
                                    while (reader.NextResult()) ;

                                }


                            }
                            #region Maitain Import History
                            // to maintain excel sheet history                  
                            //ImportHistory addnew = new ImportHistory();
                            //addnew.ImportedAt = DateTime.Now;
                            //addnew.ImportedBy = MapedField.File.CreatedBy;
                            //addnew.FilePath = filePatth;
                            ////addnew.ExcelFileName = MapedField.File.FileName.Trim(0,_).;
                            //addnew.ModuleId = 3;
                            //addnew.ExcelNameBySystem = MapedField.File.FileName;
                            //_appDbContext.ImportHistory.Add(addnew);
                            //_appDbContext.SaveChanges();
                            #endregion

                            finalreturnModel.Message = "Masters Imported Successfully!";
                            finalreturnModel.Success = true;
                        }
                        return finalreturnModel;
                    }

                }
                while (reader.NextResult()) ;

                finalreturnModel.Message = "Something went wrong!";
                finalreturnModel.Success = false;
                return finalreturnModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<object> ImportDomains(importdatanew MapedField)
        {
            try
            {
                if (MapedField.File.FileName == null)
                {
                    finalreturnModel.Message = "File not found!";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }
                if (MapedField == null)
                {
                    finalreturnModel.Message = "Model can not be null!";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }
                if (MapedField.importmasters.NameIndexId == null)
                {
                    finalreturnModel.Message = "Required field not maped!";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }
                if (MapedField.importmasters.Name == "")
                {
                    finalreturnModel.Message = "masters field not maped!";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }
                if (MapedField.importmasters.Name == "string")
                {
                    finalreturnModel.Message = "masters field not maped!";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }

                int SkipedMasters = 0;
                //int ImportedMasters = 0;
                int Overwritemasters = 0;

                var filePatth = GetFilePath1(MapedField.File.FileName); //Common.
                var Provider = new FileExtensionContentTypeProvider();
                if (!Provider.TryGetContentType(filePatth, out var _contentType))
                {
                    _contentType = "application/octet-stream";

                }
                var _ReadAllBytesAsync = await File.ReadAllBytesAsync(filePatth);
                var data = (_ReadAllBytesAsync, _contentType, Path.GetFileName(filePatth));

                FileStream stream = new FileStream(filePatth, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream);
                DataSet dataSet = reader.AsDataSet(
                    configuration: new ExcelExcelDataSetConfiguation()
                    {

                        UseColumnDataType = false,
                        ConfigureDataTable = (IExcelDataReader) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true
                        }

                    });
                var count = reader.RowCount;
                while (reader.Read())
                {
                    var ExcelFieldCount1 = reader.FieldCount;
                    for (int n = 0; n < ExcelFieldCount1; n++)
                    {
                        var ExcelRowColumnisNull = (reader.GetValue(n) == null) ? null : reader.GetValue(n).ToString();
                        if (ExcelRowColumnisNull != null)
                        {
                            for (int i = 0; i < count; i++)
                            {
                                if (i == n)
                                {
                                    var finalMappedColumnsIndex = new List<Dictionary<string, int>>();
                                    var ExcelFieldCount = reader.FieldCount;
                                    for (int f = 0; f < ExcelFieldCount; f++)
                                    {
                                        var ExcelColumn = (reader.GetValue(f) == null) ? null : reader.GetValue(f).ToString();
                                        var myDictinary = new Dictionary<string, int>();
                                        myDictinary.Add(ExcelColumn, f);
                                        finalMappedColumnsIndex.Add(myDictinary);
                                    }
                                    int NameIndex = -1;
                                    int DescriptionIndex = -1;

                                    foreach (var item in finalMappedColumnsIndex)
                                    {
                                        #region Cheak Columns
                                        if (item.ContainsKey(MapedField.importmasters.Name))
                                        {
                                            NameIndex = item["Name"];
                                        }
                                        else if (item.ContainsKey(MapedField.importmasters.Description))
                                        {
                                            DescriptionIndex = item["Description"];
                                        }
                                        #endregion
                                    }
                                    while (reader.Read())

                                    {
                                        #region Insert Date In DataBase
                                        var ExcelRowColumnisNull1 = (reader.GetValue(n) == null) ? null : reader.GetValue(n).ToString();
                                        if (ExcelRowColumnisNull1 == null)
                                        {



                                        }
                                        var field = reader;
                                        Domains ImportMaster = new Domains();

                                        var IsnullMaster = (reader.GetValue(NameIndex) == null) ? null : reader.GetValue(NameIndex).ToString();
                                        if (IsnullMaster != null)
                                        {
                                            var ExistMaster = _appDbContext.Domains.Where(x => x.IsDeleted == false && x.Name == IsnullMaster).FirstOrDefault();
                                            if (ExistMaster == null)
                                            {


                                                if (NameIndex != -1)
                                                {
                                                    var Com = (reader.GetValue(NameIndex) == null) ? null : reader.GetValue(NameIndex).ToString();
                                                    if (Com != null)
                                                    {
                                                        ImportMaster.Name = (reader.GetValue(NameIndex) == null) ? null : reader.GetValue(NameIndex).ToString();
                                                    }
                                                    if (DescriptionIndex != -1)
                                                    {
                                                        ImportMaster.Description = (reader.GetValue(DescriptionIndex) == null) ? null : reader.GetValue(DescriptionIndex).ToString();
                                                    }
                                                    ImportMaster.IsDeleted = false;
                                                    ImportMaster.CreatedAt = DateTime.Now;
                                                    ImportMaster.PublicId = Guid.NewGuid();
                                                    ImportMaster.CreatedBy = (long)MapedField.File.CreatedBy;
                                                    _appDbContext.Domains.Add(ImportMaster);
                                                    _appDbContext.SaveChanges();
                                                }

                                            }
                                            else if (MapedField.File.SkipDuplicate == true)
                                            {
                                                var MasterId = ExistMaster.Id;
                                                if (NameIndex != -1)
                                                {

                                                    var UpdateMaster = _appDbContext.Domains.Where(x => x.IsDeleted == false && x.Id == MasterId).FirstOrDefault();
                                                    if (UpdateMaster != null)
                                                    {
                                                        UpdateMaster.Name = (reader.GetValue(NameIndex) == null) ? null : reader.GetValue(NameIndex).ToString();
                                                        //ImportCompany.RegistrationNo = (reader.GetValue(RegistrationNoIndex) == null) ? null : reader.GetValue(RegistrationNoIndex).ToString();
                                                        if (NameIndex != -1)
                                                        {
                                                            var name = reader.GetValue(NameIndex);
                                                            if (name != "")
                                                            {

                                                                if (UpdateMaster.Name == null)
                                                                {
                                                                    UpdateMaster.Name = (reader.GetValue(NameIndex) == null) ? null : reader.GetValue(NameIndex).ToString();
                                                                }

                                                            }

                                                        }
                                                        if (DescriptionIndex != -1)
                                                        {
                                                            var desr = reader.GetValue(DescriptionIndex);
                                                            if (desr != "")
                                                            {
                                                                if (UpdateMaster.Description == null)
                                                                {
                                                                    UpdateMaster.Name = (reader.GetValue(NameIndex) == null) ? null : reader.GetValue(NameIndex).ToString();
                                                                }
                                                            }



                                                        }
                                                        UpdateMaster.IsDeleted = false;
                                                        UpdateMaster.ModifiedAt = DateTime.Now;
                                                        UpdateMaster.PublicId = Guid.NewGuid();
                                                        UpdateMaster.ModifiedBy = MapedField.File.CreatedBy;
                                                        await _appDbContext.SaveChangesAsync();

                                                        SkipedMasters = SkipedMasters + 1;

                                                    }

                                                }
                                            }
                                            else if (MapedField.File.OverwriteDuplicate == true)
                                            {
                                                var MasterId = ExistMaster.Id;
                                                if (NameIndex != -1)
                                                {
                                                    var UpdateMaster = _appDbContext.Domains.Where(x => x.IsDeleted == false && x.Id == MasterId).FirstOrDefault();
                                                    if (UpdateMaster != null)
                                                    {
                                                        var Com = (reader.GetValue(NameIndex) == null) ? null : reader.GetValue(NameIndex).ToString();
                                                        if (Com != null)
                                                        {
                                                            UpdateMaster.Name = (reader.GetValue(NameIndex) == null) ? null : reader.GetValue(NameIndex).ToString();
                                                            //ImportCompany.RegistrationNo = (reader.GetValue(RegistrationNoIndex) == null) ? null : reader.GetValue(RegistrationNoIndex).ToString();
                                                            if (DescriptionIndex != -1)
                                                            {
                                                                var regsi = reader.GetValue(DescriptionIndex);
                                                                if (regsi != "")
                                                                {
                                                                    UpdateMaster.Description = (reader.GetValue(DescriptionIndex) == null) ? null : reader.GetValue(DescriptionIndex).ToString();
                                                                }

                                                            }
                                                            UpdateMaster.IsDeleted = false;
                                                            UpdateMaster.PublicId = Guid.NewGuid();
                                                            UpdateMaster.ModifiedAt = DateTime.Now;
                                                            UpdateMaster.ModifiedBy = MapedField.File.CreatedBy;
                                                            await _appDbContext.SaveChangesAsync();

                                                            Overwritemasters = Overwritemasters + 1;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        #endregion
                                    }
                                    while (reader.NextResult()) ;

                                }


                            }
                            #region Maitain Import History
                            // to maintain excel sheet history                  
                            //ImportHistory addnew = new ImportHistory();
                            //addnew.ImportedAt = DateTime.Now;
                            //addnew.ImportedBy = MapedField.File.CreatedBy;
                            //addnew.FilePath = filePatth;
                            ////addnew.ExcelFileName = MapedField.File.FileName.Trim(0,_).;
                            //addnew.ModuleId = 3;
                            //addnew.ExcelNameBySystem = MapedField.File.FileName;
                            //_appDbContext.ImportHistory.Add(addnew);
                            //_appDbContext.SaveChanges();
                            #endregion

                            finalreturnModel.Message = "Masters Imported Successfully!";
                            finalreturnModel.Success = true;
                        }
                        return finalreturnModel;
                    }

                }
                while (reader.NextResult()) ;

                finalreturnModel.Message = "Something went wrong!";
                finalreturnModel.Success = false;
                return finalreturnModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<object> ImportIndustry(importdatanew MapedField)
        {
            try
            {
                if (MapedField.File.FileName == null)
                {
                    finalreturnModel.Message = "File not found!";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }
                if (MapedField == null)
                {
                    finalreturnModel.Message = "Model can not be null!";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }
                if (MapedField.importmasters.NameIndexId == null)
                {
                    finalreturnModel.Message = "Required field not maped!";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }
                if (MapedField.importmasters.Name == "")
                {
                    finalreturnModel.Message = "masters field not maped!";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }
                if (MapedField.importmasters.Name == "string")
                {
                    finalreturnModel.Message = "masters field not maped!";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }

                int SkipedMasters = 0;
                //int ImportedMasters = 0;
                int Overwritemasters = 0;

                var filePatth = GetFilePath1(MapedField.File.FileName); //Common.
                var Provider = new FileExtensionContentTypeProvider();
                if (!Provider.TryGetContentType(filePatth, out var _contentType))
                {
                    _contentType = "application/octet-stream";

                }
                var _ReadAllBytesAsync = await File.ReadAllBytesAsync(filePatth);
                var data = (_ReadAllBytesAsync, _contentType, Path.GetFileName(filePatth));

                FileStream stream = new FileStream(filePatth, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream);
                DataSet dataSet = reader.AsDataSet(
                    configuration: new ExcelExcelDataSetConfiguation()
                    {

                        UseColumnDataType = false,
                        ConfigureDataTable = (IExcelDataReader) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true
                        }

                    });
                var count = reader.RowCount;
                while (reader.Read())
                {
                    var ExcelFieldCount1 = reader.FieldCount;
                    for (int n = 0; n < ExcelFieldCount1; n++)
                    {
                        var ExcelRowColumnisNull = (reader.GetValue(n) == null) ? null : reader.GetValue(n).ToString();
                        if (ExcelRowColumnisNull != null)
                        {
                            for (int i = 0; i < count; i++)
                            {
                                if (i == n)
                                {
                                    var finalMappedColumnsIndex = new List<Dictionary<string, int>>();
                                    var ExcelFieldCount = reader.FieldCount;
                                    for (int f = 0; f < ExcelFieldCount; f++)
                                    {
                                        var ExcelColumn = (reader.GetValue(f) == null) ? null : reader.GetValue(f).ToString();
                                        var myDictinary = new Dictionary<string, int>();
                                        myDictinary.Add(ExcelColumn, f);
                                        finalMappedColumnsIndex.Add(myDictinary);
                                    }
                                    int NameIndex = -1;
                                    int DescriptionIndex = -1;

                                    foreach (var item in finalMappedColumnsIndex)
                                    {
                                        #region Cheak Columns
                                        if (item.ContainsKey(MapedField.importmasters.Name))
                                        {
                                            NameIndex = item["Name"];
                                        }
                                        else if (item.ContainsKey(MapedField.importmasters.Description))
                                        {
                                            DescriptionIndex = item["Description"];
                                        }
                                        #endregion
                                    }
                                    while (reader.Read())

                                    {
                                        #region Insert Date In DataBase
                                        var ExcelRowColumnisNull1 = (reader.GetValue(n) == null) ? null : reader.GetValue(n).ToString();
                                        if (ExcelRowColumnisNull1 == null)
                                        {



                                        }
                                        var field = reader;
                                        Industries ImportMaster = new Industries();

                                        var IsnullMaster = (reader.GetValue(NameIndex) == null) ? null : reader.GetValue(NameIndex).ToString();
                                        if (IsnullMaster != null)
                                        {
                                            var ExistMaster = _appDbContext.Industries.Where(x => x.IsDeleted == false && x.Name == IsnullMaster).FirstOrDefault();
                                            if (ExistMaster == null)
                                            {


                                                if (NameIndex != -1)
                                                {
                                                    var Com = (reader.GetValue(NameIndex) == null) ? null : reader.GetValue(NameIndex).ToString();
                                                    if (Com != null)
                                                    {
                                                        ImportMaster.Name = (reader.GetValue(NameIndex) == null) ? null : reader.GetValue(NameIndex).ToString();
                                                    }
                                                    if (DescriptionIndex != -1)
                                                    {
                                                        ImportMaster.Description = (reader.GetValue(DescriptionIndex) == null) ? null : reader.GetValue(DescriptionIndex).ToString();
                                                    }
                                                    ImportMaster.IsDeleted = false;
                                                    ImportMaster.CreatedAt = DateTime.Now;
                                                    ImportMaster.PublicId = Guid.NewGuid();
                                                    ImportMaster.CreatedBy = (long)MapedField.File.CreatedBy;
                                                    _appDbContext.Industries.Add(ImportMaster);
                                                    _appDbContext.SaveChanges();
                                                }

                                            }
                                            else if (MapedField.File.SkipDuplicate == true)
                                            {
                                                var MasterId = ExistMaster.Id;
                                                if (NameIndex != -1)
                                                {

                                                    var UpdateMaster = _appDbContext.Industries.Where(x => x.IsDeleted == false && x.Id == MasterId).FirstOrDefault();
                                                    if (UpdateMaster != null)
                                                    {
                                                        UpdateMaster.Name = (reader.GetValue(NameIndex) == null) ? null : reader.GetValue(NameIndex).ToString();
                                                        //ImportCompany.RegistrationNo = (reader.GetValue(RegistrationNoIndex) == null) ? null : reader.GetValue(RegistrationNoIndex).ToString();
                                                        if (NameIndex != -1)
                                                        {
                                                            var name = reader.GetValue(NameIndex);
                                                            if (name != "")
                                                            {

                                                                if (UpdateMaster.Name == null)
                                                                {
                                                                    UpdateMaster.Name = (reader.GetValue(NameIndex) == null) ? null : reader.GetValue(NameIndex).ToString();
                                                                }

                                                            }

                                                        }
                                                        if (DescriptionIndex != -1)
                                                        {
                                                            var desr = reader.GetValue(DescriptionIndex);
                                                            if (desr != "")
                                                            {
                                                                if (UpdateMaster.Description == null)
                                                                {
                                                                    UpdateMaster.Name = (reader.GetValue(NameIndex) == null) ? null : reader.GetValue(NameIndex).ToString();
                                                                }
                                                            }



                                                        }
                                                        UpdateMaster.IsDeleted = false;
                                                        UpdateMaster.ModifiedAt = DateTime.Now;
                                                        UpdateMaster.PublicId = Guid.NewGuid();
                                                        UpdateMaster.ModifiedBy = MapedField.File.CreatedBy;
                                                        await _appDbContext.SaveChangesAsync();

                                                        SkipedMasters = SkipedMasters + 1;

                                                    }

                                                }
                                            }
                                            else if (MapedField.File.OverwriteDuplicate == true)
                                            {
                                                var MasterId = ExistMaster.Id;
                                                if (NameIndex != -1)
                                                {
                                                    var UpdateMaster = _appDbContext.Industries.Where(x => x.IsDeleted == false && x.Id == MasterId).FirstOrDefault();
                                                    if (UpdateMaster != null)
                                                    {
                                                        var Com = (reader.GetValue(NameIndex) == null) ? null : reader.GetValue(NameIndex).ToString();
                                                        if (Com != null)
                                                        {
                                                            UpdateMaster.Name = (reader.GetValue(NameIndex) == null) ? null : reader.GetValue(NameIndex).ToString();
                                                            //ImportCompany.RegistrationNo = (reader.GetValue(RegistrationNoIndex) == null) ? null : reader.GetValue(RegistrationNoIndex).ToString();
                                                            if (DescriptionIndex != -1)
                                                            {
                                                                var regsi = reader.GetValue(DescriptionIndex);
                                                                if (regsi != "")
                                                                {
                                                                    UpdateMaster.Description = (reader.GetValue(DescriptionIndex) == null) ? null : reader.GetValue(DescriptionIndex).ToString();
                                                                }

                                                            }
                                                            UpdateMaster.IsDeleted = false;
                                                            UpdateMaster.PublicId = Guid.NewGuid();
                                                            UpdateMaster.ModifiedAt = DateTime.Now;
                                                            UpdateMaster.ModifiedBy = MapedField.File.CreatedBy;
                                                            await _appDbContext.SaveChangesAsync();

                                                            Overwritemasters = Overwritemasters + 1;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        #endregion
                                    }
                                    while (reader.NextResult()) ;

                                }


                            }
                            #region Maitain Import History
                            // to maintain excel sheet history                  
                            //ImportHistory addnew = new ImportHistory();
                            //addnew.ImportedAt = DateTime.Now;
                            //addnew.ImportedBy = MapedField.File.CreatedBy;
                            //addnew.FilePath = filePatth;
                            ////addnew.ExcelFileName = MapedField.File.FileName.Trim(0,_).;
                            //addnew.ModuleId = 3;
                            //addnew.ExcelNameBySystem = MapedField.File.FileName;
                            //_appDbContext.ImportHistory.Add(addnew);
                            //_appDbContext.SaveChanges();
                            #endregion

                            finalreturnModel.Message = "Masters Imported Successfully!";
                            finalreturnModel.Success = true;
                        }
                        return finalreturnModel;
                    }

                }
                while (reader.NextResult()) ;

                finalreturnModel.Message = "Something went wrong!";
                finalreturnModel.Success = false;
                return finalreturnModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<object> ImportSubIndustry(importdatanew MapedField)
        {
            try
            {
                if (MapedField.File.FileName == null)
                {
                    finalreturnModel.Message = "File not found!";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }
                if (MapedField == null)
                {
                    finalreturnModel.Message = "Model can not be null!";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }
                if (MapedField.importmasters.NameIndexId == null)
                {
                    finalreturnModel.Message = "Required field not maped!";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }
                if (MapedField.importmasters.Name == "")
                {
                    finalreturnModel.Message = "masters field not maped!";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }
                if (MapedField.importmasters.Name == "string")
                {
                    finalreturnModel.Message = "masters field not maped!";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }

                int SkipedMasters = 0;
                //int ImportedMasters = 0;
                int Overwritemasters = 0;

                var filePatth = GetFilePath1(MapedField.File.FileName); //Common.
                var Provider = new FileExtensionContentTypeProvider();
                if (!Provider.TryGetContentType(filePatth, out var _contentType))
                {
                    _contentType = "application/octet-stream";

                }
                var _ReadAllBytesAsync = await File.ReadAllBytesAsync(filePatth);
                var data = (_ReadAllBytesAsync, _contentType, Path.GetFileName(filePatth));

                FileStream stream = new FileStream(filePatth, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream);
                DataSet dataSet = reader.AsDataSet(
                    configuration: new ExcelExcelDataSetConfiguation()
                    {

                        UseColumnDataType = false,
                        ConfigureDataTable = (IExcelDataReader) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true
                        }

                    });
                var count = reader.RowCount;
                while (reader.Read())
                {
                    var ExcelFieldCount1 = reader.FieldCount;
                    for (int n = 0; n < ExcelFieldCount1; n++)
                    {
                        var ExcelRowColumnisNull = (reader.GetValue(n) == null) ? null : reader.GetValue(n).ToString();
                        if (ExcelRowColumnisNull != null)
                        {
                            for (int i = 0; i < count; i++)
                            {
                                if (i == n)
                                {
                                    var finalMappedColumnsIndex = new List<Dictionary<string, int>>();
                                    var ExcelFieldCount = reader.FieldCount;
                                    for (int f = 0; f < ExcelFieldCount; f++)
                                    {
                                        var ExcelColumn = (reader.GetValue(f) == null) ? null : reader.GetValue(f).ToString();
                                        var myDictinary = new Dictionary<string, int>();
                                        myDictinary.Add(ExcelColumn, f);
                                        finalMappedColumnsIndex.Add(myDictinary);
                                    }
                                    int NameIndex = -1;
                                    int DescriptionIndex = -1;

                                    foreach (var item in finalMappedColumnsIndex)
                                    {
                                        #region Cheak Columns
                                        if (item.ContainsKey(MapedField.importmasters.Name))
                                        {
                                            NameIndex = item["Name"];
                                        }
                                        else if (item.ContainsKey(MapedField.importmasters.Description))
                                        {
                                            DescriptionIndex = item["Description"];
                                        }
                                        #endregion
                                    }
                                    while (reader.Read())

                                    {
                                        #region Insert Date In DataBase
                                        var ExcelRowColumnisNull1 = (reader.GetValue(n) == null) ? null : reader.GetValue(n).ToString();
                                        if (ExcelRowColumnisNull1 == null)
                                        {



                                        }
                                        var field = reader;
                                        SubIndustries ImportMaster = new SubIndustries();

                                        var IsnullMaster = (reader.GetValue(NameIndex) == null) ? null : reader.GetValue(NameIndex).ToString();
                                        if (IsnullMaster != null)
                                        {
                                            var ExistMaster = _appDbContext.SubIndustries.Where(x => x.IsDeleted == false && x.Name == IsnullMaster).FirstOrDefault();
                                            if (ExistMaster == null)
                                            {


                                                if (NameIndex != -1)
                                                {
                                                    var Com = (reader.GetValue(NameIndex) == null) ? null : reader.GetValue(NameIndex).ToString();
                                                    if (Com != null)
                                                    {
                                                        ImportMaster.Name = (reader.GetValue(NameIndex) == null) ? null : reader.GetValue(NameIndex).ToString();
                                                    }
                                                    if (DescriptionIndex != -1)
                                                    {
                                                        ImportMaster.Description = (reader.GetValue(DescriptionIndex) == null) ? null : reader.GetValue(DescriptionIndex).ToString();
                                                    }
                                                    ImportMaster.IsDeleted = false;
                                                    ImportMaster.CreatedAt = DateTime.Now;
                                                    ImportMaster.PublicId = Guid.NewGuid();
                                                    ImportMaster.CreatedBy = (long)MapedField.File.CreatedBy;
                                                    _appDbContext.SubIndustries.Add(ImportMaster);
                                                    _appDbContext.SaveChanges();
                                                }

                                            }
                                            else if (MapedField.File.SkipDuplicate == true)
                                            {
                                                var MasterId = ExistMaster.Id;
                                                if (NameIndex != -1)
                                                {

                                                    var UpdateMaster = _appDbContext.SubIndustries.Where(x => x.IsDeleted == false && x.Id == MasterId).FirstOrDefault();
                                                    if (UpdateMaster != null)
                                                    {
                                                        UpdateMaster.Name = (reader.GetValue(NameIndex) == null) ? null : reader.GetValue(NameIndex).ToString();
                                                        //ImportCompany.RegistrationNo = (reader.GetValue(RegistrationNoIndex) == null) ? null : reader.GetValue(RegistrationNoIndex).ToString();
                                                        if (NameIndex != -1)
                                                        {
                                                            var name = reader.GetValue(NameIndex);
                                                            if (name != "")
                                                            {

                                                                if (UpdateMaster.Name == null)
                                                                {
                                                                    UpdateMaster.Name = (reader.GetValue(NameIndex) == null) ? null : reader.GetValue(NameIndex).ToString();
                                                                }

                                                            }

                                                        }
                                                        if (DescriptionIndex != -1)
                                                        {
                                                            var desr = reader.GetValue(DescriptionIndex);
                                                            if (desr != "")
                                                            {
                                                                if (UpdateMaster.Description == null)
                                                                {
                                                                    UpdateMaster.Name = (reader.GetValue(NameIndex) == null) ? null : reader.GetValue(NameIndex).ToString();
                                                                }
                                                            }



                                                        }
                                                        UpdateMaster.IsDeleted = false;
                                                        UpdateMaster.ModifiedAt = DateTime.Now;
                                                        UpdateMaster.PublicId = Guid.NewGuid();
                                                        UpdateMaster.ModifiedBy = MapedField.File.CreatedBy;
                                                        await _appDbContext.SaveChangesAsync();

                                                        SkipedMasters = SkipedMasters + 1;

                                                    }

                                                }
                                            }
                                            else if (MapedField.File.OverwriteDuplicate == true)
                                            {
                                                var MasterId = ExistMaster.Id;
                                                if (NameIndex != -1)
                                                {
                                                    var UpdateMaster = _appDbContext.SubIndustries.Where(x => x.IsDeleted == false && x.Id == MasterId).FirstOrDefault();
                                                    if (UpdateMaster != null)
                                                    {
                                                        var Com = (reader.GetValue(NameIndex) == null) ? null : reader.GetValue(NameIndex).ToString();
                                                        if (Com != null)
                                                        {
                                                            UpdateMaster.Name = (reader.GetValue(NameIndex) == null) ? null : reader.GetValue(NameIndex).ToString();
                                                            //ImportCompany.RegistrationNo = (reader.GetValue(RegistrationNoIndex) == null) ? null : reader.GetValue(RegistrationNoIndex).ToString();
                                                            if (DescriptionIndex != -1)
                                                            {
                                                                var regsi = reader.GetValue(DescriptionIndex);
                                                                if (regsi != "")
                                                                {
                                                                    UpdateMaster.Description = (reader.GetValue(DescriptionIndex) == null) ? null : reader.GetValue(DescriptionIndex).ToString();
                                                                }

                                                            }
                                                            UpdateMaster.IsDeleted = false;
                                                            UpdateMaster.PublicId = Guid.NewGuid();
                                                            UpdateMaster.ModifiedAt = DateTime.Now;
                                                            UpdateMaster.ModifiedBy = MapedField.File.CreatedBy;
                                                            await _appDbContext.SaveChangesAsync();

                                                            Overwritemasters = Overwritemasters + 1;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        #endregion
                                    }
                                    while (reader.NextResult()) ;

                                }


                            }
                            #region Maitain Import History
                            // to maintain excel sheet history                  
                            //ImportHistory addnew = new ImportHistory();
                            //addnew.ImportedAt = DateTime.Now;
                            //addnew.ImportedBy = MapedField.File.CreatedBy;
                            //addnew.FilePath = filePatth;
                            ////addnew.ExcelFileName = MapedField.File.FileName.Trim(0,_).;
                            //addnew.ModuleId = 3;
                            //addnew.ExcelNameBySystem = MapedField.File.FileName;
                            //_appDbContext.ImportHistory.Add(addnew);
                            //_appDbContext.SaveChanges();
                            #endregion

                            finalreturnModel.Message = "Masters Imported Successfully!";
                            finalreturnModel.Success = true;
                        }
                        return finalreturnModel;
                    }

                }
                while (reader.NextResult()) ;

                finalreturnModel.Message = "Something went wrong!";
                finalreturnModel.Success = false;
                return finalreturnModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<object> ImportProducts(importdatanew MapedField)
        {
            try
            {
                if (MapedField.File.FileName == null)
                {
                    finalreturnModel.Message = "File not found!";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }
                if (MapedField == null)
                {
                    finalreturnModel.Message = "Model can not be null!";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }
                if (MapedField.importmasters.NameIndexId == null)
                {
                    finalreturnModel.Message = "Required field not maped!";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }
                if (MapedField.importmasters.Name == "")
                {
                    finalreturnModel.Message = "masters field not maped!";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }
                if (MapedField.importmasters.Name == "string")
                {
                    finalreturnModel.Message = "masters field not maped!";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }

                int SkipedMasters = 0;
                //int ImportedMasters = 0;
                int Overwritemasters = 0;

                var filePatth = GetFilePath1(MapedField.File.FileName); //Common.
                var Provider = new FileExtensionContentTypeProvider();
                if (!Provider.TryGetContentType(filePatth, out var _contentType))
                {
                    _contentType = "application/octet-stream";

                }
                var _ReadAllBytesAsync = await File.ReadAllBytesAsync(filePatth);
                var data = (_ReadAllBytesAsync, _contentType, Path.GetFileName(filePatth));

                FileStream stream = new FileStream(filePatth, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream);
                DataSet dataSet = reader.AsDataSet(
                    configuration: new ExcelExcelDataSetConfiguation()
                    {

                        UseColumnDataType = false,
                        ConfigureDataTable = (IExcelDataReader) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true
                        }

                    });
                var count = reader.RowCount;
                while (reader.Read())
                {
                    var ExcelFieldCount1 = reader.FieldCount;
                    for (int n = 0; n < ExcelFieldCount1; n++)
                    {
                        var ExcelRowColumnisNull = (reader.GetValue(n) == null) ? null : reader.GetValue(n).ToString();
                        if (ExcelRowColumnisNull != null)
                        {
                            for (int i = 0; i < count; i++)
                            {
                                if (i == n)
                                {
                                    var finalMappedColumnsIndex = new List<Dictionary<string, int>>();
                                    var ExcelFieldCount = reader.FieldCount;
                                    for (int f = 0; f < ExcelFieldCount; f++)
                                    {
                                        var ExcelColumn = (reader.GetValue(f) == null) ? null : reader.GetValue(f).ToString();
                                        var myDictinary = new Dictionary<string, int>();
                                        myDictinary.Add(ExcelColumn, f);
                                        finalMappedColumnsIndex.Add(myDictinary);
                                    }
                                    int NameIndex = -1;
                                    int DescriptionIndex = -1;

                                    foreach (var item in finalMappedColumnsIndex)
                                    {
                                        #region Cheak Columns
                                        if (item.ContainsKey(MapedField.importmasters.Name))
                                        {
                                            NameIndex = item["Name"];
                                        }
                                        else if (item.ContainsKey(MapedField.importmasters.Description))
                                        {
                                            DescriptionIndex = item["Description"];
                                        }
                                        #endregion
                                    }
                                    while (reader.Read())

                                    {
                                        #region Insert Date In DataBase
                                        var ExcelRowColumnisNull1 = (reader.GetValue(n) == null) ? null : reader.GetValue(n).ToString();
                                        if (ExcelRowColumnisNull1 == null)
                                        {



                                        }
                                        var field = reader;
                                        Product ImportMaster = new Product();

                                        var IsnullMaster = (reader.GetValue(NameIndex) == null) ? null : reader.GetValue(NameIndex).ToString();
                                        if (IsnullMaster != null)
                                        {
                                            var ExistMaster = _appDbContext.Product.Where(x => x.IsDeleted == false && x.Name == IsnullMaster).FirstOrDefault();
                                            if (ExistMaster == null)
                                            {


                                                if (NameIndex != -1)
                                                {
                                                    var Com = (reader.GetValue(NameIndex) == null) ? null : reader.GetValue(NameIndex).ToString();
                                                    if (Com != null)
                                                    {
                                                        ImportMaster.Name = (reader.GetValue(NameIndex) == null) ? null : reader.GetValue(NameIndex).ToString();
                                                    }
                                                    if (DescriptionIndex != -1)
                                                    {
                                                        ImportMaster.Description = (reader.GetValue(DescriptionIndex) == null) ? null : reader.GetValue(DescriptionIndex).ToString();
                                                    }
                                                    ImportMaster.IsDeleted = false;
                                                    ImportMaster.CreatedAt = DateTime.Now;
                                                    ImportMaster.PublicId = Guid.NewGuid();
                                                    ImportMaster.CreatedBy = (long)MapedField.File.CreatedBy;
                                                    _appDbContext.Product.Add(ImportMaster);
                                                    _appDbContext.SaveChanges();
                                                }

                                            }
                                            else if (MapedField.File.SkipDuplicate == true)
                                            {
                                                var MasterId = ExistMaster.Id;
                                                if (NameIndex != -1)
                                                {

                                                    var UpdateMaster = _appDbContext.Product.Where(x => x.IsDeleted == false && x.Id == MasterId).FirstOrDefault();
                                                    if (UpdateMaster != null)
                                                    {
                                                        UpdateMaster.Name = (reader.GetValue(NameIndex) == null) ? null : reader.GetValue(NameIndex).ToString();
                                                        //ImportCompany.RegistrationNo = (reader.GetValue(RegistrationNoIndex) == null) ? null : reader.GetValue(RegistrationNoIndex).ToString();
                                                        if (NameIndex != -1)
                                                        {
                                                            var name = reader.GetValue(NameIndex);
                                                            if (name != "")
                                                            {

                                                                if (UpdateMaster.Name == null)
                                                                {
                                                                    UpdateMaster.Name = (reader.GetValue(NameIndex) == null) ? null : reader.GetValue(NameIndex).ToString();
                                                                }

                                                            }

                                                        }
                                                        if (DescriptionIndex != -1)
                                                        {
                                                            var desr = reader.GetValue(DescriptionIndex);
                                                            if (desr != "")
                                                            {
                                                                if (UpdateMaster.Description == null)
                                                                {
                                                                    UpdateMaster.Name = (reader.GetValue(NameIndex) == null) ? null : reader.GetValue(NameIndex).ToString();
                                                                }
                                                            }



                                                        }
                                                        UpdateMaster.IsDeleted = false;
                                                        UpdateMaster.ModifiedAt = DateTime.Now;
                                                        UpdateMaster.PublicId = Guid.NewGuid();
                                                        UpdateMaster.ModifiedBy = MapedField.File.CreatedBy;
                                                        await _appDbContext.SaveChangesAsync();

                                                        SkipedMasters = SkipedMasters + 1;

                                                    }

                                                }
                                            }
                                            else if (MapedField.File.OverwriteDuplicate == true)
                                            {
                                                var MasterId = ExistMaster.Id;
                                                if (NameIndex != -1)
                                                {
                                                    var UpdateMaster = _appDbContext.Product.Where(x => x.IsDeleted == false && x.Id == MasterId).FirstOrDefault();
                                                    if (UpdateMaster != null)
                                                    {
                                                        var Com = (reader.GetValue(NameIndex) == null) ? null : reader.GetValue(NameIndex).ToString();
                                                        if (Com != null)
                                                        {
                                                            UpdateMaster.Name = (reader.GetValue(NameIndex) == null) ? null : reader.GetValue(NameIndex).ToString();
                                                            //ImportCompany.RegistrationNo = (reader.GetValue(RegistrationNoIndex) == null) ? null : reader.GetValue(RegistrationNoIndex).ToString();
                                                            if (DescriptionIndex != -1)
                                                            {
                                                                var regsi = reader.GetValue(DescriptionIndex);
                                                                if (regsi != "")
                                                                {
                                                                    UpdateMaster.Description = (reader.GetValue(DescriptionIndex) == null) ? null : reader.GetValue(DescriptionIndex).ToString();
                                                                }

                                                            }
                                                            UpdateMaster.IsDeleted = false;
                                                            UpdateMaster.PublicId = Guid.NewGuid();
                                                            UpdateMaster.ModifiedAt = DateTime.Now;
                                                            UpdateMaster.ModifiedBy = MapedField.File.CreatedBy;
                                                            await _appDbContext.SaveChangesAsync();

                                                            Overwritemasters = Overwritemasters + 1;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        #endregion
                                    }
                                    while (reader.NextResult()) ;

                                }


                            }
                            #region Maitain Import History
                            // to maintain excel sheet history                  
                            //ImportHistory addnew = new ImportHistory();
                            //addnew.ImportedAt = DateTime.Now;
                            //addnew.ImportedBy = MapedField.File.CreatedBy;
                            //addnew.FilePath = filePatth;
                            ////addnew.ExcelFileName = MapedField.File.FileName.Trim(0,_).;
                            //addnew.ModuleId = 3;
                            //addnew.ExcelNameBySystem = MapedField.File.FileName;
                            //_appDbContext.ImportHistory.Add(addnew);
                            //_appDbContext.SaveChanges();
                            #endregion

                            finalreturnModel.Message = "Masters Imported Successfully!";
                            finalreturnModel.Success = true;
                        }
                        return finalreturnModel;
                    }

                }
                while (reader.NextResult()) ;

                finalreturnModel.Message = "Something went wrong!";
                finalreturnModel.Success = false;
                return finalreturnModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<object> ImportIndustryGroups(importdatanew MapedField)
        {
            try
            {
                if (MapedField.File.FileName == null)
                {
                    finalreturnModel.Message = "File not found!";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }
                if (MapedField == null)
                {
                    finalreturnModel.Message = "Model can not be null!";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }
                if (MapedField.importmasters.NameIndexId == null)
                {
                    finalreturnModel.Message = "Required field not maped!";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }
                if (MapedField.importmasters.Name == "")
                {
                    finalreturnModel.Message = "masters field not maped!";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }
                if (MapedField.importmasters.Name == "string")
                {
                    finalreturnModel.Message = "masters field not maped!";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }

                int SkipedMasters = 0;
                //int ImportedMasters = 0;
                int Overwritemasters = 0;

                var filePatth = GetFilePath1(MapedField.File.FileName); //Common.
                var Provider = new FileExtensionContentTypeProvider();
                if (!Provider.TryGetContentType(filePatth, out var _contentType))
                {
                    _contentType = "application/octet-stream";

                }
                var _ReadAllBytesAsync = await File.ReadAllBytesAsync(filePatth);
                var data = (_ReadAllBytesAsync, _contentType, Path.GetFileName(filePatth));

                FileStream stream = new FileStream(filePatth, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream);
                DataSet dataSet = reader.AsDataSet(
                    configuration: new ExcelExcelDataSetConfiguation()
                    {

                        UseColumnDataType = false,
                        ConfigureDataTable = (IExcelDataReader) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true
                        }

                    });
                var count = reader.RowCount;
                while (reader.Read())
                {
                    var ExcelFieldCount1 = reader.FieldCount;
                    for (int n = 0; n < ExcelFieldCount1; n++)
                    {
                        var ExcelRowColumnisNull = (reader.GetValue(n) == null) ? null : reader.GetValue(n).ToString();
                        if (ExcelRowColumnisNull != null)
                        {
                            for (int i = 0; i < count; i++)
                            {
                                if (i == n)
                                {
                                    var finalMappedColumnsIndex = new List<Dictionary<string, int>>();
                                    var ExcelFieldCount = reader.FieldCount;
                                    for (int f = 0; f < ExcelFieldCount; f++)
                                    {
                                        var ExcelColumn = (reader.GetValue(f) == null) ? null : reader.GetValue(f).ToString();
                                        var myDictinary = new Dictionary<string, int>();
                                        myDictinary.Add(ExcelColumn, f);
                                        finalMappedColumnsIndex.Add(myDictinary);
                                    }
                                    int NameIndex = -1;
                                    int DescriptionIndex = -1;

                                    foreach (var item in finalMappedColumnsIndex)
                                    {
                                        #region Cheak Columns
                                        if (item.ContainsKey(MapedField.importmasters.Name))
                                        {
                                            NameIndex = item["Name"];
                                        }
                                        else if (item.ContainsKey(MapedField.importmasters.Description))
                                        {
                                            DescriptionIndex = item["Description"];
                                        }
                                        #endregion
                                    }
                                    while (reader.Read())

                                    {
                                        #region Insert Date In DataBase
                                        var ExcelRowColumnisNull1 = (reader.GetValue(n) == null) ? null : reader.GetValue(n).ToString();
                                        if (ExcelRowColumnisNull1 == null)
                                        {



                                        }
                                        var field = reader;
                                        Industries ImportMaster = new Industries();

                                        var IsnullMaster = (reader.GetValue(NameIndex) == null) ? null : reader.GetValue(NameIndex).ToString();
                                        if (IsnullMaster != null)
                                        {
                                            var ExistMaster = _appDbContext.IndustryGroup.Where(x => x.IsDeleted == false && x.Name == IsnullMaster).FirstOrDefault();
                                            if (ExistMaster == null)
                                            {


                                                if (NameIndex != -1)
                                                {
                                                    var Com = (reader.GetValue(NameIndex) == null) ? null : reader.GetValue(NameIndex).ToString();
                                                    if (Com != null)
                                                    {
                                                        ImportMaster.Name = (reader.GetValue(NameIndex) == null) ? null : reader.GetValue(NameIndex).ToString();
                                                    }
                                                    if (DescriptionIndex != -1)
                                                    {
                                                        ImportMaster.Description = (reader.GetValue(DescriptionIndex) == null) ? null : reader.GetValue(DescriptionIndex).ToString();
                                                    }
                                                    ImportMaster.IsDeleted = false;
                                                    ImportMaster.CreatedAt = DateTime.Now;
                                                    ImportMaster.PublicId = Guid.NewGuid();
                                                    ImportMaster.CreatedBy = (long)MapedField.File.CreatedBy;
                                                    _appDbContext.Industries.Add(ImportMaster);
                                                    _appDbContext.SaveChanges();
                                                }

                                            }
                                            else if (MapedField.File.SkipDuplicate == true)
                                            {
                                                var MasterId = ExistMaster.Id;
                                                if (NameIndex != -1)
                                                {

                                                    var UpdateMaster = _appDbContext.IndustryGroup.Where(x => x.IsDeleted == false && x.Id == MasterId).FirstOrDefault();
                                                    if (UpdateMaster != null)
                                                    {
                                                        UpdateMaster.Name = (reader.GetValue(NameIndex) == null) ? null : reader.GetValue(NameIndex).ToString();
                                                        //ImportCompany.RegistrationNo = (reader.GetValue(RegistrationNoIndex) == null) ? null : reader.GetValue(RegistrationNoIndex).ToString();
                                                        if (NameIndex != -1)
                                                        {
                                                            var name = reader.GetValue(NameIndex);
                                                            if (name != "")
                                                            {

                                                                if (UpdateMaster.Name == null)
                                                                {
                                                                    UpdateMaster.Name = (reader.GetValue(NameIndex) == null) ? null : reader.GetValue(NameIndex).ToString();
                                                                }

                                                            }

                                                        }
                                                        if (DescriptionIndex != -1)
                                                        {
                                                            var desr = reader.GetValue(DescriptionIndex);
                                                            if (desr != "")
                                                            {
                                                                if (UpdateMaster.Description == null)
                                                                {
                                                                    UpdateMaster.Name = (reader.GetValue(NameIndex) == null) ? null : reader.GetValue(NameIndex).ToString();
                                                                }
                                                            }



                                                        }
                                                        UpdateMaster.IsDeleted = false;
                                                        UpdateMaster.ModifiedAt = DateTime.Now;
                                                        UpdateMaster.PublicId = Guid.NewGuid();
                                                        UpdateMaster.ModifiedBy = MapedField.File.CreatedBy;
                                                        await _appDbContext.SaveChangesAsync();

                                                        SkipedMasters = SkipedMasters + 1;

                                                    }

                                                }
                                            }
                                            else if (MapedField.File.OverwriteDuplicate == true)
                                            {
                                                var MasterId = ExistMaster.Id;
                                                if (NameIndex != -1)
                                                {
                                                    var UpdateMaster = _appDbContext.IndustryGroup.Where(x => x.IsDeleted == false && x.Id == MasterId).FirstOrDefault();
                                                    if (UpdateMaster != null)
                                                    {
                                                        var Com = (reader.GetValue(NameIndex) == null) ? null : reader.GetValue(NameIndex).ToString();
                                                        if (Com != null)
                                                        {
                                                            UpdateMaster.Name = (reader.GetValue(NameIndex) == null) ? null : reader.GetValue(NameIndex).ToString();
                                                            //ImportCompany.RegistrationNo = (reader.GetValue(RegistrationNoIndex) == null) ? null : reader.GetValue(RegistrationNoIndex).ToString();
                                                            if (DescriptionIndex != -1)
                                                            {
                                                                var regsi = reader.GetValue(DescriptionIndex);
                                                                if (regsi != "")
                                                                {
                                                                    UpdateMaster.Description = (reader.GetValue(DescriptionIndex) == null) ? null : reader.GetValue(DescriptionIndex).ToString();
                                                                }

                                                            }
                                                            UpdateMaster.IsDeleted = false;
                                                            UpdateMaster.PublicId = Guid.NewGuid();
                                                            UpdateMaster.ModifiedAt = DateTime.Now;
                                                            UpdateMaster.ModifiedBy = MapedField.File.CreatedBy;
                                                            await _appDbContext.SaveChangesAsync();

                                                            Overwritemasters = Overwritemasters + 1;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        #endregion
                                    }
                                    while (reader.NextResult()) ;

                                }


                            }
                            #region Maitain Import History
                            // to maintain excel sheet history                  
                            //ImportHistory addnew = new ImportHistory();
                            //addnew.ImportedAt = DateTime.Now;
                            //addnew.ImportedBy = MapedField.File.CreatedBy;
                            //addnew.FilePath = filePatth;
                            ////addnew.ExcelFileName = MapedField.File.FileName.Trim(0,_).;
                            //addnew.ModuleId = 3;
                            //addnew.ExcelNameBySystem = MapedField.File.FileName;
                            //_appDbContext.ImportHistory.Add(addnew);
                            //_appDbContext.SaveChanges();
                            #endregion

                            finalreturnModel.Message = "Masters Imported Successfully!";
                            finalreturnModel.Success = true;
                        }
                        return finalreturnModel;
                    }

                }
                while (reader.NextResult()) ;

                finalreturnModel.Message = "Something went wrong!";
                finalreturnModel.Success = false;
                return finalreturnModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<object> ImportServicess(importdatanew MapedField)
        {
            try
            {
                if (MapedField.File.FileName == null)
                {
                    finalreturnModel.Message = "File not found!";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }
                if (MapedField == null)
                {
                    finalreturnModel.Message = "Model can not be null!";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }
                if (MapedField.importmasters.NameIndexId == null)
                {
                    finalreturnModel.Message = "Required field not maped!";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }
                if (MapedField.importmasters.Name == "")
                {
                    finalreturnModel.Message = "masters field not maped!";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }
                if (MapedField.importmasters.Name == "string")
                {
                    finalreturnModel.Message = "masters field not maped!";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }

                int SkipedMasters = 0;
                //int ImportedMasters = 0;
                int Overwritemasters = 0;

                var filePatth = GetFilePath1(MapedField.File.FileName); //Common.
                var Provider = new FileExtensionContentTypeProvider();
                if (!Provider.TryGetContentType(filePatth, out var _contentType))
                {
                    _contentType = "application/octet-stream";

                }
                var _ReadAllBytesAsync = await File.ReadAllBytesAsync(filePatth);
                var data = (_ReadAllBytesAsync, _contentType, Path.GetFileName(filePatth));

                FileStream stream = new FileStream(filePatth, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream);
                DataSet dataSet = reader.AsDataSet(
                    configuration: new ExcelExcelDataSetConfiguation()
                    {

                        UseColumnDataType = false,
                        ConfigureDataTable = (IExcelDataReader) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true
                        }

                    });
                var count = reader.RowCount;
                while (reader.Read())
                {
                    var ExcelFieldCount1 = reader.FieldCount;
                    for (int n = 0; n < ExcelFieldCount1; n++)
                    {
                        var ExcelRowColumnisNull = (reader.GetValue(n) == null) ? null : reader.GetValue(n).ToString();
                        if (ExcelRowColumnisNull != null)
                        {
                            for (int i = 0; i < count; i++)
                            {
                                if (i == n)
                                {
                                    var finalMappedColumnsIndex = new List<Dictionary<string, int>>();
                                    var ExcelFieldCount = reader.FieldCount;
                                    for (int f = 0; f < ExcelFieldCount; f++)
                                    {
                                        var ExcelColumn = (reader.GetValue(f) == null) ? null : reader.GetValue(f).ToString();
                                        var myDictinary = new Dictionary<string, int>();
                                        myDictinary.Add(ExcelColumn, f);
                                        finalMappedColumnsIndex.Add(myDictinary);
                                    }
                                    int NameIndex = -1;
                                    int DescriptionIndex = -1;

                                    foreach (var item in finalMappedColumnsIndex)
                                    {
                                        #region Cheak Columns
                                        if (item.ContainsKey(MapedField.importmasters.Name))
                                        {
                                            NameIndex = item["Name"];
                                        }
                                        else if (item.ContainsKey(MapedField.importmasters.Description))
                                        {
                                            DescriptionIndex = item["Description"];
                                        }
                                        #endregion
                                    }
                                    while (reader.Read())

                                    {
                                        #region Insert Date In DataBase
                                        var ExcelRowColumnisNull1 = (reader.GetValue(n) == null) ? null : reader.GetValue(n).ToString();
                                        if (ExcelRowColumnisNull1 == null)
                                        {



                                        }
                                        var field = reader;
                                        Service ImportMaster = new Service();

                                        var IsnullMaster = (reader.GetValue(NameIndex) == null) ? null : reader.GetValue(NameIndex).ToString();
                                        if (IsnullMaster != null)
                                        {
                                            var ExistMaster = _appDbContext.Service.Where(x => x.IsDeleted == false && x.Name == IsnullMaster).FirstOrDefault();
                                            if (ExistMaster == null)
                                            {


                                                if (NameIndex != -1)
                                                {
                                                    var Com = (reader.GetValue(NameIndex) == null) ? null : reader.GetValue(NameIndex).ToString();
                                                    if (Com != null)
                                                    {
                                                        ImportMaster.Name = (reader.GetValue(NameIndex) == null) ? null : reader.GetValue(NameIndex).ToString();
                                                    }
                                                    if (DescriptionIndex != -1)
                                                    {
                                                        ImportMaster.Description = (reader.GetValue(DescriptionIndex) == null) ? null : reader.GetValue(DescriptionIndex).ToString();
                                                    }
                                                    ImportMaster.IsDeleted = false;
                                                    ImportMaster.CreatedAt = DateTime.Now;
                                                    ImportMaster.PublicId = Guid.NewGuid();
                                                    ImportMaster.CreatedBy = (long)MapedField.File.CreatedBy;
                                                    _appDbContext.Service.Add(ImportMaster);
                                                    _appDbContext.SaveChanges();
                                                }

                                            }
                                            else if (MapedField.File.SkipDuplicate == true)
                                            {
                                                var MasterId = ExistMaster.Id;
                                                if (NameIndex != -1)
                                                {

                                                    var UpdateMaster = _appDbContext.Service.Where(x => x.IsDeleted == false && x.Id == MasterId).FirstOrDefault();
                                                    if (UpdateMaster != null)
                                                    {
                                                        UpdateMaster.Name = (reader.GetValue(NameIndex) == null) ? null : reader.GetValue(NameIndex).ToString();
                                                        //ImportCompany.RegistrationNo = (reader.GetValue(RegistrationNoIndex) == null) ? null : reader.GetValue(RegistrationNoIndex).ToString();
                                                        if (NameIndex != -1)
                                                        {
                                                            var name = reader.GetValue(NameIndex);
                                                            if (name != "")
                                                            {

                                                                if (UpdateMaster.Name == null)
                                                                {
                                                                    UpdateMaster.Name = (reader.GetValue(NameIndex) == null) ? null : reader.GetValue(NameIndex).ToString();
                                                                }

                                                            }

                                                        }
                                                        if (DescriptionIndex != -1)
                                                        {
                                                            var desr = reader.GetValue(DescriptionIndex);
                                                            if (desr != "")
                                                            {
                                                                if (UpdateMaster.Description == null)
                                                                {
                                                                    UpdateMaster.Name = (reader.GetValue(NameIndex) == null) ? null : reader.GetValue(NameIndex).ToString();
                                                                }
                                                            }



                                                        }
                                                        UpdateMaster.IsDeleted = false;
                                                        UpdateMaster.ModifiedAt = DateTime.Now;
                                                        UpdateMaster.PublicId = Guid.NewGuid();
                                                        UpdateMaster.ModifiedBy = MapedField.File.CreatedBy;
                                                        await _appDbContext.SaveChangesAsync();

                                                        SkipedMasters = SkipedMasters + 1;

                                                    }

                                                }
                                            }
                                            else if (MapedField.File.OverwriteDuplicate == true)
                                            {
                                                var MasterId = ExistMaster.Id;
                                                if (NameIndex != -1)
                                                {
                                                    var UpdateMaster = _appDbContext.Service.Where(x => x.IsDeleted == false && x.Id == MasterId).FirstOrDefault();
                                                    if (UpdateMaster != null)
                                                    {
                                                        var Com = (reader.GetValue(NameIndex) == null) ? null : reader.GetValue(NameIndex).ToString();
                                                        if (Com != null)
                                                        {
                                                            UpdateMaster.Name = (reader.GetValue(NameIndex) == null) ? null : reader.GetValue(NameIndex).ToString();
                                                            //ImportCompany.RegistrationNo = (reader.GetValue(RegistrationNoIndex) == null) ? null : reader.GetValue(RegistrationNoIndex).ToString();
                                                            if (DescriptionIndex != -1)
                                                            {
                                                                var regsi = reader.GetValue(DescriptionIndex);
                                                                if (regsi != "")
                                                                {
                                                                    UpdateMaster.Description = (reader.GetValue(DescriptionIndex) == null) ? null : reader.GetValue(DescriptionIndex).ToString();
                                                                }

                                                            }
                                                            UpdateMaster.IsDeleted = false;
                                                            UpdateMaster.PublicId = Guid.NewGuid();
                                                            UpdateMaster.ModifiedAt = DateTime.Now;
                                                            UpdateMaster.ModifiedBy = MapedField.File.CreatedBy;
                                                            await _appDbContext.SaveChangesAsync();

                                                            Overwritemasters = Overwritemasters + 1;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        #endregion
                                    }
                                    while (reader.NextResult()) ;

                                }


                            }
                            #region Maitain Import History
                            // to maintain excel sheet history                  
                            //ImportHistory addnew = new ImportHistory();
                            //addnew.ImportedAt = DateTime.Now;
                            //addnew.ImportedBy = MapedField.File.CreatedBy;
                            //addnew.FilePath = filePatth;
                            ////addnew.ExcelFileName = MapedField.File.FileName.Trim(0,_).;
                            //addnew.ModuleId = 3;
                            //addnew.ExcelNameBySystem = MapedField.File.FileName;
                            //_appDbContext.ImportHistory.Add(addnew);
                            //_appDbContext.SaveChanges();
                            #endregion

                            finalreturnModel.Message = "Masters Imported Successfully!";
                            finalreturnModel.Success = true;
                        }
                        return finalreturnModel;
                    }

                }
                while (reader.NextResult()) ;

                finalreturnModel.Message = "Something went wrong!";
                finalreturnModel.Success = false;
                return finalreturnModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<object> ImportProcess(importdatanew MapedField)
        {
            try
            {
                if (MapedField.File.FileName == null)
                {
                    finalreturnModel.Message = "File not found!";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }
                if (MapedField == null)
                {
                    finalreturnModel.Message = "Model can not be null!";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }
                if (MapedField.importmasters.NameIndexId == null)
                {
                    finalreturnModel.Message = "Required field not maped!";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }
                if (MapedField.importmasters.Name == "")
                {
                    finalreturnModel.Message = "masters field not maped!";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }
                if (MapedField.importmasters.Name == "string")
                {
                    finalreturnModel.Message = "masters field not maped!";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }

                int SkipedMasters = 0;
                //int ImportedMasters = 0;
                int Overwritemasters = 0;

                var filePatth = GetFilePath1(MapedField.File.FileName); //Common.
                var Provider = new FileExtensionContentTypeProvider();
                if (!Provider.TryGetContentType(filePatth, out var _contentType))
                {
                    _contentType = "application/octet-stream";

                }
                var _ReadAllBytesAsync = await File.ReadAllBytesAsync(filePatth);
                var data = (_ReadAllBytesAsync, _contentType, Path.GetFileName(filePatth));

                FileStream stream = new FileStream(filePatth, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream);
                DataSet dataSet = reader.AsDataSet(
                    configuration: new ExcelExcelDataSetConfiguation()
                    {

                        UseColumnDataType = false,
                        ConfigureDataTable = (IExcelDataReader) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true
                        }

                    });
                var count = reader.RowCount;
                while (reader.Read())
                {
                    var ExcelFieldCount1 = reader.FieldCount;
                    for (int n = 0; n < ExcelFieldCount1; n++)
                    {
                        var ExcelRowColumnisNull = (reader.GetValue(n) == null) ? null : reader.GetValue(n).ToString();
                        if (ExcelRowColumnisNull != null)
                        {
                            for (int i = 0; i < count; i++)
                            {
                                if (i == n)
                                {
                                    var finalMappedColumnsIndex = new List<Dictionary<string, int>>();
                                    var ExcelFieldCount = reader.FieldCount;
                                    for (int f = 0; f < ExcelFieldCount; f++)
                                    {
                                        var ExcelColumn = (reader.GetValue(f) == null) ? null : reader.GetValue(f).ToString();
                                        var myDictinary = new Dictionary<string, int>();
                                        myDictinary.Add(ExcelColumn, f);
                                        finalMappedColumnsIndex.Add(myDictinary);
                                    }
                                    int NameIndex = -1;
                                    int DescriptionIndex = -1;

                                    foreach (var item in finalMappedColumnsIndex)
                                    {
                                        #region Cheak Columns
                                        if (item.ContainsKey(MapedField.importmasters.Name))
                                        {
                                            NameIndex = item["Name"];
                                        }
                                        else if (item.ContainsKey(MapedField.importmasters.Description))
                                        {
                                            DescriptionIndex = item["Description"];
                                        }
                                        #endregion
                                    }
                                    while (reader.Read())

                                    {
                                        #region Insert Date In DataBase
                                        var ExcelRowColumnisNull1 = (reader.GetValue(n) == null) ? null : reader.GetValue(n).ToString();
                                        if (ExcelRowColumnisNull1 == null)
                                        {



                                        }
                                        var field = reader;
                                        Process ImportMaster = new Process();

                                        var IsnullMaster = (reader.GetValue(NameIndex) == null) ? null : reader.GetValue(NameIndex).ToString();
                                        if (IsnullMaster != null)
                                        {
                                            var ExistMaster = _appDbContext.Process.Where(x => x.IsDeleted == false && x.Name == IsnullMaster).FirstOrDefault();
                                            if (ExistMaster == null)
                                            {


                                                if (NameIndex != -1)
                                                {
                                                    var Com = (reader.GetValue(NameIndex) == null) ? null : reader.GetValue(NameIndex).ToString();
                                                    if (Com != null)
                                                    {
                                                        ImportMaster.Name = (reader.GetValue(NameIndex) == null) ? null : reader.GetValue(NameIndex).ToString();
                                                    }
                                                    if (DescriptionIndex != -1)
                                                    {
                                                        ImportMaster.Description = (reader.GetValue(DescriptionIndex) == null) ? null : reader.GetValue(DescriptionIndex).ToString();
                                                    }
                                                    ImportMaster.IsDeleted = false;
                                                    ImportMaster.CreatedAt = DateTime.Now;
                                                    ImportMaster.PublicId = Guid.NewGuid();
                                                    ImportMaster.CreatedBy = (long)MapedField.File.CreatedBy;
                                                    _appDbContext.Process.Add(ImportMaster);
                                                    _appDbContext.SaveChanges();
                                                }

                                            }
                                            else if (MapedField.File.SkipDuplicate == true)
                                            {
                                                var MasterId = ExistMaster.Id;
                                                if (NameIndex != -1)
                                                {

                                                    var UpdateMaster = _appDbContext.Process.Where(x => x.IsDeleted == false && x.Id == MasterId).FirstOrDefault();
                                                    if (UpdateMaster != null)
                                                    {
                                                        UpdateMaster.Name = (reader.GetValue(NameIndex) == null) ? null : reader.GetValue(NameIndex).ToString();
                                                        //ImportCompany.RegistrationNo = (reader.GetValue(RegistrationNoIndex) == null) ? null : reader.GetValue(RegistrationNoIndex).ToString();
                                                        if (NameIndex != -1)
                                                        {
                                                            var name = reader.GetValue(NameIndex);
                                                            if (name != "")
                                                            {

                                                                if (UpdateMaster.Name == null)
                                                                {
                                                                    UpdateMaster.Name = (reader.GetValue(NameIndex) == null) ? null : reader.GetValue(NameIndex).ToString();
                                                                }

                                                            }

                                                        }
                                                        if (DescriptionIndex != -1)
                                                        {
                                                            var desr = reader.GetValue(DescriptionIndex);
                                                            if (desr != "")
                                                            {
                                                                if (UpdateMaster.Description == null)
                                                                {
                                                                    UpdateMaster.Name = (reader.GetValue(NameIndex) == null) ? null : reader.GetValue(NameIndex).ToString();
                                                                }
                                                            }



                                                        }
                                                        UpdateMaster.IsDeleted = false;
                                                        UpdateMaster.ModifiedAt = DateTime.Now;
                                                        UpdateMaster.PublicId = Guid.NewGuid();
                                                        UpdateMaster.ModifiedBy = MapedField.File.CreatedBy;
                                                        await _appDbContext.SaveChangesAsync();

                                                        SkipedMasters = SkipedMasters + 1;

                                                    }

                                                }
                                            }
                                            else if (MapedField.File.OverwriteDuplicate == true)
                                            {
                                                var MasterId = ExistMaster.Id;
                                                if (NameIndex != -1)
                                                {
                                                    var UpdateMaster = _appDbContext.Process.Where(x => x.IsDeleted == false && x.Id == MasterId).FirstOrDefault();
                                                    if (UpdateMaster != null)
                                                    {
                                                        var Com = (reader.GetValue(NameIndex) == null) ? null : reader.GetValue(NameIndex).ToString();
                                                        if (Com != null)
                                                        {
                                                            UpdateMaster.Name = (reader.GetValue(NameIndex) == null) ? null : reader.GetValue(NameIndex).ToString();
                                                            //ImportCompany.RegistrationNo = (reader.GetValue(RegistrationNoIndex) == null) ? null : reader.GetValue(RegistrationNoIndex).ToString();
                                                            if (DescriptionIndex != -1)
                                                            {
                                                                var regsi = reader.GetValue(DescriptionIndex);
                                                                if (regsi != "")
                                                                {
                                                                    UpdateMaster.Description = (reader.GetValue(DescriptionIndex) == null) ? null : reader.GetValue(DescriptionIndex).ToString();
                                                                }

                                                            }
                                                            UpdateMaster.IsDeleted = false;
                                                            UpdateMaster.PublicId = Guid.NewGuid();
                                                            UpdateMaster.ModifiedAt = DateTime.Now;
                                                            UpdateMaster.ModifiedBy = MapedField.File.CreatedBy;
                                                            await _appDbContext.SaveChangesAsync();

                                                            Overwritemasters = Overwritemasters + 1;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        #endregion
                                    }
                                    while (reader.NextResult()) ;

                                }


                            }
                            #region Maitain Import History
                            // to maintain excel sheet history                  
                            //ImportHistory addnew = new ImportHistory();
                            //addnew.ImportedAt = DateTime.Now;
                            //addnew.ImportedBy = MapedField.File.CreatedBy;
                            //addnew.FilePath = filePatth;
                            ////addnew.ExcelFileName = MapedField.File.FileName.Trim(0,_).;
                            //addnew.ModuleId = 3;
                            //addnew.ExcelNameBySystem = MapedField.File.FileName;
                            //_appDbContext.ImportHistory.Add(addnew);
                            //_appDbContext.SaveChanges();
                            #endregion

                            finalreturnModel.Message = "Masters Imported Successfully!";
                            finalreturnModel.Success = true;
                        }
                        return finalreturnModel;
                    }

                }
                while (reader.NextResult()) ;

                finalreturnModel.Message = "Something went wrong!";
                finalreturnModel.Success = false;
                return finalreturnModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<object> ImportToolendTechnologies(importdatanew MapedField)
        {
            try
            {
                if (MapedField.File.FileName == null)
                {
                    finalreturnModel.Message = "File not found!";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }
                if (MapedField == null)
                {
                    finalreturnModel.Message = "Model can not be null!";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }
                if (MapedField.importmasters.NameIndexId == null)
                {
                    finalreturnModel.Message = "Required field not maped!";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }
                if (MapedField.importmasters.Name == "")
                {
                    finalreturnModel.Message = "masters field not maped!";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }
                if (MapedField.importmasters.Name == "string")
                {
                    finalreturnModel.Message = "masters field not maped!";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }

                int SkipedMasters = 0;
                //int ImportedMasters = 0;
                int Overwritemasters = 0;

                var filePatth = GetFilePath1(MapedField.File.FileName); //Common.
                var Provider = new FileExtensionContentTypeProvider();
                if (!Provider.TryGetContentType(filePatth, out var _contentType))
                {
                    _contentType = "application/octet-stream";

                }
                var _ReadAllBytesAsync = await File.ReadAllBytesAsync(filePatth);
                var data = (_ReadAllBytesAsync, _contentType, Path.GetFileName(filePatth));

                FileStream stream = new FileStream(filePatth, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream);
                DataSet dataSet = reader.AsDataSet(
                    configuration: new ExcelExcelDataSetConfiguation()
                    {

                        UseColumnDataType = false,
                        ConfigureDataTable = (IExcelDataReader) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true
                        }

                    });
                var count = reader.RowCount;
                while (reader.Read())
                {
                    var ExcelFieldCount1 = reader.FieldCount;
                    for (int n = 0; n < ExcelFieldCount1; n++)
                    {
                        var ExcelRowColumnisNull = (reader.GetValue(n) == null) ? null : reader.GetValue(n).ToString();
                        if (ExcelRowColumnisNull != null)
                        {
                            for (int i = 0; i < count; i++)
                            {
                                if (i == n)
                                {
                                    var finalMappedColumnsIndex = new List<Dictionary<string, int>>();
                                    var ExcelFieldCount = reader.FieldCount;
                                    for (int f = 0; f < ExcelFieldCount; f++)
                                    {
                                        var ExcelColumn = (reader.GetValue(f) == null) ? null : reader.GetValue(f).ToString();
                                        var myDictinary = new Dictionary<string, int>();
                                        myDictinary.Add(ExcelColumn, f);
                                        finalMappedColumnsIndex.Add(myDictinary);
                                    }
                                    int NameIndex = -1;
                                    int DescriptionIndex = -1;

                                    foreach (var item in finalMappedColumnsIndex)
                                    {
                                        #region Cheak Columns
                                        if (item.ContainsKey(MapedField.importmasters.Name))
                                        {
                                            NameIndex = item["Name"];
                                        }
                                        else if (item.ContainsKey(MapedField.importmasters.Description))
                                        {
                                            DescriptionIndex = item["Description"];
                                        }
                                        #endregion
                                    }
                                    while (reader.Read())

                                    {
                                        #region Insert Date In DataBase
                                        var ExcelRowColumnisNull1 = (reader.GetValue(n) == null) ? null : reader.GetValue(n).ToString();
                                        if (ExcelRowColumnisNull1 == null)
                                        {



                                        }
                                        var field = reader;
                                        ToolandtechTechnologies ImportMaster = new ToolandtechTechnologies();

                                        var IsnullMaster = (reader.GetValue(NameIndex) == null) ? null : reader.GetValue(NameIndex).ToString();
                                        if (IsnullMaster != null)
                                        {
                                            var ExistMaster = _appDbContext.ToolandtechTechnologies.Where(x => x.IsDeleted == false && x.Name == IsnullMaster).FirstOrDefault();
                                            if (ExistMaster == null)
                                            {


                                                if (NameIndex != -1)
                                                {
                                                    var Com = (reader.GetValue(NameIndex) == null) ? null : reader.GetValue(NameIndex).ToString();
                                                    if (Com != null)
                                                    {
                                                        ImportMaster.Name = (reader.GetValue(NameIndex) == null) ? null : reader.GetValue(NameIndex).ToString();
                                                    }
                                                    if (DescriptionIndex != -1)
                                                    {
                                                        ImportMaster.Description = (reader.GetValue(DescriptionIndex) == null) ? null : reader.GetValue(DescriptionIndex).ToString();
                                                    }
                                                    ImportMaster.IsDeleted = false;
                                                    ImportMaster.CreatedAt = DateTime.Now;
                                                    ImportMaster.PublicId = Guid.NewGuid();
                                                    ImportMaster.CreatedBy = (long)MapedField.File.CreatedBy;
                                                    _appDbContext.ToolandtechTechnologies.Add(ImportMaster);
                                                    _appDbContext.SaveChanges();
                                                }

                                            }
                                            else if (MapedField.File.SkipDuplicate == true)
                                            {
                                                var MasterId = ExistMaster.Id;
                                                if (NameIndex != -1)
                                                {

                                                    var UpdateMaster = _appDbContext.ToolandtechTechnologies.Where(x => x.IsDeleted == false && x.Id == MasterId).FirstOrDefault();
                                                    if (UpdateMaster != null)
                                                    {
                                                        UpdateMaster.Name = (reader.GetValue(NameIndex) == null) ? null : reader.GetValue(NameIndex).ToString();
                                                        //ImportCompany.RegistrationNo = (reader.GetValue(RegistrationNoIndex) == null) ? null : reader.GetValue(RegistrationNoIndex).ToString();
                                                        if (NameIndex != -1)
                                                        {
                                                            var name = reader.GetValue(NameIndex);
                                                            if (name != "")
                                                            {

                                                                if (UpdateMaster.Name == null)
                                                                {
                                                                    UpdateMaster.Name = (reader.GetValue(NameIndex) == null) ? null : reader.GetValue(NameIndex).ToString();
                                                                }

                                                            }

                                                        }
                                                        if (DescriptionIndex != -1)
                                                        {
                                                            var desr = reader.GetValue(DescriptionIndex);
                                                            if (desr != "")
                                                            {
                                                                if (UpdateMaster.Description == null)
                                                                {
                                                                    UpdateMaster.Name = (reader.GetValue(NameIndex) == null) ? null : reader.GetValue(NameIndex).ToString();
                                                                }
                                                            }



                                                        }
                                                        UpdateMaster.IsDeleted = false;
                                                        UpdateMaster.ModifiedAt = DateTime.Now;
                                                        UpdateMaster.PublicId = Guid.NewGuid();
                                                        UpdateMaster.ModifiedBy = MapedField.File.CreatedBy;
                                                        await _appDbContext.SaveChangesAsync();

                                                        SkipedMasters = SkipedMasters + 1;

                                                    }

                                                }
                                            }
                                            else if (MapedField.File.OverwriteDuplicate == true)
                                            {
                                                var MasterId = ExistMaster.Id;
                                                if (NameIndex != -1)
                                                {
                                                    var UpdateMaster = _appDbContext.ToolandtechTechnologies.Where(x => x.IsDeleted == false && x.Id == MasterId).FirstOrDefault();
                                                    if (UpdateMaster != null)
                                                    {
                                                        var Com = (reader.GetValue(NameIndex) == null) ? null : reader.GetValue(NameIndex).ToString();
                                                        if (Com != null)
                                                        {
                                                            UpdateMaster.Name = (reader.GetValue(NameIndex) == null) ? null : reader.GetValue(NameIndex).ToString();
                                                            //ImportCompany.RegistrationNo = (reader.GetValue(RegistrationNoIndex) == null) ? null : reader.GetValue(RegistrationNoIndex).ToString();
                                                            if (DescriptionIndex != -1)
                                                            {
                                                                var regsi = reader.GetValue(DescriptionIndex);
                                                                if (regsi != "")
                                                                {
                                                                    UpdateMaster.Description = (reader.GetValue(DescriptionIndex) == null) ? null : reader.GetValue(DescriptionIndex).ToString();
                                                                }

                                                            }
                                                            UpdateMaster.IsDeleted = false;
                                                            UpdateMaster.PublicId = Guid.NewGuid();
                                                            UpdateMaster.ModifiedAt = DateTime.Now;
                                                            UpdateMaster.ModifiedBy = MapedField.File.CreatedBy;
                                                            await _appDbContext.SaveChangesAsync();

                                                            Overwritemasters = Overwritemasters + 1;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        #endregion
                                    }
                                    while (reader.NextResult()) ;

                                }


                            }
                            #region Maitain Import History
                            // to maintain excel sheet history                  
                            //ImportHistory addnew = new ImportHistory();
                            //addnew.ImportedAt = DateTime.Now;
                            //addnew.ImportedBy = MapedField.File.CreatedBy;
                            //addnew.FilePath = filePatth;
                            ////addnew.ExcelFileName = MapedField.File.FileName.Trim(0,_).;
                            //addnew.ModuleId = 3;
                            //addnew.ExcelNameBySystem = MapedField.File.FileName;
                            //_appDbContext.ImportHistory.Add(addnew);
                            //_appDbContext.SaveChanges();
                            #endregion

                            finalreturnModel.Message = "Masters Imported Successfully!";
                            finalreturnModel.Success = true;
                        }
                        return finalreturnModel;
                    }

                }
                while (reader.NextResult()) ;

                finalreturnModel.Message = "Something went wrong!";
                finalreturnModel.Success = false;
                return finalreturnModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<object> ImportFunctionalAreas(importdatanew MapedField)
        {
            try
            {
                if (MapedField.File.FileName == null)
                {
                    finalreturnModel.Message = "File not found!";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }
                if (MapedField == null)
                {
                    finalreturnModel.Message = "Model can not be null!";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }
                if (MapedField.importmasters.NameIndexId == null)
                {
                    finalreturnModel.Message = "Required field not maped!";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }
                if (MapedField.importmasters.Name == "")
                {
                    finalreturnModel.Message = "masters field not maped!";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }
                if (MapedField.importmasters.Name == "string")
                {
                    finalreturnModel.Message = "masters field not maped!";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }

                int SkipedMasters = 0;
                //int ImportedMasters = 0;
                int Overwritemasters = 0;

                var filePatth = GetFilePath1(MapedField.File.FileName); //Common.
                var Provider = new FileExtensionContentTypeProvider();
                if (!Provider.TryGetContentType(filePatth, out var _contentType))
                {
                    _contentType = "application/octet-stream";

                }
                var _ReadAllBytesAsync = await File.ReadAllBytesAsync(filePatth);
                var data = (_ReadAllBytesAsync, _contentType, Path.GetFileName(filePatth));

                FileStream stream = new FileStream(filePatth, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream);
                DataSet dataSet = reader.AsDataSet(
                    configuration: new ExcelExcelDataSetConfiguation()
                    {

                        UseColumnDataType = false,
                        ConfigureDataTable = (IExcelDataReader) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true
                        }

                    });
                var count = reader.RowCount;
                while (reader.Read())
                {
                    var ExcelFieldCount1 = reader.FieldCount;
                    for (int n = 0; n < ExcelFieldCount1; n++)
                    {
                        var ExcelRowColumnisNull = (reader.GetValue(n) == null) ? null : reader.GetValue(n).ToString();
                        if (ExcelRowColumnisNull != null)
                        {
                            for (int i = 0; i < count; i++)
                            {
                                if (i == n)
                                {
                                    var finalMappedColumnsIndex = new List<Dictionary<string, int>>();
                                    var ExcelFieldCount = reader.FieldCount;
                                    for (int f = 0; f < ExcelFieldCount; f++)
                                    {
                                        var ExcelColumn = (reader.GetValue(f) == null) ? null : reader.GetValue(f).ToString();
                                        var myDictinary = new Dictionary<string, int>();
                                        myDictinary.Add(ExcelColumn, f);
                                        finalMappedColumnsIndex.Add(myDictinary);
                                    }
                                    int NameIndex = -1;
                                    int DescriptionIndex = -1;

                                    foreach (var item in finalMappedColumnsIndex)
                                    {
                                        #region Cheak Columns
                                        if (item.ContainsKey(MapedField.importmasters.Name))
                                        {
                                            NameIndex = item["Name"];
                                        }
                                        else if (item.ContainsKey(MapedField.importmasters.Description))
                                        {
                                            DescriptionIndex = item["Description"];
                                        }
                                        #endregion
                                    }
                                    while (reader.Read())

                                    {
                                        #region Insert Date In DataBase
                                        var ExcelRowColumnisNull1 = (reader.GetValue(n) == null) ? null : reader.GetValue(n).ToString();
                                        if (ExcelRowColumnisNull1 == null)
                                        {



                                        }
                                        var field = reader;
                                        FunctionalAreas ImportMaster = new FunctionalAreas();

                                        var IsnullMaster = (reader.GetValue(NameIndex) == null) ? null : reader.GetValue(NameIndex).ToString();
                                        if (IsnullMaster != null)
                                        {
                                            var ExistMaster = _appDbContext.FunctionalAreas.Where(x => x.IsDeleted == false && x.Name == IsnullMaster).FirstOrDefault();
                                            if (ExistMaster == null)
                                            {


                                                if (NameIndex != -1)
                                                {
                                                    var Com = (reader.GetValue(NameIndex) == null) ? null : reader.GetValue(NameIndex).ToString();
                                                    if (Com != null)
                                                    {
                                                        ImportMaster.Name = (reader.GetValue(NameIndex) == null) ? null : reader.GetValue(NameIndex).ToString();
                                                    }
                                                    if (DescriptionIndex != -1)
                                                    {
                                                        ImportMaster.Description = (reader.GetValue(DescriptionIndex) == null) ? null : reader.GetValue(DescriptionIndex).ToString();
                                                    }
                                                    ImportMaster.IsDeleted = false;
                                                    ImportMaster.CreatedAt = DateTime.Now;
                                                    ImportMaster.PublicId = Guid.NewGuid();
                                                    ImportMaster.CreatedBy = (long)MapedField.File.CreatedBy;
                                                    _appDbContext.FunctionalAreas.Add(ImportMaster);
                                                    _appDbContext.SaveChanges();
                                                }

                                            }
                                            else if (MapedField.File.SkipDuplicate == true)
                                            {
                                                var MasterId = ExistMaster.Id;
                                                if (NameIndex != -1)
                                                {

                                                    var UpdateMaster = _appDbContext.FunctionalAreas.Where(x => x.IsDeleted == false && x.Id == MasterId).FirstOrDefault();
                                                    if (UpdateMaster != null)
                                                    {
                                                        UpdateMaster.Name = (reader.GetValue(NameIndex) == null) ? null : reader.GetValue(NameIndex).ToString();
                                                        //ImportCompany.RegistrationNo = (reader.GetValue(RegistrationNoIndex) == null) ? null : reader.GetValue(RegistrationNoIndex).ToString();
                                                        if (NameIndex != -1)
                                                        {
                                                            var name = reader.GetValue(NameIndex);
                                                            if (name != "")
                                                            {

                                                                if (UpdateMaster.Name == null)
                                                                {
                                                                    UpdateMaster.Name = (reader.GetValue(NameIndex) == null) ? null : reader.GetValue(NameIndex).ToString();
                                                                }

                                                            }

                                                        }
                                                        if (DescriptionIndex != -1)
                                                        {
                                                            var desr = reader.GetValue(DescriptionIndex);
                                                            if (desr != "")
                                                            {
                                                                if (UpdateMaster.Description == null)
                                                                {
                                                                    UpdateMaster.Name = (reader.GetValue(NameIndex) == null) ? null : reader.GetValue(NameIndex).ToString();
                                                                }
                                                            }



                                                        }
                                                        UpdateMaster.IsDeleted = false;
                                                        UpdateMaster.ModifiedAt = DateTime.Now;
                                                        UpdateMaster.PublicId = Guid.NewGuid();
                                                        UpdateMaster.ModifiedBy = MapedField.File.CreatedBy;
                                                        await _appDbContext.SaveChangesAsync();

                                                        SkipedMasters = SkipedMasters + 1;

                                                    }

                                                }
                                            }
                                            else if (MapedField.File.OverwriteDuplicate == true)
                                            {
                                                var MasterId = ExistMaster.Id;
                                                if (NameIndex != -1)
                                                {
                                                    var UpdateMaster = _appDbContext.FunctionalAreas.Where(x => x.IsDeleted == false && x.Id == MasterId).FirstOrDefault();
                                                    if (UpdateMaster != null)
                                                    {
                                                        var Com = (reader.GetValue(NameIndex) == null) ? null : reader.GetValue(NameIndex).ToString();
                                                        if (Com != null)
                                                        {
                                                            UpdateMaster.Name = (reader.GetValue(NameIndex) == null) ? null : reader.GetValue(NameIndex).ToString();
                                                            //ImportCompany.RegistrationNo = (reader.GetValue(RegistrationNoIndex) == null) ? null : reader.GetValue(RegistrationNoIndex).ToString();
                                                            if (DescriptionIndex != -1)
                                                            {
                                                                var regsi = reader.GetValue(DescriptionIndex);
                                                                if (regsi != "")
                                                                {
                                                                    UpdateMaster.Description = (reader.GetValue(DescriptionIndex) == null) ? null : reader.GetValue(DescriptionIndex).ToString();
                                                                }

                                                            }
                                                            UpdateMaster.IsDeleted = false;
                                                            UpdateMaster.PublicId = Guid.NewGuid();
                                                            UpdateMaster.ModifiedAt = DateTime.Now;
                                                            UpdateMaster.ModifiedBy = MapedField.File.CreatedBy;
                                                            await _appDbContext.SaveChangesAsync();

                                                            Overwritemasters = Overwritemasters + 1;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        #endregion
                                    }
                                    while (reader.NextResult()) ;

                                }


                            }
                            #region Maitain Import History
                            // to maintain excel sheet history                  
                            //ImportHistory addnew = new ImportHistory();
                            //addnew.ImportedAt = DateTime.Now;
                            //addnew.ImportedBy = MapedField.File.CreatedBy;
                            //addnew.FilePath = filePatth;
                            ////addnew.ExcelFileName = MapedField.File.FileName.Trim(0,_).;
                            //addnew.ModuleId = 3;
                            //addnew.ExcelNameBySystem = MapedField.File.FileName;
                            //_appDbContext.ImportHistory.Add(addnew);
                            //_appDbContext.SaveChanges();
                            #endregion

                            finalreturnModel.Message = "Masters Imported Successfully!";
                            finalreturnModel.Success = true;
                        }
                        return finalreturnModel;
                    }

                }
                while (reader.NextResult()) ;

                finalreturnModel.Message = "Something went wrong!";
                finalreturnModel.Success = false;
                return finalreturnModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<object> ImportSubFunctionalAreas(importdatanew MapedField)
        {
            try
            {
                if (MapedField.File.FileName == null)
                {
                    finalreturnModel.Message = "File not found!";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }
                if (MapedField == null)
                {
                    finalreturnModel.Message = "Model can not be null!";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }
                if (MapedField.importmasters.NameIndexId == null)
                {
                    finalreturnModel.Message = "Required field not maped!";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }
                if (MapedField.importmasters.Name == "")
                {
                    finalreturnModel.Message = "masters field not maped!";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }
                if (MapedField.importmasters.Name == "string")
                {
                    finalreturnModel.Message = "masters field not maped!";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }

                int SkipedMasters = 0;
                //int ImportedMasters = 0;
                int Overwritemasters = 0;

                var filePatth = GetFilePath1(MapedField.File.FileName); //Common.
                var Provider = new FileExtensionContentTypeProvider();
                if (!Provider.TryGetContentType(filePatth, out var _contentType))
                {
                    _contentType = "application/octet-stream";

                }
                var _ReadAllBytesAsync = await File.ReadAllBytesAsync(filePatth);
                var data = (_ReadAllBytesAsync, _contentType, Path.GetFileName(filePatth));

                FileStream stream = new FileStream(filePatth, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream);
                DataSet dataSet = reader.AsDataSet(
                    configuration: new ExcelExcelDataSetConfiguation()
                    {

                        UseColumnDataType = false,
                        ConfigureDataTable = (IExcelDataReader) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true
                        }

                    });
                var count = reader.RowCount;
                while (reader.Read())
                {
                    var ExcelFieldCount1 = reader.FieldCount;
                    for (int n = 0; n < ExcelFieldCount1; n++)
                    {
                        var ExcelRowColumnisNull = (reader.GetValue(n) == null) ? null : reader.GetValue(n).ToString();
                        if (ExcelRowColumnisNull != null)
                        {
                            for (int i = 0; i < count; i++)
                            {
                                if (i == n)
                                {
                                    var finalMappedColumnsIndex = new List<Dictionary<string, int>>();
                                    var ExcelFieldCount = reader.FieldCount;
                                    for (int f = 0; f < ExcelFieldCount; f++)
                                    {
                                        var ExcelColumn = (reader.GetValue(f) == null) ? null : reader.GetValue(f).ToString();
                                        var myDictinary = new Dictionary<string, int>();
                                        myDictinary.Add(ExcelColumn, f);
                                        finalMappedColumnsIndex.Add(myDictinary);
                                    }
                                    int NameIndex = -1;
                                    int DescriptionIndex = -1;

                                    foreach (var item in finalMappedColumnsIndex)
                                    {
                                        #region Cheak Columns
                                        if (item.ContainsKey(MapedField.importmasters.Name))
                                        {
                                            NameIndex = item["Name"];
                                        }
                                        else if (item.ContainsKey(MapedField.importmasters.Description))
                                        {
                                            DescriptionIndex = item["Description"];
                                        }
                                        #endregion
                                    }
                                    while (reader.Read())

                                    {
                                        #region Insert Date In DataBase
                                        var ExcelRowColumnisNull1 = (reader.GetValue(n) == null) ? null : reader.GetValue(n).ToString();
                                        if (ExcelRowColumnisNull1 == null)
                                        {



                                        }
                                        var field = reader;
                                        SubFunctionalAreas ImportMaster = new SubFunctionalAreas();

                                        var IsnullMaster = (reader.GetValue(NameIndex) == null) ? null : reader.GetValue(NameIndex).ToString();
                                        if (IsnullMaster != null)
                                        {
                                            var ExistMaster = _appDbContext.SubFunctionalAreas.Where(x => x.IsDeleted == false && x.Name == IsnullMaster).FirstOrDefault();
                                            if (ExistMaster == null)
                                            {


                                                if (NameIndex != -1)
                                                {
                                                    var Com = (reader.GetValue(NameIndex) == null) ? null : reader.GetValue(NameIndex).ToString();
                                                    if (Com != null)
                                                    {
                                                        ImportMaster.Name = (reader.GetValue(NameIndex) == null) ? null : reader.GetValue(NameIndex).ToString();
                                                    }
                                                    if (DescriptionIndex != -1)
                                                    {
                                                        ImportMaster.Description = (reader.GetValue(DescriptionIndex) == null) ? null : reader.GetValue(DescriptionIndex).ToString();
                                                    }
                                                    ImportMaster.IsDeleted = false;
                                                    ImportMaster.CreatedAt = DateTime.Now;
                                                    ImportMaster.PublicId = Guid.NewGuid();
                                                    ImportMaster.CreatedBy = (long)MapedField.File.CreatedBy;
                                                    _appDbContext.SubFunctionalAreas.Add(ImportMaster);
                                                    _appDbContext.SaveChanges();
                                                }

                                            }
                                            else if (MapedField.File.SkipDuplicate == true)
                                            {
                                                var MasterId = ExistMaster.Id;
                                                if (NameIndex != -1)
                                                {

                                                    var UpdateMaster = _appDbContext.SubFunctionalAreas.Where(x => x.IsDeleted == false && x.Id == MasterId).FirstOrDefault();
                                                    if (UpdateMaster != null)
                                                    {
                                                        UpdateMaster.Name = (reader.GetValue(NameIndex) == null) ? null : reader.GetValue(NameIndex).ToString();
                                                        //ImportCompany.RegistrationNo = (reader.GetValue(RegistrationNoIndex) == null) ? null : reader.GetValue(RegistrationNoIndex).ToString();
                                                        if (NameIndex != -1)
                                                        {
                                                            var name = reader.GetValue(NameIndex);
                                                            if (name != "")
                                                            {

                                                                if (UpdateMaster.Name == null)
                                                                {
                                                                    UpdateMaster.Name = (reader.GetValue(NameIndex) == null) ? null : reader.GetValue(NameIndex).ToString();
                                                                }

                                                            }

                                                        }
                                                        if (DescriptionIndex != -1)
                                                        {
                                                            var desr = reader.GetValue(DescriptionIndex);
                                                            if (desr != "")
                                                            {
                                                                if (UpdateMaster.Description == null)
                                                                {
                                                                    UpdateMaster.Name = (reader.GetValue(NameIndex) == null) ? null : reader.GetValue(NameIndex).ToString();
                                                                }
                                                            }



                                                        }
                                                        UpdateMaster.IsDeleted = false;
                                                        UpdateMaster.ModifiedAt = DateTime.Now;
                                                        UpdateMaster.PublicId = Guid.NewGuid();
                                                        UpdateMaster.ModifiedBy = MapedField.File.CreatedBy;
                                                        await _appDbContext.SaveChangesAsync();

                                                        SkipedMasters = SkipedMasters + 1;

                                                    }

                                                }
                                            }
                                            else if (MapedField.File.OverwriteDuplicate == true)
                                            {
                                                var MasterId = ExistMaster.Id;
                                                if (NameIndex != -1)
                                                {
                                                    var UpdateMaster = _appDbContext.SubFunctionalAreas.Where(x => x.IsDeleted == false && x.Id == MasterId).FirstOrDefault();
                                                    if (UpdateMaster != null)
                                                    {
                                                        var Com = (reader.GetValue(NameIndex) == null) ? null : reader.GetValue(NameIndex).ToString();
                                                        if (Com != null)
                                                        {
                                                            UpdateMaster.Name = (reader.GetValue(NameIndex) == null) ? null : reader.GetValue(NameIndex).ToString();
                                                            //ImportCompany.RegistrationNo = (reader.GetValue(RegistrationNoIndex) == null) ? null : reader.GetValue(RegistrationNoIndex).ToString();
                                                            if (DescriptionIndex != -1)
                                                            {
                                                                var regsi = reader.GetValue(DescriptionIndex);
                                                                if (regsi != "")
                                                                {
                                                                    UpdateMaster.Description = (reader.GetValue(DescriptionIndex) == null) ? null : reader.GetValue(DescriptionIndex).ToString();
                                                                }

                                                            }
                                                            UpdateMaster.IsDeleted = false;
                                                            UpdateMaster.PublicId = Guid.NewGuid();
                                                            UpdateMaster.ModifiedAt = DateTime.Now;
                                                            UpdateMaster.ModifiedBy = MapedField.File.CreatedBy;
                                                            await _appDbContext.SaveChangesAsync();

                                                            Overwritemasters = Overwritemasters + 1;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        #endregion
                                    }
                                    while (reader.NextResult()) ;

                                }


                            }
                            #region Maitain Import History
                            // to maintain excel sheet history                  
                            //ImportHistory addnew = new ImportHistory();
                            //addnew.ImportedAt = DateTime.Now;
                            //addnew.ImportedBy = MapedField.File.CreatedBy;
                            //addnew.FilePath = filePatth;
                            ////addnew.ExcelFileName = MapedField.File.FileName.Trim(0,_).;
                            //addnew.ModuleId = 3;
                            //addnew.ExcelNameBySystem = MapedField.File.FileName;
                            //_appDbContext.ImportHistory.Add(addnew);
                            //_appDbContext.SaveChanges();
                            #endregion

                            finalreturnModel.Message = "Masters Imported Successfully!";
                            finalreturnModel.Success = true;
                        }
                        return finalreturnModel;
                    }

                }
                while (reader.NextResult()) ;

                finalreturnModel.Message = "Something went wrong!";
                finalreturnModel.Success = false;
                return finalreturnModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<object> ImportSuperFunctionalAreas(importdatanew MapedField)
        {
            try
            {
                if (MapedField.File.FileName == null)
                {
                    finalreturnModel.Message = "File not found!";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }
                if (MapedField == null)
                {
                    finalreturnModel.Message = "Model can not be null!";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }
                if (MapedField.importmasters.NameIndexId == null)
                {
                    finalreturnModel.Message = "Required field not maped!";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }
                if (MapedField.importmasters.Name == "")
                {
                    finalreturnModel.Message = "masters field not maped!";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }
                if (MapedField.importmasters.Name == "string")
                {
                    finalreturnModel.Message = "masters field not maped!";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }

                int SkipedMasters = 0;
                //int ImportedMasters = 0;
                int Overwritemasters = 0;

                var filePatth = GetFilePath1(MapedField.File.FileName); //Common.
                var Provider = new FileExtensionContentTypeProvider();
                if (!Provider.TryGetContentType(filePatth, out var _contentType))
                {
                    _contentType = "application/octet-stream";

                }
                var _ReadAllBytesAsync = await File.ReadAllBytesAsync(filePatth);
                var data = (_ReadAllBytesAsync, _contentType, Path.GetFileName(filePatth));

                FileStream stream = new FileStream(filePatth, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream);
                DataSet dataSet = reader.AsDataSet(
                    configuration: new ExcelExcelDataSetConfiguation()
                    {

                        UseColumnDataType = false,
                        ConfigureDataTable = (IExcelDataReader) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true
                        }

                    });
                var count = reader.RowCount;
                while (reader.Read())
                {
                    var ExcelFieldCount1 = reader.FieldCount;
                    for (int n = 0; n < ExcelFieldCount1; n++)
                    {
                        var ExcelRowColumnisNull = (reader.GetValue(n) == null) ? null : reader.GetValue(n).ToString();
                        if (ExcelRowColumnisNull != null)
                        {
                            for (int i = 0; i < count; i++)
                            {
                                if (i == n)
                                {
                                    var finalMappedColumnsIndex = new List<Dictionary<string, int>>();
                                    var ExcelFieldCount = reader.FieldCount;
                                    for (int f = 0; f < ExcelFieldCount; f++)
                                    {
                                        var ExcelColumn = (reader.GetValue(f) == null) ? null : reader.GetValue(f).ToString();
                                        var myDictinary = new Dictionary<string, int>();
                                        myDictinary.Add(ExcelColumn, f);
                                        finalMappedColumnsIndex.Add(myDictinary);
                                    }
                                    int NameIndex = -1;
                                    int DescriptionIndex = -1;

                                    foreach (var item in finalMappedColumnsIndex)
                                    {
                                        #region Cheak Columns
                                        if (item.ContainsKey(MapedField.importmasters.Name))
                                        {
                                            NameIndex = item["Name"];
                                        }
                                        else if (item.ContainsKey(MapedField.importmasters.Description))
                                        {
                                            DescriptionIndex = item["Description"];
                                        }
                                        #endregion
                                    }
                                    while (reader.Read())

                                    {
                                        #region Insert Date In DataBase
                                        var ExcelRowColumnisNull1 = (reader.GetValue(n) == null) ? null : reader.GetValue(n).ToString();
                                        if (ExcelRowColumnisNull1 == null)
                                        {



                                        }
                                        var field = reader;
                                        SuperFunctionalAreas ImportMaster = new SuperFunctionalAreas();

                                        var IsnullMaster = (reader.GetValue(NameIndex) == null) ? null : reader.GetValue(NameIndex).ToString();
                                        if (IsnullMaster != null)
                                        {
                                            var ExistMaster = _appDbContext.SuperFunctionalAreas.Where(x => x.IsDeleted == false && x.Name == IsnullMaster).FirstOrDefault();
                                            if (ExistMaster == null)
                                            {


                                                if (NameIndex != -1)
                                                {
                                                    var Com = (reader.GetValue(NameIndex) == null) ? null : reader.GetValue(NameIndex).ToString();
                                                    if (Com != null)
                                                    {
                                                        ImportMaster.Name = (reader.GetValue(NameIndex) == null) ? null : reader.GetValue(NameIndex).ToString();
                                                    }
                                                    if (DescriptionIndex != -1)
                                                    {
                                                        ImportMaster.Description = (reader.GetValue(DescriptionIndex) == null) ? null : reader.GetValue(DescriptionIndex).ToString();
                                                    }
                                                    ImportMaster.IsDeleted = false;
                                                    ImportMaster.CreatedAt = DateTime.Now;
                                                    ImportMaster.PublicId = Guid.NewGuid();
                                                    ImportMaster.CreatedBy = (long)MapedField.File.CreatedBy;
                                                    _appDbContext.SuperFunctionalAreas.Add(ImportMaster);
                                                    _appDbContext.SaveChanges();
                                                }

                                            }
                                            else if (MapedField.File.SkipDuplicate == true)
                                            {
                                                var MasterId = ExistMaster.Id;
                                                if (NameIndex != -1)
                                                {

                                                    var UpdateMaster = _appDbContext.SuperFunctionalAreas.Where(x => x.IsDeleted == false && x.Id == MasterId).FirstOrDefault();
                                                    if (UpdateMaster != null)
                                                    {
                                                        UpdateMaster.Name = (reader.GetValue(NameIndex) == null) ? null : reader.GetValue(NameIndex).ToString();
                                                        //ImportCompany.RegistrationNo = (reader.GetValue(RegistrationNoIndex) == null) ? null : reader.GetValue(RegistrationNoIndex).ToString();
                                                        if (NameIndex != -1)
                                                        {
                                                            var name = reader.GetValue(NameIndex);
                                                            if (name != "")
                                                            {

                                                                if (UpdateMaster.Name == null)
                                                                {
                                                                    UpdateMaster.Name = (reader.GetValue(NameIndex) == null) ? null : reader.GetValue(NameIndex).ToString();
                                                                }

                                                            }

                                                        }
                                                        if (DescriptionIndex != -1)
                                                        {
                                                            var desr = reader.GetValue(DescriptionIndex);
                                                            if (desr != "")
                                                            {
                                                                if (UpdateMaster.Description == null)
                                                                {
                                                                    UpdateMaster.Name = (reader.GetValue(NameIndex) == null) ? null : reader.GetValue(NameIndex).ToString();
                                                                }
                                                            }



                                                        }
                                                        UpdateMaster.IsDeleted = false;
                                                        UpdateMaster.ModifiedAt = DateTime.Now;
                                                        UpdateMaster.PublicId = Guid.NewGuid();
                                                        UpdateMaster.ModifiedBy = MapedField.File.CreatedBy;
                                                        await _appDbContext.SaveChangesAsync();

                                                        SkipedMasters = SkipedMasters + 1;

                                                    }

                                                }
                                            }
                                            else if (MapedField.File.OverwriteDuplicate == true)
                                            {
                                                var MasterId = ExistMaster.Id;
                                                if (NameIndex != -1)
                                                {
                                                    var UpdateMaster = _appDbContext.SuperFunctionalAreas.Where(x => x.IsDeleted == false && x.Id == MasterId).FirstOrDefault();
                                                    if (UpdateMaster != null)
                                                    {
                                                        var Com = (reader.GetValue(NameIndex) == null) ? null : reader.GetValue(NameIndex).ToString();
                                                        if (Com != null)
                                                        {
                                                            UpdateMaster.Name = (reader.GetValue(NameIndex) == null) ? null : reader.GetValue(NameIndex).ToString();
                                                            //ImportCompany.RegistrationNo = (reader.GetValue(RegistrationNoIndex) == null) ? null : reader.GetValue(RegistrationNoIndex).ToString();
                                                            if (DescriptionIndex != -1)
                                                            {
                                                                var regsi = reader.GetValue(DescriptionIndex);
                                                                if (regsi != "")
                                                                {
                                                                    UpdateMaster.Description = (reader.GetValue(DescriptionIndex) == null) ? null : reader.GetValue(DescriptionIndex).ToString();
                                                                }

                                                            }
                                                            UpdateMaster.IsDeleted = false;
                                                            UpdateMaster.PublicId = Guid.NewGuid();
                                                            UpdateMaster.ModifiedAt = DateTime.Now;
                                                            UpdateMaster.ModifiedBy = MapedField.File.CreatedBy;
                                                            await _appDbContext.SaveChangesAsync();

                                                            Overwritemasters = Overwritemasters + 1;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        #endregion
                                    }
                                    while (reader.NextResult()) ;

                                }


                            }
                            #region Maitain Import History
                            // to maintain excel sheet history                  
                            //ImportHistory addnew = new ImportHistory();
                            //addnew.ImportedAt = DateTime.Now;
                            //addnew.ImportedBy = MapedField.File.CreatedBy;
                            //addnew.FilePath = filePatth;
                            ////addnew.ExcelFileName = MapedField.File.FileName.Trim(0,_).;
                            //addnew.ModuleId = 3;
                            //addnew.ExcelNameBySystem = MapedField.File.FileName;
                            //_appDbContext.ImportHistory.Add(addnew);
                            //_appDbContext.SaveChanges();
                            #endregion

                            finalreturnModel.Message = "Masters Imported Successfully!";
                            finalreturnModel.Success = true;
                        }
                        return finalreturnModel;
                    }

                }
                while (reader.NextResult()) ;

                finalreturnModel.Message = "Something went wrong!";
                finalreturnModel.Success = false;
                return finalreturnModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }





        //public object Export()
        //{

        //    var SuperClassification = (from cls in _appDbContext.SuperClassification
        //                          select new
        //                          {
        //                              Name = cls.Name,
        //                              Description = cls.Description

        //                          }).ToList();

        //    using (var package = new ExcelPackage(new FileInfo("SuperClassifiaction.xlsx")))
        //    {
        //        var worksheet = package.Workbook.Worksheets.Add("City State Data");

        //        worksheet.Cells[1, 1].Value = " Name";
        //        worksheet.Cells[1, 2].Value = " Description";

        //        for (int i = 0; i < SuperClassification.Count; i++)
        //        {
        //            worksheet.Cells[i + 2, 1].Value = SuperClassification[i].Name;
        //            worksheet.Cells[i + 2, 2].Value = SuperClassification[i].Description;
        //        }

        //        var fileContent = package.GetAsByteArray();

        //        var bas64 = Convert.ToBase64String(fileContent);

        //        return bas64;
        //    }
        //}


        public object AddUpdateCurrentEmployee(Currentemp add)
        {
            try
            {

                if (add.UserId == 0)
                {
                    finalreturnModel.Message = "id is not found";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }

                if (add.Name == null)
                {
                    finalreturnModel.Message = " name is equired";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }
                if (add.Id != 0)
                {
                    var userId = add.Id;
                    var IsExist = _appDbContext.CurrentEmployee.Where(x => x.Id == userId).FirstOrDefault();
                    if (IsExist != null)
                    {
                        IsExist.Name = add.Name;
                        IsExist.Description = add.Description;
                        //IsExist.ModifiedBy = add.UserId;
                        ////IsExist.CreatedAt = DateTime.Now;
                        //IsExist.ModifiedAt = DateTime.Now;

                        _appDbContext.SaveChanges();

                        finalreturnModel.Message = "update successfully";
                        finalreturnModel.Success = true;
                        return finalreturnModel;
                    }
                    else
                    {
                        finalreturnModel.Message = "Id not found";
                        finalreturnModel.Success = false;
                        return finalreturnModel;
                    }

                }
                else
                {
                    var Exist = _appDbContext.CurrentEmployee.Where(x => x.Name == add.Name).FirstOrDefault();
                    if (add.UserId == 0)
                    {
                        finalreturnModel.Message = "id is not found";
                        finalreturnModel.Success = false;
                        return finalreturnModel;
                    }
                    if (Exist == null)
                    {
                        CurrentEmployee newGrade = new CurrentEmployee();
                        newGrade.Name = add.Name;
                        Guid newguid = new Guid();
                        newGrade.PublicId = Guid.NewGuid();
                        newGrade.Description = add.Description;
                        newGrade.CreatedBy = add.UserId;
                        newGrade.CreatedAt = DateTime.Now;
                        //newGrade.ModifiedAt = DateTime.Now;
                        _appDbContext.CurrentEmployee.Add(newGrade);
                        _appDbContext.SaveChanges();

                        finalreturnModel.Message = " add successfully";
                        finalreturnModel.Success = true;
                        return finalreturnModel;
                    }
                    else
                    {
                        finalreturnModel.Message = "allready exist";
                        finalreturnModel.Success = false;
                        return finalreturnModel;
                    }
                }
            }
            catch (System.Exception ex)
            {
                finalreturnModel.Message = ex.Message;
                if (ex.InnerException != null)
                    finalreturnModel.Message = finalreturnModel.Message + "\n" + ex.InnerException.Message.ToString();

                finalreturnModel.Success = false;
                return finalreturnModel;
            }
        }

        public object GetCurrentemployee()
        {
            var product = (from e in _appDbContext.CurrentEmployee
                           join u in _appDbContext.Users on e.CreatedBy equals u.UserId into deptGroup
                           from u in deptGroup.DefaultIfEmpty()
                           join um in _appDbContext.Users on e.ModifiedBy equals um.UserId into deptmGroup
                           from um in deptmGroup.DefaultIfEmpty()
                           select new
                           {
                               e.Id,
                               e.Name,
                               e.Description,
                               //e.CreatedBy,
                               //e.CreatedAt,
                               //e.ModifiedBy,
                               //e.ModifiedAt,
                               //e.IsDeleted,
                               //CreatedById = e.CreatedBy,
                               CreatedByName = u.UserName,
                               ModifiedByName = um.UserName,
                               e.ModifiedAt,

                               //Users = u != null ? u.USerName: null
                           }).ToList();
            var data = product.AsQueryable();
            var datanew = data.OrderByDescending(x => x.ModifiedAt).ToList();
            finalreturnModel.Success = true;
            return (datanew);
        }


        public object DeleteCurrentEmployee(int employeeid)
        {
            try
            {
                if (employeeid == 0)
                {
                    finalreturnModel.Message = "id is required";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }
                var Remove = _appDbContext.CurrentEmployee.Where(X => X.Id == employeeid).FirstOrDefault();
                if (Remove != null)
                {
                    _appDbContext.Remove(Remove);
                    _appDbContext.SaveChanges();
                    finalreturnModel.Success = true;
                    return finalreturnModel;
                }
                else
                {
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }


            }
            catch (System.Exception ex)
            {
                finalreturnModel.Message = ex.Message;
                if (ex.InnerException != null)
                    finalreturnModel.Message = finalreturnModel.Message + "\n" + ex.InnerException.Message.ToString();

                finalreturnModel.Success = false;
                return finalreturnModel;
            }

        }


        public object AddUpdateEducationkey(Educationkey add)
        {
            try
            {
                if (add.UserId == 0)
                {
                    finalreturnModel.Message = "id is not found";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }

                if (add.Name == null)
                {
                    finalreturnModel.Message = " name is equired";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }
                if (add.Id != 0)
                {
                    var userId = add.Id;
                    var IsExist = _appDbContext.EducationKeywords.Where(x => x.Id == userId).FirstOrDefault();
                    if (IsExist != null)
                    {
                        IsExist.Name = add.Name;
                        IsExist.Description = add.Description;
                        //IsExist.ModifiedBy = add.UserId;
                        //IsExist.CreatedAt = DateTime.Now;
                        //IsExist.ModifiedAt = DateTime.Now;

                        _appDbContext.SaveChanges();

                        finalreturnModel.Message = "update successfully";
                        finalreturnModel.Success = true;
                        return finalreturnModel;
                    }
                    else
                    {
                        finalreturnModel.Message = "Id not found";
                        finalreturnModel.Success = false;
                        return finalreturnModel;
                    }

                }
                else
                {
                    var Exist = _appDbContext.EducationKeywords.Where(x => x.Name == add.Name).FirstOrDefault();
                    if (add.UserId == 0)
                    {
                        finalreturnModel.Message = "id is not found";
                        finalreturnModel.Success = false;
                        return finalreturnModel;
                    }
                    if (Exist == null)
                    {
                        EducationKeywords newGrade = new EducationKeywords();
                        newGrade.Name = add.Name;
                        newGrade.Description = add.Description;
                        newGrade.CreatedBy = add.UserId;
                        Guid newguid = new Guid();
                        newGrade.PublicId = Guid.NewGuid();
                        newGrade.CreatedAt = DateTime.Now;
                        //newGrade.ModifiedAt = DateTime.Now;
                        _appDbContext.EducationKeywords.Add(newGrade);
                        _appDbContext.SaveChanges();

                        finalreturnModel.Message = " add successfully";
                        finalreturnModel.Success = true;
                        return finalreturnModel;
                    }
                    else
                    {
                        finalreturnModel.Message = "allready exist";
                        finalreturnModel.Success = false;
                        return finalreturnModel;
                    }
                }
            }
            catch (System.Exception ex)
            {
                finalreturnModel.Message = ex.Message;
                if (ex.InnerException != null)
                    finalreturnModel.Message = finalreturnModel.Message + "\n" + ex.InnerException.Message.ToString();

                finalreturnModel.Success = false;
                return finalreturnModel;
            }
        }

        public object GetEducationKey()
        {
            var product = (from e in _appDbContext.EducationKeywords
                           join u in _appDbContext.Users on e.CreatedBy equals u.UserId into deptGroup
                           from u in deptGroup.DefaultIfEmpty()
                           join um in _appDbContext.Users on e.ModifiedBy equals um.UserId into deptmGroup
                           from um in deptmGroup.DefaultIfEmpty()
                           select new
                           {
                               e.Id,
                               e.Name,
                               e.Description,
                               //e.CreatedBy,
                               //e.CreatedAt,
                               //e.ModifiedBy,
                               //e.ModifiedAt,
                               //e.IsDeleted,
                               //CreatedById = e.CreatedBy,
                               CreatedByName = u.UserName,
                               ModifiedByName = um.UserName,
                               e.ModifiedAt,

                               //Users = u != null ? u.USerName: null
                           }).ToList();
            var data = product.AsQueryable();
            var datanew = data.OrderByDescending(x => x.ModifiedAt).ToList();
            finalreturnModel.Success = true;
            return (datanew);
        }

        public object AddUpdateCoursecategory(Coursecate add)
        {
            try
            {
                if (add.UserId == 0)
                {
                    finalreturnModel.Message = "id is not found";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }

                if (add.Name == null)
                {
                    finalreturnModel.Message = " name is equired";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }
                if (add.Id != 0)
                {
                    var userId = add.Id;
                    var IsExist = _appDbContext.Coursecategory.Where(x => x.Id == userId).FirstOrDefault();
                    if (IsExist != null)
                    {
                        IsExist.Name = add.Name;
                        IsExist.Description = add.Description;
                        IsExist.ModifiedBy = add.UserId;
                        ////IsExist.CreatedAt = DateTime.Now;
                        IsExist.ModifiedAt = DateTime.Now;

                        _appDbContext.SaveChanges();

                        finalreturnModel.Message = "update successfully";
                        finalreturnModel.Success = true;
                        return finalreturnModel;
                    }
                    else
                    {
                        finalreturnModel.Message = "Id not found";
                        finalreturnModel.Success = false;
                        return finalreturnModel;
                    }

                }
                else
                {
                    var Exist = _appDbContext.Coursecategory.Where(x => x.Name == add.Name).FirstOrDefault();
                    if (add.UserId == 0)
                    {
                        finalreturnModel.Message = "id is not found";
                        finalreturnModel.Success = false;
                        return finalreturnModel;
                    }
                    if (Exist == null)
                    {
                        Coursecategory newGrade = new Coursecategory();
                        newGrade.Name = add.Name;
                        Guid newguid = new Guid();
                        newGrade.PublicId = Guid.NewGuid();
                        newGrade.Description = add.Description;
                        newGrade.CreatedBy = add.UserId;
                        newGrade.CreatedAt = DateTime.Now;
                        //newGrade.ModifiedAt = DateTime.Now;
                        _appDbContext.Coursecategory.Add(newGrade);
                        _appDbContext.SaveChanges();

                        finalreturnModel.Message = " add successfully";
                        finalreturnModel.Success = true;
                        return finalreturnModel;
                    }
                    else
                    {
                        finalreturnModel.Message = "allready exist";
                        finalreturnModel.Success = false;
                        return finalreturnModel;
                    }
                }
            }
            catch (System.Exception ex)
            {
                finalreturnModel.Message = ex.Message;
                if (ex.InnerException != null)
                    finalreturnModel.Message = finalreturnModel.Message + "\n" + ex.InnerException.Message.ToString();

                finalreturnModel.Success = false;
                return finalreturnModel;
            }
        }

        public object GetCoursecategory()
        {
            var product = (from e in _appDbContext.Coursecategory
                           join u in _appDbContext.Users on e.CreatedBy equals u.UserId into deptGroup
                           from u in deptGroup.DefaultIfEmpty()
                           join um in _appDbContext.Users on e.ModifiedBy equals um.UserId into deptmGroup
                           from um in deptmGroup.DefaultIfEmpty()
                           select new
                           {
                               e.Id,
                               e.Name,
                               e.Description,
                               //e.CreatedBy,
                               //e.CreatedAt,
                               //e.ModifiedBy,
                               //e.ModifiedAt,
                               //e.IsDeleted,
                               //CreatedById = e.CreatedBy,
                               CreatedByName = u.UserName,
                               ModifiedByName = um.UserName,
                               e.ModifiedAt,

                               //Users = u != null ? u.USerName: null
                           }).ToList();
            var data = product.AsQueryable();
            var datanew = data.OrderByDescending(x => x.ModifiedAt).ToList();
            finalreturnModel.Success = true;
            return (datanew);
        }

        public object AddUpdateSkill(Skill add)
        {
            try
            {
                if (add.UserId == 0)
                {
                    finalreturnModel.Message = "id is not found";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }

                if (add.Name == null)
                {
                    finalreturnModel.Message = " name is equired";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }
                if (add.Id != 0)
                {
                    var userId = add.Id;
                    var IsExist = _appDbContext.Skills.Where(x => x.Id == userId).FirstOrDefault();
                    if (IsExist != null)
                    {
                        IsExist.Name = add.Name;
                        IsExist.Description = add.Description;
                        //IsExist.ModifiedBy = add.UserId;
                        ////IsExist.CreatedAt = DateTime.Now;
                        //IsExist.ModifiedAt = DateTime.Now;

                        _appDbContext.SaveChanges();

                        finalreturnModel.Message = "update successfully";
                        finalreturnModel.Success = true;
                        return finalreturnModel;
                    }
                    else
                    {
                        finalreturnModel.Message = "Id not found";
                        finalreturnModel.Success = false;
                        return finalreturnModel;
                    }

                }
                else
                {
                    var Exist = _appDbContext.Skills.Where(x => x.Name == add.Name).FirstOrDefault();
                    if (add.UserId == 0)
                    {
                        finalreturnModel.Message = "id is not found";
                        finalreturnModel.Success = false;
                        return finalreturnModel;
                    }
                    if (Exist == null)
                    {
                        Skills newGrade = new Skills();
                        newGrade.Name = add.Name;
                        Guid newguid = new Guid();
                        newGrade.PublicId = Guid.NewGuid();
                        newGrade.Description = add.Description;
                        newGrade.CreatedBy = add.UserId;
                        newGrade.CreatedAt = DateTime.Now;
                        //newGrade.ModifiedAt = DateTime.Now;
                        _appDbContext.Skills.Add(newGrade);
                        _appDbContext.SaveChanges();

                        finalreturnModel.Message = " add successfully";
                        finalreturnModel.Success = true;
                        return finalreturnModel;
                    }
                    else
                    {
                        finalreturnModel.Message = "allready exist";
                        finalreturnModel.Success = false;
                        return finalreturnModel;
                    }
                }
            }
            catch (System.Exception ex)
            {
                finalreturnModel.Message = ex.Message;
                if (ex.InnerException != null)
                    finalreturnModel.Message = finalreturnModel.Message + "\n" + ex.InnerException.Message.ToString();

                finalreturnModel.Success = false;
                return finalreturnModel;
            }
        }

        public object GetSkill()
        {
            var product = (from e in _appDbContext.Skills
                           join u in _appDbContext.Users on e.CreatedBy equals u.UserId into deptGroup
                           from u in deptGroup.DefaultIfEmpty()
                           join um in _appDbContext.Users on e.ModifiedBy equals um.UserId into deptmGroup
                           from um in deptmGroup.DefaultIfEmpty()
                           select new
                           {
                               e.Id,
                               e.Name,
                               e.Description,
                               //e.CreatedBy,
                               //e.CreatedAt,
                               //e.ModifiedBy,
                               //e.ModifiedAt,
                               //e.IsDeleted,
                               //CreatedById = e.CreatedBy,
                               CreatedByName = u.UserName,
                               ModifiedByName = um.UserName,
                               e.ModifiedAt,

                               //Users = u != null ? u.USerName: null
                           }).ToList();
            var data = product.AsQueryable();
            var datanew = data.OrderByDescending(x => x.ModifiedAt).ToList();
            finalreturnModel.Success = true;
            return (datanew);
        }


        public object AddUpdateJobCurrentEmployee(JobCurrentemp add)
        {
            try
            {
                if (add.JobId == 0)
                {
                    finalreturnModel.Message = "Id is Required";

                }

                if (add.Id != 0)
                {
                    var currentempId = add.CurrentEmployeeId;
                    foreach (var item in currentempId)
                    {
                        var IsExist = _appDbContext.JobCurrentEmployeerelation.Where(x => x.Id == add.Id && x.CurrentEmployeeId == item).FirstOrDefault();
                        if (IsExist != null)
                        {
                            IsExist.JobId = add.JobId;
                            //IsExist.createdBy = add.createdBy;
                            //IsExist.Createddate = add.Createddate;
                            IsExist.CurrentEmployeeId= item;

                            _appDbContext.SaveChanges();


                        }
                        else
                        {
                            finalreturnModel.Message = "Id not found";
                            finalreturnModel.Success = false;
                            return finalreturnModel;
                        }
                    }
                    finalreturnModel.Message = "update successfully";
                    finalreturnModel.Success = true;
                    return finalreturnModel;
                }

                else
                {
                    var tId = add.CurrentEmployeeId;
                    foreach (var item in tId)
                    {
                        var Exist = _appDbContext.JobCurrentEmployeerelation.Where(x => x.JobId == add.JobId && x.CurrentEmployeeId == item).FirstOrDefault();
                        if (Exist == null)
                        {
                            JobCurrentEmployeerelation newGrade = new JobCurrentEmployeerelation();
                            newGrade.JobId = add.JobId;
                            newGrade.CurrentEmployeeId = item;
                            newGrade.CreatedBy = add.CreatedBy;
                            newGrade.Createddate = add.Createddate;
                            _appDbContext.JobCurrentEmployeerelation.Add(newGrade);
                            _appDbContext.SaveChanges();
                            finalreturnModel.Message = " add successfully";
                            finalreturnModel.Success = true;
                            return finalreturnModel;
                        }
                    }
                    finalreturnModel.Message = "allready exist";
                    finalreturnModel.Success = false;
                    return finalreturnModel;

                }


            }
            catch (System.Exception ex)
            {
                finalreturnModel.Message = ex.Message;
                if (ex.InnerException != null)
                    finalreturnModel.Message = finalreturnModel.Message + "\n" + ex.InnerException.Message.ToString();

                finalreturnModel.Success = false;
                return finalreturnModel;
            }
        }

        //public object GetJobCurrentEmployee()
        //{
        //    var product = (from e in _appDbContext.JobCurrentEmployeerelation
        //                   join u in _appDbContext.Job on e.JobId equals u.Id into deptGroup
        //                   from u in deptGroup.DefaultIfEmpty()
        //                   join um in _appDbContext.CurrentEmployee on e.CurrentEmployeeId equals um.Id into deptmGroup
        //                   from um in deptmGroup.DefaultIfEmpty()
        //                   select new
        //                   {
        //                       e.Id,
        //                       e.JobId,
        //                       e.CurrentEmployeeId,
        //                       e.Createddate,
        //                       e.CreatedBy



        //                   }).ToList();

        //    return (product);
        //}

        public object GetJobCurrentEmployerid(int employeeid)
        {
            try
            {
                if (employeeid == 0)
                {
                    finalreturnModel.Message = "id is required";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }
                var result = (from pt in _appDbContext.JobCurrentEmployeerelation
                              join c in _appDbContext.Job on pt.JobId equals c.Id
                              join t in _appDbContext.CurrentEmployee on pt.CurrentEmployeeId equals t.Id
                              select new
                              {
                                  pt.Id,
                                  pt.JobId,
                                  pt.CurrentEmployeeId,
                              });

                if (result == null)
                {
                    finalreturnModel.Message = "Data not found!";
                    finalreturnModel.Success = true;
                    return finalreturnModel;
                }
                else
                {
                    return result;
                }

            }
            catch (System.Exception ex)
            {
                finalreturnModel.Message = ex.Message;
                if (ex.InnerException != null)
                    finalreturnModel.Message = finalreturnModel.Message + "\n" + ex.InnerException.Message.ToString();

                finalreturnModel.Success = false;
                return finalreturnModel;
            }

        }

        public object AddUpdateJobEducation(JobEducation add)
        {
            try
            {
                if (add.JobId == 0)
                {
                    finalreturnModel.Message = "Id is Required";

                }

                if (add.Id != 0)
                {
                    var currentempId = add.EducationKeywordsId;
                    foreach (var item in currentempId)
                    {
                        var IsExist = _appDbContext.JobEducationkeywords.Where(x => x.Id == add.Id && x.EducationKeywordsId == item).FirstOrDefault();
                        if (IsExist != null)
                        {
                            IsExist.JobId = add.JobId;
                            //IsExist.createdBy = add.createdBy;
                            //IsExist.Createddate = add.Createddate;
                            IsExist.EducationKeywordsId = item;

                            _appDbContext.SaveChanges();


                        }
                        else
                        {
                            finalreturnModel.Message = "Id not found";
                            finalreturnModel.Success = false;
                            return finalreturnModel;
                        }
                    }
                    finalreturnModel.Message = "update successfully";
                    finalreturnModel.Success = true;
                    return finalreturnModel;
                }

                else
                {
                    var tId = add.EducationKeywordsId;
                    foreach (var item in tId)
                    {
                        var Exist = _appDbContext.JobEducationkeywords.Where(x => x.JobId == add.JobId && x.EducationKeywordsId == item).FirstOrDefault();
                        if (Exist == null)
                        {
                            JobEducationkeywords newGrade = new JobEducationkeywords();
                            newGrade.JobId = add.JobId;
                            newGrade.EducationKeywordsId = item;
                            newGrade.CreatedBy = add.CreatedBy;
                            newGrade.Createddate = add.Createddate;
                            _appDbContext.JobEducationkeywords.Add(newGrade);
                            _appDbContext.SaveChanges();
                            finalreturnModel.Message = " add successfully";
                            finalreturnModel.Success = true;
                            return finalreturnModel;
                        }
                    }
                    finalreturnModel.Message = "allready exist";
                    finalreturnModel.Success = false;
                    return finalreturnModel;

                }


            }
            catch (System.Exception ex)
            {
                finalreturnModel.Message = ex.Message;
                if (ex.InnerException != null)
                    finalreturnModel.Message = finalreturnModel.Message + "\n" + ex.InnerException.Message.ToString();

                finalreturnModel.Success = false;
                return finalreturnModel;
            }
        }

        //public object GetJobEducation()
        //{
        //    var product = (from e in _appDbContext.JobEducationkeywords
        //                   join u in _appDbContext.Job on e.JobId equals u.Id into deptGroup
        //                   from u in deptGroup.DefaultIfEmpty()
        //                   join um in _appDbContext.EducationKeywords on e.EducationKeywordsId equals um.Id into deptmGroup
        //                   from um in deptmGroup.DefaultIfEmpty()
        //                   select new
        //                   {
        //                       e.Id,
        //                       e.JobId,
        //                       e.EducationKeywordsId,
        //                       e.Createddate,
        //                       e.createdBy



        //                   }).ToList();

        //    return (product);
        //}

        //public object GetJobEducationkeyword(int educationkeywordid)
        //{
        //    try
        //    {
        //        if (educationkeywordid == 0)
        //        {
        //            finalreturnModel.Message = "id is required";
        //            finalreturnModel.Success = false;
        //            return finalreturnModel;
        //        }
        //        var result = (from pt in _appDbContext.JobEducationkeywords
        //                      join c in _appDbContext.Job on pt.JobId equals c.Id
        //                      join t in _appDbContext.EducationKeywords on pt.CurrentEmployeeId equals t.Id
        //                      select new
        //                      {
        //                          pt.Id,
        //                          pt.JobId,
        //                          pt.CurrentEmployeeId,
        //                      });

        //        if (result == null)
        //        {
        //            finalreturnModel.Message = "Data not found!";
        //            finalreturnModel.Success = true;
        //            return finalreturnModel;
        //        }
        //        else
        //        {
        //            return result;
        //        }

        //    }
        //    catch (System.Exception ex)
        //    {
        //        finalreturnModel.Message = ex.Message;
        //        if (ex.InnerException != null)
        //            finalreturnModel.Message = finalreturnModel.Message + "\n" + ex.InnerException.Message.ToString();

        //        finalreturnModel.Success = false;
        //        return finalreturnModel;
        //    }

        //}


        //public object AddUpdateJobs(JobAddUpdateModel addUpdateModel)
        //{
        //    var transaction = _appDbContext.Database.BeginTransaction();
        //    try
        //    {

        //        if (addUpdateModel.JobEducation != null)
        //        {
        //            if (addUpdateModel.JobEducation.JobId == 0)
        //            {
        //                finalreturnModel.Message = "JobId is Required for Education";
        //                return finalreturnModel;
        //            }


        //            if (addUpdateModel.JobEducation.Id != 0)
        //            {
        //                var currentempId = addUpdateModel.JobEducation.EducationKeywordsId;
        //                foreach (var item in currentempId)
        //                {
        //                    var isExist = _appDbContext.JobEducationkeywords
        //                        .Where(x => x.Id == addUpdateModel.JobEducation.Id && x.EducationKeywordsId == item)
        //                        .FirstOrDefault();

        //                    if (isExist != null)
        //                    {
        //                        isExist.JobId = addUpdateModel.JobEducation.JobId;
        //                        isExist.EducationKeywordsId = item;
        //                        _appDbContext.SaveChanges();
        //                    }
        //                    else
        //                    {
        //                        finalreturnModel.Message = "Education Id not found";
        //                        finalreturnModel.Success = false;
        //                        return finalreturnModel;
        //                    }
        //                }
        //                finalreturnModel.Message = "Education updated successfully";
        //            }
        //            else
        //            {
        //                var tId = addUpdateModel.JobEducation.EducationKeywordsId;
        //                foreach (var item in tId)
        //                {
        //                    var exist = _appDbContext.JobEducationkeywords
        //                        .Where(x => x.JobId == addUpdateModel.JobEducation.JobId && x.EducationKeywordsId == item)
        //                        .FirstOrDefault();

        //                    if (exist == null)
        //                    {
        //                        JobEducationkeywords newGrade = new JobEducationkeywords
        //                        {
        //                            JobId = addUpdateModel.JobEducation.JobId,
        //                            EducationKeywordsId = item,
        //                            CreatedBy = addUpdateModel.JobEducation.CreatedBy,
        //                            Createddate = addUpdateModel.JobEducation.Createddate
        //                        };
        //                        _appDbContext.JobEducationkeywords.Add(newGrade);
        //                        _appDbContext.SaveChanges();
        //                    }
        //                }
        //                finalreturnModel.Message = "Education added successfully";
        //            }
        //        }


        //        if (addUpdateModel.JobSkills != null)
        //        {
        //            if (addUpdateModel.JobSkills.JobId == 0)
        //            {
        //                finalreturnModel.Message = "JobId is Required for skills";
        //                return finalreturnModel;
        //            }


        //            if (addUpdateModel.JobSkills.Id != 0)
        //            {
        //                var currentempId = addUpdateModel.JobSkills.SkillsId;
        //                foreach (var item in currentempId)
        //                {
        //                    var isExist = _appDbContext.JobSkills
        //                        .Where(x => x.Id == addUpdateModel.JobSkills.Id && x.SkillsId == item)
        //                        .FirstOrDefault();

        //                    if (isExist != null)
        //                    {
        //                        isExist.JobId = addUpdateModel.JobSkills.JobId;
        //                        isExist.SkillsId = item;
        //                        _appDbContext.SaveChanges();
        //                    }
        //                    else
        //                    {
        //                        finalreturnModel.Message = "skills Id not found";
        //                        finalreturnModel.Success = false;
        //                        return finalreturnModel;
        //                    }
        //                }
        //                finalreturnModel.Message = "skills updated successfully";
        //            }
        //            else
        //            {
        //                var tId = addUpdateModel.JobSkills.SkillsId;
        //                foreach (var item in tId)
        //                {
        //                    var exist = _appDbContext.JobSkills
        //                        .Where(x => x.JobId == addUpdateModel.JobSkills.JobId && x.SkillsId == item)
        //                        .FirstOrDefault();

        //                    if (exist == null)
        //                    {
        //                        JobSkills newGrade = new JobSkills
        //                        {
        //                            JobId = addUpdateModel.JobSkills.JobId,
        //                            EducationKeywordsId = item,
        //                            CreatedBy = addUpdateModel.JobSkills.CreatedBy,
        //                            Createddate = addUpdateModel.JobSkills.Createddate
        //                        };
        //                        _appDbContext.Jobskills.Add(newGrade);
        //                        _appDbContext.SaveChanges();
        //                    }
        //                }
        //                finalreturnModel.Message = "skills added successfully";
        //            }
        //        }

        //        if (addUpdateModel.JobCurrentemp != null)
        //        {
        //            if (addUpdateModel.JobCurrentemp.JobId == 0)
        //            {
        //                finalreturnModel.Message = "JobId is Required for Current Employee";
        //                return finalreturnModel;
        //            }


        //            if (addUpdateModel.JobCurrentemp.Id != 0)
        //            {
        //                var currentempId = addUpdateModel.JobCurrentemp.CurrentEmployeeId;
        //                foreach (var item in currentempId)
        //                {
        //                    var isExist = _appDbContext.JobCurrentEmployeerelation
        //                        .Where(x => x.Id == addUpdateModel.JobCurrentemp.Id && x.CurrentEmployeeId == item)
        //                        .FirstOrDefault();

        //                    if (isExist != null)
        //                    {
        //                        isExist.JobId = addUpdateModel.JobCurrentemp.JobId;
        //                        isExist.CurrentEmployeeId = item;
        //                        _appDbContext.SaveChanges();
        //                    }
        //                    else
        //                    {
        //                        finalreturnModel.Message = "Current Employee Id not found";
        //                        finalreturnModel.Success = false;
        //                        return finalreturnModel;
        //                    }
        //                }
        //                finalreturnModel.Message = "Current Employee updated successfully";
        //            }
        //            else
        //            {
        //                var tId = addUpdateModel.JobCurrentemp.CurrentEmployeeId;
        //                foreach (var item in tId)
        //                {
        //                    var exist = _appDbContext.JobCurrentEmployeerelation
        //                        .Where(x => x.JobId == addUpdateModel.JobCurrentemp.JobId && x.CurrentEmployeeId == item)
        //                        .FirstOrDefault();

        //                    if (exist == null)
        //                    {
        //                        JobCurrentEmployeerelation newGrade = new JobCurrentEmployeerelation
        //                        {
        //                            JobId = addUpdateModel.JobCurrentemp.JobId,
        //                            CurrentEmployeeId = item,
        //                            CreatedBy = addUpdateModel.JobCurrentemp.CreatedBy,
        //                            Createddate = addUpdateModel.JobCurrentemp.Createddate
        //                        };
        //                        _appDbContext.JobCurrentEmployeerelation.Add(newGrade);
        //                        _appDbContext.SaveChanges();
        //                    }
        //                }
        //                finalreturnModel.Message = "Current Employee added successfully";
        //            }
        //        }

        //        if (addUpdateModel.Jobcoursecategory != null)
        //        {
        //            if (addUpdateModel.Jobcoursecategory.JobId == 0)
        //            {
        //                finalreturnModel.Message = "JobId is Required for Coursecategory";
        //                return finalreturnModel;
        //            }


        //            if (addUpdateModel.Jobcoursecategory.Id != 0)
        //            {
        //                var currentempId = addUpdateModel.Jobcoursecategory.CoursecategoryId;
        //                foreach (var item in currentempId)
        //                {
        //                    var isExist = _appDbContext.JobCoursecategory
        //                        .Where(x => x.Id == addUpdateModel.Jobcoursecategory.Id && x.CoursecategoryId == item)
        //                        .FirstOrDefault();

        //                    if (isExist != null)
        //                    {
        //                        isExist.JobId = addUpdateModel.Jobcoursecategory.JobId;
        //                        isExist.CoursecategoryId = item;
        //                        _appDbContext.SaveChanges();
        //                    }
        //                    else
        //                    {
        //                        finalreturnModel.Message = "Coursecategory Id not found";
        //                        finalreturnModel.Success = false;
        //                        return finalreturnModel;
        //                    }
        //                }
        //                finalreturnModel.Message = "Coursecategory updated successfully";
        //            }
        //            else
        //            {
        //                var tId = addUpdateModel.Jobcoursecategory.CoursecategoryId;
        //                foreach (var item in tId)
        //                {
        //                    var exist = _appDbContext.JobCoursecategory
        //                        .Where(x => x.JobId == addUpdateModel.Jobcoursecategory.JobId && x.CoursecategoryId == item)
        //                        .FirstOrDefault();

        //                    if (exist == null)
        //                    {
        //                        Jobcoursecategory newGrade = new Jobcoursecategory
        //                        {
        //                            JobId = addUpdateModel.Jobcoursecategory.JobId,
        //                            CoursecategoryId = item,
        //                            CreatedBy = addUpdateModel.Jobcoursecategory.CreatedBy,
        //                            Createddate = addUpdateModel.Jobcoursecategory.Createddate
        //                        };
        //                        _appDbContext.JobCoursecategory.Add(newGrade);
        //                        _appDbContext.SaveChanges();
        //                    }
        //                }
        //                finalreturnModel.Message = "coursecategory added successfully";
        //            }
        //        }


        //        transaction.Commit();
        //        finalreturnModel.Success = true;
        //        return finalreturnModel;
        //    }
        //    catch (Exception ex)
        //    {

        //        transaction.Rollback();

        //        finalreturnModel.Message = ex.Message;
        //        if (ex.InnerException != null)
        //        {
        //            finalreturnModel.Message = finalreturnModel.Message + "\n" + ex.InnerException.Message;
        //        }
        //        finalreturnModel.Success = false;
        //        return finalreturnModel;
        //    }
        //}

        public object GetJobDetails(int id, bool isEmployeeId)
        {
            try
            {
                if (id == 0)
                {
                    finalreturnModel.Message = "id is required";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }

                if (isEmployeeId)
                {
                 
                    var result = (from pt in _appDbContext.JobCurrentEmployeerelation
                                  join c in _appDbContext.Job on pt.JobId equals c.Id
                                  join t in _appDbContext.CurrentEmployee on pt.CurrentEmployeeId equals t.Id
                                  where pt.CurrentEmployeeId == id  
                                  select new
                                  {
                                      pt.Id,
                                      pt.JobId,
                                      pt.CurrentEmployeeId,
                                  }).ToList();  

                    if (result == null || result.Count == 0)
                    {
                        finalreturnModel.Message = "Data not found!";
                        finalreturnModel.Success = false;
                        return finalreturnModel;
                    }
                    else
                    {
                        finalreturnModel.Message = "Data retrieved successfully";
                        finalreturnModel.Success = true;
                        return result;
                    }
                }
                else
                {
             
                    var result = (from pt in _appDbContext.JobEducationkeywords
                                  join c in _appDbContext.Job on pt.JobId equals c.Id
                                  join t in _appDbContext.EducationKeywords on pt.EducationKeywordsId equals t.Id
                                  where pt.EducationKeywordsId == id  
                                  select new
                                  {
                                      pt.Id,
                                      pt.JobId,
                                      pt.EducationKeywordsId,
                                  }).ToList();  

                    if (result == null || result.Count == 0)
                    {
                        finalreturnModel.Message = "Data not found!";
                        finalreturnModel.Success = false;
                        return finalreturnModel;
                    }
                    else
                    {
                        finalreturnModel.Message = "Data retrieved successfully";
                        finalreturnModel.Success = true;
                        return result;
                    }
                }
            }
            catch (System.Exception ex)
            {
                finalreturnModel.Message = ex.Message;
                if (ex.InnerException != null)
                    finalreturnModel.Message = finalreturnModel.Message + "\n" + ex.InnerException.Message.ToString();

                finalreturnModel.Success = false;
                return finalreturnModel;
            }
        }




        public object GetAllCompanies(string masterstable, string filterByName)
        {
            try
            {
               
                if (string.IsNullOrEmpty(masterstable) ||
                    !(masterstable == "Classification" || masterstable == "SubClassification" || masterstable == "SuperClassification" ||
                      masterstable == "Domains" || masterstable == "Industries" || masterstable == "SubIndustries" || masterstable == "Product" || masterstable == "IndustryGroup" || masterstable == "Service" || masterstable == "Process" || masterstable == "ToolandtechTechnologies" || masterstable == "FunctionalAreas" || masterstable == "SubFunctionalAreas" || masterstable == "SuperFunctionalAreas" ))
                {
                    return new { Success = false, Message = "Invalid classification type provided. Please provide 'sub', 'super', 'domain', 'functionalSubFunction' or 'SubIndustries'." };
                }

                IQueryable<dynamic> result=null;

               
                if (masterstable == "SubClassification")
                {
                    result = from ct in _appDbContext.SubClassification
                             join us in _appDbContext.Userss on ct.CreatedBy equals us.UserId into deptGroup
                             from us in deptGroup.DefaultIfEmpty()
                             join us1 in _appDbContext.Userss on ct.ModifiedBy equals us1.UserId into deptaGroup
                             from us1 in deptaGroup.DefaultIfEmpty()
                             select new
                             {
                                 ct.Description,
                                 ct.Name,
                                 ct.Id,
                                 CreatedBy = us != null ? us.UserssName : null,
                                 ModifiedBy = us1 != null ? us1.UserssName : null
                             };
                }
                
                else if (masterstable == "SuperClassification")
                {
                    result = from ct in _appDbContext.SuperClassification
                             join us in _appDbContext.Userss on ct.CreatedBy equals us.UserId into deptGroup
                             from us in deptGroup.DefaultIfEmpty()
                             join us1 in _appDbContext.Userss on ct.ModifiedBy equals us1.UserId into deptaGroup
                             from us1 in deptaGroup.DefaultIfEmpty()
                             where ct.IsDeleted == false
                             select new
                             {
                                 ct.Description,
                                 ct.Name,
                                 ct.Id,
                                 CreatedBy = us != null ? us.UserssName : null,
                                 ModifiedBy = us1 != null ? us1.UserssName : null
                             };
                }
                
                else if (masterstable == "Domains")
                {
                    result = from ct in _appDbContext.Domains
                             join us in _appDbContext.Userss on ct.CreatedBy equals us.UserId into deptGroup
                             from us in deptGroup.DefaultIfEmpty()
                             join us1 in _appDbContext.Userss on ct.ModifiedBy equals us1.UserId into deptaGroup
                             from us1 in deptaGroup.DefaultIfEmpty()
                             select new
                             {
                                 ct.Description,
                                 ct.Name,
                                 ct.Id,
                                 CreatedBy = us != null ? us.UserssName : null,
                                 ModifiedBy = us1 != null ? us1.UserssName : null
                             };
                }
              
                else if (masterstable == "FunctionalAreas")
                {
                    result = from ct in _appDbContext.FunctionalAreas
                             join us in _appDbContext.Userss on ct.CreatedBy equals us.UserId into deptGroup
                             from us in deptGroup.DefaultIfEmpty()
                             join us1 in _appDbContext.Userss on ct.ModifiedBy equals us1.UserId into deptaGroup
                             from us1 in deptaGroup.DefaultIfEmpty()
                             select new
                             {
                                 ct.Description,
                                 ct.Name,
                                 ct.Id,
                                 CreatedBy = us != null ? us.UserssName : null,
                                 ModifiedBy = us1 != null ? us1.UserssName : null
                             };
                }
                
                else if (masterstable == "Industries")
                {
                    result = from ct in _appDbContext.Industries
                             join us in _appDbContext.Userss on ct.CreatedBy equals us.UserId into deptGroup
                             from us in deptGroup.DefaultIfEmpty()
                             join us1 in _appDbContext.Userss on ct.ModifiedBy equals us1.UserId into deptaGroup
                             from us1 in deptaGroup.DefaultIfEmpty()
                             select new
                             {
                                 ct.Description,
                                 ct.Name,
                                 ct.Id,
                                 CreatedBy = us != null ? us.UserssName : null,
                                 ModifiedBy = us1 != null ? us1.UserssName : null
                             };
                }

                else if (masterstable == "Classificatio")
                {
                    result = from ct in _appDbContext.Classification
                             join us in _appDbContext.Userss on ct.CreatedBy equals us.UserId into deptGroup
                             from us in deptGroup.DefaultIfEmpty()
                             join us1 in _appDbContext.Userss on ct.ModifiedBy equals us1.UserId into deptaGroup
                             from us1 in deptaGroup.DefaultIfEmpty()
                             select new
                             {
                                 ct.Description,
                                 ct.Name,
                                 ct.Id,
                                 CreatedBy = us != null ? us.UserssName : null,
                                 ModifiedBy = us1 != null ? us1.UserssName : null
                             };
                }

                else if (masterstable == "SubIndustries")
                {
                    result = from ct in _appDbContext.SubIndustries
                             join us in _appDbContext.Userss on ct.CreatedBy equals us.UserId into deptGroup
                             from us in deptGroup.DefaultIfEmpty()
                             join us1 in _appDbContext.Userss on ct.ModifiedBy equals us1.UserId into deptaGroup
                             from us1 in deptaGroup.DefaultIfEmpty()
                             select new
                             {
                                 ct.Description,
                                 ct.Name,
                                 ct.Id,
                                 CreatedBy = us != null ? us.UserssName : null,
                                 ModifiedBy = us1 != null ? us1.UserssName : null
                             };
                }

                else if (masterstable == "Product")
                {
                    result = from ct in _appDbContext.Product
                             join us in _appDbContext.Userss on ct.CreatedBy equals us.UserId into deptGroup
                             from us in deptGroup.DefaultIfEmpty()
                             join us1 in _appDbContext.Userss on ct.ModifiedBy equals us1.UserId into deptaGroup
                             from us1 in deptaGroup.DefaultIfEmpty()
                             select new
                             {
                                 ct.Description,
                                 ct.Name,
                                 ct.Id,
                                 CreatedBy = us != null ? us.UserssName : null,
                                 ModifiedBy = us1 != null ? us1.UserssName : null
                             };
                }

                else if (masterstable == "IndustryGroup")
                {
                    result = from ct in _appDbContext.IndustryGroup
                             join us in _appDbContext.Userss on ct.CreatedBy equals us.UserId into deptGroup
                             from us in deptGroup.DefaultIfEmpty()
                             join us1 in _appDbContext.Userss on ct.ModifiedBy equals us1.UserId into deptaGroup
                             from us1 in deptaGroup.DefaultIfEmpty()
                             select new
                             {
                                 ct.Description,
                                 
                                 ct.Name,
                                 ct.Id,
                                 CreatedBy = us != null ? us.UserssName : null,
                                 ModifiedBy = us1 != null ? us1.UserssName : null
                             };
                }

                else if (masterstable == "Service")
                {
                    result = from ct in _appDbContext.Service
                             join us in _appDbContext.Userss on ct.CreatedBy equals us.UserId into deptGroup
                             from us in deptGroup.DefaultIfEmpty()
                             join us1 in _appDbContext.Userss on ct.ModifiedBy equals us1.UserId into deptaGroup
                             from us1 in deptaGroup.DefaultIfEmpty()
                             select new
                             {
                                 ct.Description,
                                 
                                 ct.Name,
                                 ct.Id,
                                 CreatedBy = us != null ? us.UserssName : null,
                                 ModifiedBy = us1 != null ? us1.UserssName : null
                             };
                }

                else if (masterstable == "ToolandtechTechnologies")
                {
                    result = from ct in _appDbContext.ToolandtechTechnologies
                             join us in _appDbContext.Userss on ct.CreatedBy equals us.UserId into deptGroup
                             from us in deptGroup.DefaultIfEmpty()
                             join us1 in _appDbContext.Userss on ct.ModifiedBy equals us1.UserId into deptaGroup
                             from us1 in deptaGroup.DefaultIfEmpty()
                             select new
                             {
                                 ct.Description,

                                 ct.Name,
                                 ct.Id,
                                 CreatedBy = us != null ? us.UserssName : null,
                                 ModifiedBy = us1 != null ? us1.UserssName : null
                             };
                }

                else if (masterstable == "FunctionalAreas")
                {
                    result = from ct in _appDbContext.FunctionalAreas
                             join us in _appDbContext.Userss on ct.CreatedBy equals us.UserId into deptGroup
                             from us in deptGroup.DefaultIfEmpty()
                             join us1 in _appDbContext.Userss on ct.ModifiedBy equals us1.UserId into deptaGroup
                             from us1 in deptaGroup.DefaultIfEmpty()
                             select new
                             {
                                 ct.Description,

                                 ct.Name,
                                 ct.Id,
                                 CreatedBy = us != null ? us.UserssName : null,
                                 ModifiedBy = us1 != null ? us1.UserssName : null
                             };
                }

                else if (masterstable == "SubFunctionalAreas")
                {
                    result = from ct in _appDbContext.SubFunctionalAreas
                             join us in _appDbContext.Userss on ct.CreatedBy equals us.UserId into deptGroup
                             from us in deptGroup.DefaultIfEmpty()
                             join us1 in _appDbContext.Userss on ct.ModifiedBy equals us1.UserId into deptaGroup
                             from us1 in deptaGroup.DefaultIfEmpty()
                             select new
                             {
                                 ct.Description,

                                 ct.Name,
                                 ct.Id,
                                 CreatedBy = us != null ? us.UserssName : null,
                                 ModifiedBy = us1 != null ? us1.UserssName : null
                             };
                }

                else if (masterstable == "SuperFunctionalAreas")
                {
                    result = from ct in _appDbContext.SuperFunctionalAreas
                             join us in _appDbContext.Userss on ct.CreatedBy equals us.UserId into deptGroup
                             from us in deptGroup.DefaultIfEmpty()
                             join us1 in _appDbContext.Userss on ct.ModifiedBy equals us1.UserId into deptaGroup
                             from us1 in deptaGroup.DefaultIfEmpty()
                             select new
                             {
                                 ct.Description,

                                 ct.Name,
                                 ct.Id,
                                 CreatedBy = us != null ? us.UserssName : null,
                                 ModifiedBy = us1 != null ? us1.UserssName : null
                             };
                }

                var resultList = result.ToList();

                if (!resultList.Any())
                {
                    return new { Success = false, Message = "No data found in the Classification table" };
                }

                
                var filteredClass = resultList.Where(p => p.Name.Contains(filterByName)).DistinctBy(p => p.Name).ToList();

                if (!filteredClass.Any())
                {
                    return new { Success = false, Message = "No matching records found for the provided search letter" };
                }

                return new { Success = true, Data = filteredClass };
            }
            catch (Exception ex)
            {
                var finalReturnModel = new
                {
                    Success = false,
                    Message = ex.Message + (ex.InnerException != null ? "\n" + ex.InnerException.Message : "")
                };
                return finalReturnModel;
            }
        }






        public object AddUpdateCompanyDomain(CompanyDomain add)
        {
            try
            {
                if (add.CompanyId == 0)
                {
                    finalreturnModel.Message = "Id is Required";

                }

                if (add.DomainName == null || add.DomainName.Length == 0)
                {
                    finalreturnModel.Message = "Domain Name is Required";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }

                foreach (var item in add.DomainName)
                {
                    if (!add.IsValidDomainName(item))
                    {
                        finalreturnModel.Message = $"Invalid domain format: {item}";
                        finalreturnModel.Success = false;
                        return finalreturnModel;
                    }
                }

                if (add.Id != 0)
                {
                    var superfunctionId = add.DomainName;
                    foreach (var item in superfunctionId)
                    {
                        var IsExist = _appDbContext.CompanyDomainRelation
                            .Where(x => x.Id == add.Id && x.DomainName == item)
                            .FirstOrDefault();

                        if (IsExist != null)
                        {
                            IsExist.CompanyId = add.CompanyId;
                            //IsExist.DomainId = add.DomainId
                            IsExist.DomainName = item;
                            _appDbContext.SaveChanges();
                        }
                        else
                        {
                            finalreturnModel.Message = "Id not found";
                            finalreturnModel.Success = false;
                            return finalreturnModel;
                        }
                    }
                    finalreturnModel.Message = "Update successfully";
                    finalreturnModel.Success = true;
                    return finalreturnModel;
                }
                else
                {
                    var tId = add.DomainName;
                    foreach (var item in tId)
                    {
                        var Exist = _appDbContext.CompanyDomainRelation
                            .Where(x => x.CompanyId == add.CompanyId && x.DomainName == item)
                            .FirstOrDefault();
                        if (Exist == null)
                        {
                            CompanyDomainRelation newGrade = new CompanyDomainRelation();
                            newGrade.CompanyId = add.CompanyId;
                            newGrade.DomainName = item;
                            _appDbContext.CompanyDomainRelation.Add(newGrade);
                            _appDbContext.SaveChanges();
                            finalreturnModel.Message = "Added successfully";
                            finalreturnModel.Success = true;
                            return finalreturnModel;
                        }
                    }
                    finalreturnModel.Message = "Already exists";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }

                //if (add.Id != 0)
                //{
                //    var superfunctionId = add.DomainName;
                //    foreach (var item in superfunctionId)
                //    {
                //        var IsExist = _appDbContext.CompanyDomainRelation.Where(x => x.Id == add.Id && x.DomainName == item).FirstOrDefault();
                //        if (IsExist != null)
                //        {
                //            IsExist.CompanyName = add.CompanyName;
                //            IsExist.DomainName = item;

                //            _appDbContext.SaveChanges();


                //        }
                //        else
                //        {
                //            finalreturnModel.Message = "Id not found";
                //            finalreturnModel.Success = false;
                //            return finalreturnModel;
                //        }
                //    }
                //    finalreturnModel.Message = "update successfully";
                //    finalreturnModel.Success = true;
                //    return finalreturnModel;
                //}

                //else
                //{
                //    var tId = add.DomainName;
                //    foreach (var item in tId)
                //    {
                //        var Exist = _appDbContext.CompanyDomainRelation.Where(x => x.CompanyName == add.CompanyName && x.DomainName == item).FirstOrDefault();
                //        if (Exist == null)
                //        {
                //            CompanyDomainRelation newGrade = new CompanyDomainRelation();
                //            newGrade.CompanyName = add.CompanyName;
                //            newGrade.DomainName = item;
                //            _appDbContext.CompanyDomainRelation.Add(newGrade);
                //            _appDbContext.SaveChanges();
                //            finalreturnModel.Message = " add successfully";
                //            finalreturnModel.Success = true;
                //            return finalreturnModel;
                //        }
                //    }
                //    finalreturnModel.Message = "allready exist";
                //    finalreturnModel.Success = false;
                //    return finalreturnModel;

                //}


            }
            catch (System.Exception ex)
            {
                finalreturnModel.Message = ex.Message;
                if (ex.InnerException != null)
                    finalreturnModel.Message = finalreturnModel.Message + "\n" + ex.InnerException.Message.ToString();

                finalreturnModel.Success = false;
                return finalreturnModel;
            }
        }

        public object GetCompanyDomain()
        {
            var query = from pt in _appDbContext.CompanyDomainRelation

                        join c in _appDbContext.Companies on pt.CompanyId equals c.CompanyId into deptGroup
                        from c in deptGroup.DefaultIfEmpty()
                        join t in _appDbContext.Domains on pt.DomainName equals t.Name into deptmGroup
                        from t in deptmGroup.DefaultIfEmpty()

                        select new
                        {
                            pt.Id,
                            pt.CompanyId,
                            pt.DomainName,


                             
                        };

            return query.ToList();

        }

        public object CreateAllJobs(AllJob jobs)
        {
            try
            {
                if (string.IsNullOrEmpty(jobs.Name))
                {                    
                        finalreturnModel.Message = "job name cannot be empty";
                        finalreturnModel.Success = false;
                        return finalreturnModel;
                    
                }
                    //throw new Exception("job name cannot be empty");
                var Com = jobs.Name;
                var details = _appDbContext.Job.Where(f => f.Name == Com && f.IsDeleted == false).FirstOrDefault();
                if (details != null)
                {
                    finalreturnModel.Message = "Job already exist!";
                    finalreturnModel.Success = false;
                    return finalreturnModel;

                }
                else
                {
                    Job newJob = new Job();
                    newJob.Name = jobs.Name;
                    newJob.JobType = jobs.JobType;
                    newJob.JobCompany = jobs.JobCompany;
                    newJob.JobLocation = jobs.JobLocation;
                    newJob.CreatedAt = DateTime.Now;
                    newJob.CreatedBy = jobs.CreatedBy;
                    newJob.ModifiedBy = jobs.ModifiedBy;
                    newJob.ModifiedAt = DateTime.Now;
                    newJob.Description = jobs.Description;
                    newJob.IsDeleted = false;
                    
                    _appDbContext.Job.Add(newJob);
                    _appDbContext.SaveChanges();
                    var jobId = newJob.Id;


                    if (jobs.CoursecategoryId != null)
                    {
                        foreach (var item in jobs.CoursecategoryId)
                        {
                            var GrupIsExist = _appDbContext.Coursecategory.Where(x => x.Id == item).FirstOrDefault();
                             JobCoursecategory thisJobCourseCategory = new JobCoursecategory();
                            thisJobCourseCategory.JobId = jobId;
                            thisJobCourseCategory.CoursecategoryId = item;
                            thisJobCourseCategory.CreatedBy = jobs.CreatedBy;
                            thisJobCourseCategory.Createddate = DateTime.Now;
                            thisJobCourseCategory.IsDeleted = false;
                            //add.CoursecategoryId = item;
                            _appDbContext.JobCoursecategory.Add(thisJobCourseCategory);
                            _appDbContext.SaveChanges();
                        }
                    }
                    if (jobs.EducationkeywordId != null)
                    {
                        foreach (var item in jobs.EducationkeywordId)
                        {
                            var GrupIsExist = _appDbContext.EducationKeywords.Where(x => x.Id == item).FirstOrDefault();
                            JobEducationkeywords jobEducationkeywords = new JobEducationkeywords();
                            jobEducationkeywords.JobId = jobId;
                            jobEducationkeywords.EducationKeywordsId = item;
                            jobEducationkeywords.Createddate = DateTime.Now;
                            jobEducationkeywords.CreatedBy = jobs.CreatedBy;
                            jobEducationkeywords.IsDeleted = false;
                            _appDbContext.JobEducationkeywords.Add(jobEducationkeywords);
                            _appDbContext.SaveChanges();
                        }
                    }
                    if (jobs.SkillsId != null)
                    {
                        foreach (var item in jobs.SkillsId)
                        {
                            var GrupIsExist = _appDbContext.Skills.Where(x => x.Id == item).FirstOrDefault();
                            JobSkillls jobSkillls = new JobSkillls();
                            jobSkillls.JobId = jobId;
                            jobSkillls.SkillsId = item;
                            jobSkillls.Createddate = DateTime.Now;
                            jobSkillls.CreatedBy = jobs.CreatedBy;
                            jobSkillls.IsDeleted = false;
                           
                            _appDbContext.JobSkillls.Add(jobSkillls);
                            _appDbContext.SaveChanges();
                        }
                    }
                    if (jobs.CurrentemployerId != null)
                    {
                        foreach (var item in jobs.CurrentemployerId)
                        {
                            var GrupIsExist = _appDbContext.CurrentEmployee.Where(x => x.Id == item).FirstOrDefault();
                            JobCurrentEmployeerelation jobCurrentEmployeerelation = new JobCurrentEmployeerelation();
                            jobCurrentEmployeerelation.JobId = jobId;
                            jobCurrentEmployeerelation.CurrentEmployeeId = item;
                            jobCurrentEmployeerelation.Createddate = DateTime.Now;
                            jobCurrentEmployeerelation.CreatedBy = jobs.CreatedBy;
                            jobCurrentEmployeerelation.IsDeleted = false;
                            _appDbContext.JobCurrentEmployeerelation.Add(jobCurrentEmployeerelation);
                            _appDbContext.SaveChanges();
                        }
                    }
                   
                }
                return new { Success = true, Message = "job added successfully." };
            }
            catch (Exception ex)
            {
                finalreturnModel.Message = ex.Message;
                if (ex.InnerException != null)
                    finalreturnModel.Message = finalreturnModel.Message + "\n" + ex.InnerException.Message.ToString();

                finalreturnModel.Success = false;
                return finalreturnModel;
            }
        }

        public object UpdateJobs(AllJob jobs)
        {
            try
            {
                if (jobs.Id > 0)
                {
                    var isExists = _appDbContext.Job.Where(x => x.Id != jobs.Id && x.Name.ToUpper() == jobs.Name.ToUpper()).FirstOrDefault();
                    if (isExists != null)
                    {
                        finalreturnModel.Message = "job allready exists!";
                        finalreturnModel.Success = false;
                        return finalreturnModel;
                    }
                    var details = _appDbContext.Job.Where(f => f.Id == jobs.Id).FirstOrDefault();
                    if (details != null)
                    {
                        details.JobType = jobs.JobType;
                        details.Name = jobs.Name;
                        details.JobLocation = jobs.JobLocation;
                        details.JobCompany = jobs.JobCompany;
                        details.ModifiedBy = jobs.ModifiedBy;
                        details.Description = jobs.Description;
                        details.CreatedBy = jobs.CreatedBy;
                        details.CreatedAt = DateTime.Now;
                        details.ModifiedAt = DateTime.Now;
                        details.IsDeleted = false;
                        _appDbContext.SaveChanges();

                        if (jobs.CurrentemployerId != null)
                        {
                            var jobRelations = _appDbContext.JobCurrentEmployeerelation.Where(x => x.IsDeleted == false && x.CurrentEmployeeId == jobs.Id).ToList();
                            if (jobRelations.Count != 0)
                            {
                                foreach (var DeleteRelation in jobRelations)
                                {
                                    _appDbContext.JobCurrentEmployeerelation.Remove(DeleteRelation);
                                    _appDbContext.SaveChanges();
                                }
                            }
                            foreach (var item in jobs.CurrentemployerId)
                            {
                                var JobIsExist = _appDbContext.JobCurrentEmployeerelation.Where(x => x.IsDeleted == false && x.Id == item).FirstOrDefault();
                                if (JobIsExist != null)
                                {
                                    JobCurrentEmployeerelation relation = new JobCurrentEmployeerelation();
                                    relation.JobId = jobs.Id;
                                    relation.CurrentEmployeeId = item;
                                    relation.IsDeleted = false;
                                    relation.Createddate = DateTime.Now;
                                    _appDbContext.JobCurrentEmployeerelation.Add(relation);
                                    _appDbContext.SaveChanges();


                                }
                            }
                        }
                        else
                        {
                            var jobRelations = _appDbContext.JobCurrentEmployeerelation.Where(x => x.IsDeleted == false && x.JobId == jobs.Id).ToList();
                            if (jobRelations.Count != 0)
                            {
                                foreach (var DeleteRelation in jobRelations)
                                {
                                    _appDbContext.JobCurrentEmployeerelation.Remove(DeleteRelation);
                                    _appDbContext.SaveChanges();
                                }
                            }
                        }
                        if (jobs.CoursecategoryId != null)
                        {
                            var jobRelations = _appDbContext.JobCoursecategory.Where(x => x.IsDeleted == false && x.CoursecategoryId == jobs.Id).ToList();
                            if (jobRelations.Count != 0)
                            {
                                foreach (var DeleteRelation in jobRelations)
                                {
                                    _appDbContext.JobCoursecategory.Remove(DeleteRelation);
                                    _appDbContext.SaveChanges();
                                }
                            }
                            foreach (var item in jobs.CoursecategoryId)
                            {
                                var JobIsExist = _appDbContext.JobCoursecategory.Where(x => x.IsDeleted == false && x.Id == item).FirstOrDefault();
                                if (JobIsExist != null)
                                {
                                   JobCoursecategory relation = new JobCoursecategory();
                                    relation.JobId = jobs.Id;
                                    relation.CoursecategoryId = item;
                                    relation.IsDeleted = false;
                                    relation.Createddate = DateTime.Now;
                                    _appDbContext.JobCoursecategory.Add(relation);
                                    _appDbContext.SaveChanges();


                                }
                            }

                        }
                        else
                        {
                            var jobRelations = _appDbContext.JobCoursecategory.Where(x => x.IsDeleted == false && x.JobId == jobs.Id).ToList();
                            if (jobRelations.Count != 0)
                            {
                                foreach (var DeleteRelation in jobRelations)
                                {
                                    _appDbContext.JobCoursecategory.Remove(DeleteRelation);
                                    _appDbContext.SaveChanges();
                                }
                            }
                        }

                        if (jobs.EducationkeywordId != null)
                        {
                            var jobRelations = _appDbContext.JobEducationkeywords.Where(x => x.IsDeleted == false && x.EducationKeywordsId == jobs.Id).ToList();
                            if (jobRelations.Count != 0)
                            {
                                foreach (var DeleteRelation in jobRelations)
                                {
                                    _appDbContext.JobEducationkeywords.Remove(DeleteRelation);
                                    _appDbContext.SaveChanges();
                                }
                            }
                            foreach (var item in jobs.EducationkeywordId)
                            {
                                var JobIsExist = _appDbContext.JobEducationkeywords.Where(x => x.IsDeleted == false && x.Id == item).FirstOrDefault();
                                if (JobIsExist != null)
                                {
                                    JobEducationkeywords relation = new JobEducationkeywords();
                                    relation.JobId = jobs.Id;
                                    relation.EducationKeywordsId = item;
                                    relation.IsDeleted = false;
                                    relation.Createddate = DateTime.Now;
                                    _appDbContext.JobEducationkeywords.Add(relation);
                                    _appDbContext.SaveChanges();


                                }
                            }

                        }
                        else
                        {
                            var jobRelations = _appDbContext.JobEducationkeywords.Where(x => x.IsDeleted == false && x.JobId == jobs.Id).ToList();
                            if (jobRelations.Count != 0)
                            {
                                foreach (var DeleteRelation in jobRelations)
                                {
                                    _appDbContext.JobEducationkeywords.Remove(DeleteRelation);
                                    _appDbContext.SaveChanges();
                                }
                            }
                        }

                        if (jobs.SkillsId != null)
                        {
                            var jobRelations = _appDbContext.JobSkillls.Where(x => x.IsDeleted == false && x.SkillsId == jobs.Id).ToList();
                            if (jobRelations.Count != 0)
                            {
                                foreach (var DeleteRelation in jobRelations)
                                {
                                    _appDbContext.JobSkillls.Remove(DeleteRelation);
                                    _appDbContext.SaveChanges();
                                }
                            }
                            foreach (var item in jobs.SkillsId)
                            {
                                var JobIsExist = _appDbContext.JobSkillls.Where(x => x.IsDeleted == false && x.Id == item).FirstOrDefault();
                                if (JobIsExist != null)
                                {
                                    JobSkillls relation = new JobSkillls();
                                    relation.JobId = jobs.Id;
                                    relation.SkillsId = item;
                                    relation.IsDeleted = false;
                                    relation.Createddate = DateTime.Now;
                                    _appDbContext.JobSkillls.Add(relation);
                                    _appDbContext.SaveChanges();


                                }
                            }

                        }
                        else
                        {
                            var jobRelations = _appDbContext.JobSkillls.Where(x => x.IsDeleted == false && x.JobId == jobs.Id).ToList();
                            if (jobRelations.Count != 0)
                            {
                                foreach (var DeleteRelation in jobRelations)
                                {
                                    _appDbContext.JobSkillls.Remove(DeleteRelation);
                                    _appDbContext.SaveChanges();
                                }
                            }
                        }


                        #region Maintain Audit logs
                        var AuditJob = _appDbContext.Job.Where(x => x.IsDeleted == false && x.Id == jobs.Id).FirstOrDefault();
                        if (AuditJob != null)
                        {
                            //Job NewJob = new Job();
                            AuditJob.JobType = AuditJob.JobType;
                            AuditJob.JobLocation = AuditJob.JobLocation;
                            AuditJob.JobCompany = AuditJob.JobCompany;
                            AuditJob.ModifiedBy = AuditJob.ModifiedBy;
                            AuditJob.ModifiedAt = DateTime.Now;
                            _appDbContext.SaveChanges();
                        }
                        #endregion

                        finalreturnModel.Message = "Job updated successfully!";
                        finalreturnModel.Success = true;
                        return finalreturnModel;
                    }
                    else
                    {
                        finalreturnModel.Message = "Data not found!";
                       finalreturnModel.Success = false;
                        return finalreturnModel;
                    }
                }
                finalreturnModel.Message = "JobId is required!";
                finalreturnModel.Success = false;
                return finalreturnModel;

            }
            catch (Exception ex)
            {
                finalreturnModel.Message = ex.Message;
                if (ex.InnerException != null)
                    finalreturnModel.Message = finalreturnModel.Message + "\n" + ex.InnerException.Message.ToString();

                finalreturnModel.Success = false;
                return finalreturnModel;
            }
        }

        public object GetAllJobs()
        {
            try
            {
                var result = (from job in _appDbContext.Job
                              join cur in _appDbContext.JobCurrentEmployeerelation on job.Id equals cur.JobId into curJoin
                              from cur in curJoin.DefaultIfEmpty()
                              join curset in _appDbContext.CurrentEmployee on cur.CurrentEmployeeId equals curset.Id into cursetJoin
                              from curset in cursetJoin.DefaultIfEmpty()
                              join education in _appDbContext.JobEducationkeywords on job.Id equals education.JobId into educationJoin
                              from education in educationJoin.DefaultIfEmpty()
                              join educationset in _appDbContext.EducationKeywords on education.EducationKeywordsId equals educationset.Id into educationsetJoin
                              from educationset in educationsetJoin.DefaultIfEmpty()
                              join course in _appDbContext.JobCoursecategory on job.Id equals course.JobId into courseJoin
                              from course in courseJoin.DefaultIfEmpty()
                              join courseCat in _appDbContext.Coursecategory on course.CoursecategoryId equals courseCat.Id into courseCatJoin
                from courseCat in courseCatJoin.DefaultIfEmpty()
             
                              join skill in _appDbContext.JobSkillls on job.Id equals skill.JobId into skillJoin
                              from skill in skillJoin.DefaultIfEmpty()
                              join skillset in _appDbContext.Skills on skill.SkillsId equals skillset.Id into skillsetJoin
                              from skillset in skillsetJoin.DefaultIfEmpty()



                              select new
                              {
                                  job.Id,
                                  job.Name,
                                  job.JobType,
                                  job.JobLocation,
                                  job.JobCompany,
                                  EducationKeywordsId = education != null ? education.EducationKeywordsId : 0,
                                  EducationKeywordsName = educationset != null ? educationset.Name : null,
                                  CoursecategoryId = course != null ? course.CoursecategoryId : 0,
                                  CoursecategoryName = courseCat != null ? courseCat.Name : null,
                                  SkillsId = skill != null ? skill.SkillsId :0,
                                  SkillsName = skillset != null ? skillset.Name : null,
                                  CurrentEmployeeId = cur != null ? cur.CurrentEmployeeId : 0,
                                  CurrentEmployeeName = curset != null ? curset.Name : null,






                              });
                return result.ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object CreateCompany(AllCompany company)
        {
            try
            {
                if (string.IsNullOrEmpty(company.CompanyName))
                {
                    finalreturnModel.Message = "company name cannot be empty";
                    finalreturnModel.Success = false;
                    return finalreturnModel;

                }
                //throw new Exception("job name cannot be empty");
                var Com = company.CompanyName;
                var details = _appDbContext.Companies.Where(f => f.CompanyName == Com && f.IsDeleted == false).FirstOrDefault();
                if (details != null)
                {
                    finalreturnModel.Message = "Company already exist!";
                    finalreturnModel.Success = false;
                    return finalreturnModel;

                }
                else
                {
                    Companies newCompany = new Companies();
                    newCompany.CompanyName = company.CompanyName;


                    newCompany.CreatedBy = company.CreatedBy;
                    //newCompany.ModifiedBy = company.ModifiedBy;
                    //newCompany.ModifiedAt = DateTime.Now;
                    newCompany.Description = company.Description;
                    newCompany.IsDeleted = false;

                    _appDbContext.Companies.Add(newCompany);
                    _appDbContext.SaveChanges();
                    var companyId = newCompany.CompanyId;


                    if (company.ProductId != null)
                    {
                        foreach (var item in company.ProductId)
                        {
                            var GrupIsExist = _appDbContext.Products.Where(x => x.ProductId == item).FirstOrDefault();
                            CompanyProductRelationship companyProducts = new CompanyProductRelationship();
                            companyProducts.CompanyId = companyId;
                            companyProducts.ProductId = item;
                            //companyProducts.CreatedBy = company.CreatedBy;
                            //companyProducts.Createddate = DateTime.Now;
                            //companyProducts.IsDeleted = false;
                            //add.CoursecategoryId = item;
                            _appDbContext.companyProductRelationship.Add(companyProducts);
                            _appDbContext.SaveChanges();
                        }

                        if (company.ServiceId != null)
                        {
                            foreach (var item in company.ServiceId)
                            {
                                var GrupIsExist = _appDbContext.Service.Where(x => x.Id == item).FirstOrDefault();
                                CompanyServiceRelationship companyServiceRelationship = new CompanyServiceRelationship();
                                companyServiceRelationship.CompanyId = companyId;
                                companyServiceRelationship.ServiceId = item;

                                _appDbContext.CompanyServiceRelationship.Add(companyServiceRelationship);
                                _appDbContext.SaveChanges();
                            }
                        }
                        if (company.ToolId != null)
                        {
                            foreach (var item in company.ToolId)
                            {
                                var GrupIsExist = _appDbContext.ToolandtechTechnologies.Where(x => x.Id == item).FirstOrDefault();
                                CompanyToolRelationship companyToolRelationship = new CompanyToolRelationship();
                                companyToolRelationship.CompanyId = companyId;
                                companyToolRelationship.ToolId = item;

                                _appDbContext.CompanyToolRelationship.Add(companyToolRelationship);
                                _appDbContext.SaveChanges();
                            }
                        }


                    }
                    return new { Success = true, Message = "company added successfully." };
                }
            }
            catch (Exception ex)
            {
                finalreturnModel.Message = ex.Message;
                if (ex.InnerException != null)
                    finalreturnModel.Message = finalreturnModel.Message + "\n" + ex.InnerException.Message.ToString();

                finalreturnModel.Success = false;
                return finalreturnModel;
            }
        }


        //public object UpdateCompany(AllCompany company)
        //{
        //    try
        //    {
        //        if (company.Id > 0)
        //        {
        //            var isExists = _appDbContext.Job.Where(x => x.Id != jobs.Id && x.Name.ToUpper() == jobs.Name.ToUpper()).FirstOrDefault();
        //            if (isExists != null)
        //            {
        //                finalreturnModel.Message = "job allready exists!";
        //                finalreturnModel.Success = false;
        //                return finalreturnModel;
        //            }
        //            var details = _appDbContext.Job.Where(f => f.Id == jobs.Id).FirstOrDefault();
        //            if (details != null)
        //            {
        //                details.JobType = jobs.JobType;
        //                details.Name = jobs.Name;
        //                details.JobLocation = jobs.JobLocation;
        //                details.JobCompany = jobs.JobCompany;
        //                details.ModifiedBy = jobs.ModifiedBy;
        //                details.Description = jobs.Description;
        //                details.CreatedBy = jobs.CreatedBy;
        //                details.CreatedAt = DateTime.Now;
        //                details.ModifiedAt = DateTime.Now;
        //                details.IsDeleted = false;
        //                _appDbContext.SaveChanges();

        //                if (jobs.CurrentemployerId != null)
        //                {
        //                    var jobRelations = _appDbContext.JobCurrentEmployeerelation.Where(x => x.IsDeleted == false && x.CurrentEmployeeId == jobs.Id).ToList();
        //                    if (jobRelations.Count != 0)
        //                    {
        //                        foreach (var DeleteRelation in jobRelations)
        //                        {
        //                            _appDbContext.JobCurrentEmployeerelation.Remove(DeleteRelation);
        //                            _appDbContext.SaveChanges();
        //                        }
        //                    }
        //                    foreach (var item in jobs.CurrentemployerId)
        //                    {
        //                        var JobIsExist = _appDbContext.JobCurrentEmployeerelation.Where(x => x.IsDeleted == false && x.Id == item).FirstOrDefault();
        //                        if (JobIsExist != null)
        //                        {
        //                            JobCurrentEmployeerelation relation = new JobCurrentEmployeerelation();
        //                            relation.JobId = jobs.Id;
        //                            relation.CurrentEmployeeId = item;
        //                            relation.IsDeleted = false;
        //                            relation.Createddate = DateTime.Now;
        //                            _appDbContext.JobCurrentEmployeerelation.Add(relation);
        //                            _appDbContext.SaveChanges();


        //                        }
        //                    }
        //                }
        //                else
        //                {
        //                    var jobRelations = _appDbContext.JobCurrentEmployeerelation.Where(x => x.IsDeleted == false && x.JobId == jobs.Id).ToList();
        //                    if (jobRelations.Count != 0)
        //                    {
        //                        foreach (var DeleteRelation in jobRelations)
        //                        {
        //                            _appDbContext.JobCurrentEmployeerelation.Remove(DeleteRelation);
        //                            _appDbContext.SaveChanges();
        //                        }
        //                    }
        //                }
        //                if (jobs.CoursecategoryId != null)
        //                {
        //                    var jobRelations = _appDbContext.JobCoursecategory.Where(x => x.IsDeleted == false && x.CoursecategoryId == jobs.Id).ToList();
        //                    if (jobRelations.Count != 0)
        //                    {
        //                        foreach (var DeleteRelation in jobRelations)
        //                        {
        //                            _appDbContext.JobCoursecategory.Remove(DeleteRelation);
        //                            _appDbContext.SaveChanges();
        //                        }
        //                    }
        //                    foreach (var item in jobs.CoursecategoryId)
        //                    {
        //                        var JobIsExist = _appDbContext.JobCoursecategory.Where(x => x.IsDeleted == false && x.Id == item).FirstOrDefault();
        //                        if (JobIsExist != null)
        //                        {
        //                            JobCoursecategory relation = new JobCoursecategory();
        //                            relation.JobId = jobs.Id;
        //                            relation.CoursecategoryId = item;
        //                            relation.IsDeleted = false;
        //                            relation.Createddate = DateTime.Now;
        //                            _appDbContext.JobCoursecategory.Add(relation);
        //                            _appDbContext.SaveChanges();


        //                        }
        //                    }

        //                }
        //                else
        //                {
        //                    var jobRelations = _appDbContext.JobCoursecategory.Where(x => x.IsDeleted == false && x.JobId == jobs.Id).ToList();
        //                    if (jobRelations.Count != 0)
        //                    {
        //                        foreach (var DeleteRelation in jobRelations)
        //                        {
        //                            _appDbContext.JobCoursecategory.Remove(DeleteRelation);
        //                            _appDbContext.SaveChanges();
        //                        }
        //                    }
        //                }

        //                if (jobs.EducationkeywordId != null)
        //                {
        //                    var jobRelations = _appDbContext.JobEducationkeywords.Where(x => x.IsDeleted == false && x.EducationKeywordsId == jobs.Id).ToList();
        //                    if (jobRelations.Count != 0)
        //                    {
        //                        foreach (var DeleteRelation in jobRelations)
        //                        {
        //                            _appDbContext.JobEducationkeywords.Remove(DeleteRelation);
        //                            _appDbContext.SaveChanges();
        //                        }
        //                    }
        //                    foreach (var item in jobs.EducationkeywordId)
        //                    {
        //                        var JobIsExist = _appDbContext.JobEducationkeywords.Where(x => x.IsDeleted == false && x.Id == item).FirstOrDefault();
        //                        if (JobIsExist != null)
        //                        {
        //                            JobEducationkeywords relation = new JobEducationkeywords();
        //                            relation.JobId = jobs.Id;
        //                            relation.EducationKeywordsId = item;
        //                            relation.IsDeleted = false;
        //                            relation.Createddate = DateTime.Now;
        //                            _appDbContext.JobEducationkeywords.Add(relation);
        //                            _appDbContext.SaveChanges();


        //                        }
        //                    }

        //                }
        //                else
        //                {
        //                    var jobRelations = _appDbContext.JobEducationkeywords.Where(x => x.IsDeleted == false && x.JobId == jobs.Id).ToList();
        //                    if (jobRelations.Count != 0)
        //                    {
        //                        foreach (var DeleteRelation in jobRelations)
        //                        {
        //                            _appDbContext.JobEducationkeywords.Remove(DeleteRelation);
        //                            _appDbContext.SaveChanges();
        //                        }
        //                    }
        //                }

        //                if (jobs.SkillsId != null)
        //                {
        //                    var jobRelations = _appDbContext.JobSkillls.Where(x => x.IsDeleted == false && x.SkillsId == jobs.Id).ToList();
        //                    if (jobRelations.Count != 0)
        //                    {
        //                        foreach (var DeleteRelation in jobRelations)
        //                        {
        //                            _appDbContext.JobSkillls.Remove(DeleteRelation);
        //                            _appDbContext.SaveChanges();
        //                        }
        //                    }
        //                    foreach (var item in jobs.SkillsId)
        //                    {
        //                        var JobIsExist = _appDbContext.JobSkillls.Where(x => x.IsDeleted == false && x.Id == item).FirstOrDefault();
        //                        if (JobIsExist != null)
        //                        {
        //                            JobSkillls relation = new JobSkillls();
        //                            relation.JobId = jobs.Id;
        //                            relation.SkillsId = item;
        //                            relation.IsDeleted = false;
        //                            relation.Createddate = DateTime.Now;
        //                            _appDbContext.JobSkillls.Add(relation);
        //                            _appDbContext.SaveChanges();


        //                        }
        //                    }

        //                }
        //                else
        //                {
        //                    var jobRelations = _appDbContext.JobSkillls.Where(x => x.IsDeleted == false && x.JobId == jobs.Id).ToList();
        //                    if (jobRelations.Count != 0)
        //                    {
        //                        foreach (var DeleteRelation in jobRelations)
        //                        {
        //                            _appDbContext.JobSkillls.Remove(DeleteRelation);
        //                            _appDbContext.SaveChanges();
        //                        }
        //                    }
        //                }


        //                #region Maintain Audit logs
        //                var AuditJob = _appDbContext.Job.Where(x => x.IsDeleted == false && x.Id == jobs.Id).FirstOrDefault();
        //                if (AuditJob != null)
        //                {
        //                    //Job NewJob = new Job();
        //                    AuditJob.JobType = AuditJob.JobType;
        //                    AuditJob.JobLocation = AuditJob.JobLocation;
        //                    AuditJob.JobCompany = AuditJob.JobCompany;
        //                    AuditJob.ModifiedBy = AuditJob.ModifiedBy;
        //                    AuditJob.ModifiedAt = DateTime.Now;
        //                    _appDbContext.SaveChanges();
        //                }
        //                #endregion

        //                finalreturnModel.Message = "Job updated successfully!";
        //                finalreturnModel.Success = true;
        //                return finalreturnModel;
        //            }
        //            else
        //            {
        //                finalreturnModel.Message = "Data not found!";
        //                finalreturnModel.Success = false;
        //                return finalreturnModel;
        //            }
        //        }
        //        finalreturnModel.Message = "JobId is required!";
        //        finalreturnModel.Success = false;
        //        return finalreturnModel;

        //    }
        //    catch (Exception ex)
        //    {
        //        finalreturnModel.Message = ex.Message;
        //        if (ex.InnerException != null)
        //            finalreturnModel.Message = finalreturnModel.Message + "\n" + ex.InnerException.Message.ToString();

        //        finalreturnModel.Success = false;
        //        return finalreturnModel;
        //    }
        //}


        public static string GetStaticContentDirectory()
        {
            var DirectoryPath = "Uploads\\Masters\\CompanyDemoExcelFile";
            //var result = Path.Combine(Directory.GetCurrentDirectory(), "Uploads\\StaticContent\\");
            var result = Path.Combine(DirectoryPath);  //Directory.GetCurrentDirectory()
            if (Directory.Exists(result))
            {
                return result;

            }
            else
            {
                Directory.CreateDirectory(result);
                return result;
            }

        }
        public static string GetFilePath(string FileName)
        {
            var _GetStaticContentDirectory = GetStaticContentDirectory();
            var result = Path.Combine(_GetStaticContentDirectory, FileName);//, FileName
            return result;

        }
        public static string GetStaticContentDirectory1()
        {
            var DirectoryPath = "Uploads\\Masters\\ImportHistory";
            //var result = Path.Combine(Directory.GetCurrentDirectory(), "Uploads\\StaticContent\\");
            var result = Path.Combine(DirectoryPath);  //Directory.GetCurrentDirectory()
            if (Directory.Exists(result))
            {
                return result;

            }
            else
            {
                Directory.CreateDirectory(result);
                return result;
            }

        }
        public static string GetFilePath1(string FileName)
        {
            var _GetStaticContentDirectory = GetStaticContentDirectory1();
            var result = Path.Combine(_GetStaticContentDirectory, FileName);//, FileName
            return result;

        }
    }



    internal class ExcelExcelDataSetConfiguation : ExcelDataSetConfiguration
    {
        public bool UseColumnDataType { get; set; }
        public Func<IExcelDataReader, ExcelDataTableConfiguration> ConfigureDataTable { get; set; }
    }
}


