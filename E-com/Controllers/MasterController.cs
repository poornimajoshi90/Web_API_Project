using E_com.Model;
using E_com.Services;
using E_com.VeiwModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_com.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[ApiExplorerSettings(IgnoreApi = true)]
    public class MasterController : ControllerBase
    {
        private IMasterServices _masterServices;

        public MasterController(IMasterServices masterServices)
        {
            _masterServices = masterServices;
        }

        [HttpPost("AddUpdateCompanyProduct")]
        public IActionResult AddUpdateCompanyProduct([FromBody] Add add)
        {
            var result = _masterServices.AddUpdateCompanyProduct(add);
            return Ok(result);
        }

        //[HttpPut("UpdateCompanyProduct")]

        //public IActionResult UpdateCompanyProduct([FromBody] CompanyProducts update)
        //{
        //    var result = _masterServices.UpdateCompanyProduct(update);
        //    return Ok(result);
        //}

        [HttpDelete("DeleteCompanyProduct")]
        public IActionResult DeleteCompanyProduct( int productid)
        {
            var result = _masterServices.DeleteCompanyProduct(productid);
            return Ok(result);
        }

        [HttpGet("GetCompanyProduct")]
        public IActionResult GetCompanyProduct()
        {
            var result = _masterServices.GetCompanyProduct();
            return Ok(result);
        }

        //[HttpPost("AddCompanyServices")]
        //public IActionResult AddCompanyServices(Add add)
        //{
        //    var result = _masterServices.AddCompanyServices(add);
        //    return Ok(result);
        //}

        //[HttpPut("UpdateCompanyServices")]
        //public IActionResult UpdateCompanyServices(VeiwModel.Update addnew)
        //{
        //    var result = _masterServices.UpdateCompanyServices(addnew);
        //    return Ok(result);
        //}
        [HttpPost("AddUpdateCompanyServices")]
        public IActionResult AddUpdateCompanyServices(Add add)
        {
            var result = _masterServices.AddUpdateCompanyServices(add);
            return Ok(result);
        }

        [HttpGet("GetCompanyServices")]
        public IActionResult GetCompanyServices()
        {
            var result = _masterServices.GetCompanyServices();
            return Ok(result);
        }

        [HttpDelete("DeleteCompanyServices")]
        public IActionResult DeleteCompanyServices(int serviceid)
        {
            var result = _masterServices.DeleteCompanyServices(serviceid);
            return Ok(result);
        }

        [HttpPost("AddUpdateCompanyTools")]
        public IActionResult AddUpdateCompanyTools(Add add)
        {
            var result = _masterServices.AddUpdateCompanyTools(add);
            return Ok(result);
        }

        [HttpGet("GetCompanyTools")]
        public IActionResult GetCompanyTools()
        {
            var result = _masterServices.GetCompanyTools();
            return Ok(result);
        }

        [HttpDelete("DeleteCompanyTools")]
        public IActionResult DeleteCompanyTools(int toolid)
        {
            var result = _masterServices.DeleteCompanyTools(toolid);
            return Ok(result);
        }

        [HttpGet("GetToolRelationid")]
        public IActionResult GetToolRelationid(int toolid)
        {
            var result = _masterServices.GetToolRelationid(toolid);
            return Ok(result);
        }

        //[HttpPost("AddUser")]
        //public IActionResult AddUser(Users add)
        //{
        //    var result = _masterServices.AddUser(add);
        //    return Ok(result);
        //}

        //[HttpGet("GetCompanyProductRelation")]
        //public IActionResult GetCompanyProductRelation()
        //{
        //    var result = _masterServices.GetCompanyProductRelation();
        //    return Ok(result);
        //}

        [HttpPost("AddUpdateCompany")]
        public IActionResult AddUpdateCompany(Companyi add)
        {
            var result = _masterServices.AddUpdateCompany(add);
            return Ok(result);
        }

        [HttpGet("GetCompany")]
        public IActionResult GetCompany()
        {
            var result = _masterServices.GetCompany();
            return Ok(result);
        }


        //[HttpGet("GetCompanyToolRelation")]
        //public IActionResult GetCompanyToolRelation()
        //{
        //    var result = _masterServices.GetCompanyToolRelation();
        //        return Ok(result);
        //}

        [HttpPost("AddUpdateCompanyToolRelation")]
        public IActionResult AddUpdateCompanyToolRelation(CompanyToolModel add)
        {
            var result = _masterServices.AddUpdateCompanyToolRelation(add);
            return Ok(result);
        }

        [HttpGet("GetToolRelation")]
        public IActionResult GetToolRelation()
        {
            var result = _masterServices.GetToolRelation();
            return Ok(result);
        }
        [HttpPost("AddCompanyService")]
        public IActionResult AddCompanyService(CompanyServiceModel add)
        {
            var result = _masterServices.AddCompanyService(add);
            return Ok(result);
        }

        [HttpGet("GetCompanyServiceByid")]
        public IActionResult GetCompanyServiceByid(int serviceid)
        {
            var result = _masterServices.GetCompanyServiceByid(serviceid);
            return Ok(result);
        }

        [HttpPost("AddComapnyProduct")]
        public IActionResult AddComapnyProduct(CompanyProductRequestModel add)
        {
            var result = _masterServices.AddComapnyProduct(add);
            return Ok(result);

        }

        [HttpGet("GetCompanyProductByid")]
        public IActionResult GetCompanyProductByid(int productid)
        {
            var result = _masterServices.GetCompanyProductByid(productid);
            return Ok(result);
        }

        [HttpPost("AddDummyAccount")]
        public IActionResult AddDummyAccount(AccountRequest add)
        {
            var result = _masterServices.AddDummyAccount(add);
            return Ok(result);
        }

        [HttpGet("GetDummyAccount")]
        public IActionResult GetDummyAccount()
        {
            var result = _masterServices.GetDummyAccount();
            return Ok(result);
        }

        [HttpPost("AddUpdateClassification")]
        public IActionResult AddUpdateClassification(Classficationrequestcs addnew)
        {
            var result = _masterServices.AddUpdateClassification(addnew);
            return Ok(result);
        }

        //[HttpPost("GetClassificationDetails")]
        //public IActionResult GetClassificationDetails(LocationsViewModel request)
        //{
        //    var result = _masterServices.GetClassificationDetails(request);
        //    return Ok(result);
        //}

        [HttpDelete("DeleteClassification")]
        public IActionResult DeleteClassification(int classificationid)
        {
            var result = _masterServices.DeleteClassification(classificationid);
            return Ok(result);
        }

        [HttpPost("AddUpdateSubClassification")]
        public IActionResult AddUpdateSubClassification(SubClassficationrequestcs addnew)
        {
            var result = _masterServices.AddUpdateSubClassification(addnew);
            return Ok(result);
        }

        [HttpGet("GetSubClassification")]
        public IActionResult GetSubClassification(string FilterByName)
        {
            var result = _masterServices.GetSubClassification(FilterByName);
            return Ok(result);
        }

        [HttpDelete("DeleteSubClassification")]
        public IActionResult DeleteSubClassification(int Subclassificationid)
        {
            var result = _masterServices.DeleteSubClassification(Subclassificationid);
            return Ok(result);
        }

        [HttpPost("AddUpdateSuperClassification")]
        public IActionResult AddUpdateSuperClassification(SuperClassficationrequestcs addnew)
        {
            var result = _masterServices.AddUpdateSuperClassification(addnew);
            return Ok(result);
        }

        [HttpGet("GetSuperClassification")]
        public IActionResult GetSuperClassification(string FilterByName)
        {
            var result = _masterServices.GetSuperClassification(FilterByName);
            return Ok(result);
        }

        [HttpDelete("DeleteSuperClassification")]
        public IActionResult DeleteSuperClassification(int classificationid)
        {
            var result = _masterServices.DeleteSuperClassification(classificationid);
            return Ok(result);
        }

        [HttpPost("AddUpdateDomains")]
        public IActionResult AddUpdateDomains(Domainsreq addnew)
        {
            var result = _masterServices.AddUpdateDomains(addnew);
            return Ok(result);
        }

        [HttpGet("GetDomains")]
        public IActionResult GetDomains(string FilterByName)
        {
            var result = _masterServices.GetDomains(FilterByName);
            return Ok(result);
        }

        [HttpDelete("DeleteDomains")]
        public IActionResult DeleteDomains(int classificationid)
        {
            var result = _masterServices.DeleteDomains(classificationid);
            return Ok(result);
        }

        [HttpPost("AddUpdateIndustries")]
        public IActionResult AddUpdateIndustries(Industriesreq addnew)
        {
            var result = _masterServices.AddUpdateIndustries(addnew);
            return Ok(result);
        }

        [HttpGet("GetIndustries")]
        public IActionResult GetIndustries(string FilterByName)
        {
            var result = _masterServices.GetIndustries(FilterByName);
            return Ok(result);
        }

        [HttpDelete("DeleteIndustries")]
        public IActionResult DeleteIndustries(int Industriesid)
        {
            var result = _masterServices.DeleteIndustries(Industriesid);
            return Ok(result);
        }

        [HttpPost("AddUpdateSubIndustries")]
        public IActionResult AddUpdateSubIndustries(SubIndustriesreq addnew)
        {
            var result = _masterServices.AddUpdateSubIndustries(addnew);
            return Ok(result);
        }

        [HttpDelete("DeleteSubIndustries")]
        public IActionResult DeleteSubIndustries(int SubIndustriesid)
        {
            var result = _masterServices.DeleteSubIndustries(SubIndustriesid);
            return Ok(result);
        }

        [HttpPost("AddUpdateProducts")]
        public IActionResult AddUpdateProducts(Productreq addnew)
        {
            var result = _masterServices.AddUpdateProducts(addnew);
            return Ok(result);
        }
        
        [HttpDelete("DeleteProducts")]
        public IActionResult DeleteProducts(int Productsid)
        {
            var result = _masterServices.DeleteProducts(Productsid);
            return Ok(result);
        }

        [HttpPost("AddUpdateIndustryGroup")]
        public IActionResult AddUpdateIndustryGroup(Industryreq addnew)
        {
            var result = _masterServices.AddUpdateIndustryGroup(addnew);
            return Ok(result);
        }

        [HttpDelete("DeleteIndustryGroup")]
        public IActionResult DeleteIndustryGroup(int Industryid)
        {
            var result = _masterServices.DeleteIndustryGroup(Industryid);
            return Ok(result);
        }

        [HttpPost("AddUpdateService")]
        public IActionResult AddUpdateService(Servicereq addnew)
        {
            var result = _masterServices.AddUpdateService(addnew);
            return Ok(result);
        }
        [HttpDelete("DeleteService")]
        public IActionResult DeleteService(int Serviceid)
        {
            var result = _masterServices.DeleteService(Serviceid);
            return Ok(result);
        }

        [HttpPost("AddUpdateProcess")]
        public IActionResult AddUpdateProcess(Processreq addnew)
        {
            var result = _masterServices.AddUpdateProcess(addnew);
            return Ok(result);
        }

        [HttpDelete("DeleteProcess")]
        public IActionResult DeleteProcess(int Processid)
        {
            var result = _masterServices.DeleteProcess(Processid);
            return Ok(result);
        }

        [HttpPost("AddUpdateToolandTechnologies")]
        public IActionResult AddUpdateToolandTechnologies(techreq addnew)
        {
            var result = _masterServices.AddUpdateToolandTechnologies(addnew);
            return Ok(result);
        }

        [HttpDelete("DeleteToolTechnologies")]
        public IActionResult DeleteToolTechnologies(int tooltechid)
        {
            var result = _masterServices.DeleteToolTechnologies(tooltechid);
            return Ok(result);
        }

        [HttpPost("AddUpdateFunctionalAreas")]
        public IActionResult AddUpdateFunctionalAreas(functionalreq addnew)
        {
            var result = _masterServices.AddUpdateFunctionalAreas(addnew);
            return Ok(result);
        }

        [HttpDelete("DeleteFunctionalAreas")]
        public IActionResult DeleteFunctionalAreas(int functionalareaid)
        {
            var result = _masterServices.DeleteFunctionalAreas(functionalareaid);
            return Ok(result);
        }

        [HttpPost("AddUpdateSubFunctional")]
        public IActionResult AddUpdateSubFunctional(subfuncreq addnew)
        {
            var result = _masterServices.AddUpdateSubFunctional(addnew);
            return Ok(result);
        }

        [HttpDelete("DeleteSubFunctionalAreas")]
        public IActionResult DeleteSubFunctionalAreas(int subfunctionalareaid)
        {
            var result = _masterServices.DeleteSubFunctionalAreas(subfunctionalareaid);
            return Ok(result);
        }

        [HttpPost("AddUpdateSuperFunctional")]
        public IActionResult AddUpdateSuperFunctional(supfunreq addnew)
        {
            var result = _masterServices.AddUpdateSuperFunctional(addnew);
            return Ok(result);
        }

        [HttpDelete("DeleteSuperFunctionalAreas")]
        public IActionResult DeleteSuperFunctionalAreas(int superfunctionalareaid)
        {
            var result = _masterServices.DeleteSuperFunctionalAreas(superfunctionalareaid);
            return Ok(result);
        }

        [HttpPost("AddCompanyIndustryClassRelation")]
        public IActionResult AddCompanyIndustryClassRelation(IndustryClassRelation add)
        {
            var result = _masterServices.AddCompanyIndustryClassRelation(add);
            return Ok(result);
        }

        [HttpPost("AddClassSubClassRelation")]
        public IActionResult AddClassSubClassRelation(ClassificationSubclassificationRelation add)
        {
            var result = _masterServices.AddClassSubClassRelation(add);
            return Ok(result);
        }

        [HttpPost("AddSupclassSuperclassRelation")]
        public IActionResult AddSupclassSuperclassRelation(SubClassificationSuperClasiificationRelation add)
        {
            var result = _masterServices.AddSupclassSuperclassRelation(add);
            return Ok(result);
        }

        //[HttpGet("GetIndustryClassificationrelation")]
        //public IActionResult GetIndustryClassificationrelation()
        //{
        //    var result = _masterServices.GetIndustryClassificationrelation();
        //    return Ok(result);
        //}

        [HttpDelete("DeleteSupclassSuperclassRelation")]
        public IActionResult DeleteSupclassSuperclassRelation(int id)
        {
            var result = _masterServices.DeleteSupclassSuperclassRelation(id);
            return Ok(result);
        }

        [HttpDelete("DeleteIndustryClassRelation")]
        public IActionResult DeleteIndustryClassRelation(int id)
        {
            var result = _masterServices.DeleteIndustryClassRelation(id);
            return Ok(result);
        }

        [HttpDelete("DeleteClassSubClassRelation")]
        public IActionResult DeleteClassSubClassRelation(int id)
        {
            var result = _masterServices.DeleteClassSubClassRelation(id);
            return Ok(result);
        }

        [HttpPost("AddUpdateComapnyProcessRelation")]
        public IActionResult AddUpdateComapnyProcessRelation(CompanyProcess add)
        {
            var result = _masterServices.AddUpdateComapnyProcessRelation(add);
            return Ok(result);
        }

        [HttpDelete("DeleteCompanyProcess")]
        public IActionResult DeleteCompanyProcess(int id)
        {
            var result = _masterServices.DeleteCompanyProcess(id);
            return Ok(result);
        }

        [HttpGet("GetCompanyProcess")]
        public IActionResult GetCompanyProcess()
        {
            var result = _masterServices.GetCompanyProcess();
            return Ok(result);
        }

        [HttpPost("AddUpdateComapnyToolandtech")]
        public IActionResult AddUpdateComapnyToolandtech(ComapnyTooltech add)
        {
            var result = _masterServices.AddUpdateComapnyToolandtech(add);
            return Ok(result);
        }

        [HttpGet("GetCompanyToolandTech")]
        public IActionResult GetCompanyToolandTech()
        {
            var result = _masterServices.GetCompanyToolandTech();
            return Ok(result);
        }
        [HttpDelete("DeleteCompanyTollandTech")]
        public IActionResult DeleteCompanyTollandTech(int id)
        {
            var result = _masterServices.DeleteCompanyTollandTech(id);
            return Ok(result);
        }

        [HttpPost("AddUpdateJob")]
        public IActionResult AddUpdateJon(Jobs addnew)
        {
            var result = _masterServices.AddUpdateJob(addnew);
            return Ok(result);
        }

        //[HttpGet("Getjobid")]
        //public IActionResult Getjobid(int jobid)
        //{
        //    var result = _masterServices.Getjobid(jobid);
        //    return Ok(result);
        //}
        [HttpDelete("DeleteJob")]
        public IActionResult DeleteJob(int jobid)
        {
            var result = _masterServices.DeleteJob(jobid);
            return Ok(result);
        }

        [HttpDelete("DeleteFunctionalsubfunctional")]
        public IActionResult DeleteFunctionalsubfunctional(int id)
        {
            var result = _masterServices.DeleteFunctionalsubfunctional(id);
            return Ok(result);
        }

        [HttpPost("AddUpdateFunctionalSubfunctional")]
        public IActionResult AddUpdateFunctionalSubfunctional(FunctionalSubFunctional add)
        {
            var result = _masterServices.AddUpdateFunctionalSubfunctional(add);
            return Ok(result);
        }

        [HttpGet("GetFunctionalSubfunctional")]
        public IActionResult GetFunctionalSubfunctional()
        {
            var result = _masterServices.GetFunctionalSubfunctional();
            return Ok(result);
        }

        [HttpPost("AddUpdateSubFunctionalSuperfunctional")]
        public IActionResult AddUpdateSubFunctionalSuperfunctional(SubfunctionalSuperfunctional add)
        {
            var result = _masterServices.AddUpdateSubFunctionalSuperfunctional(add);
            return Ok(result);
        }

        [HttpGet("GetSubFunctionalSuperfunctional")]
        public IActionResult GetSubFunctionalSuperfunctional()
        {
            var result = _masterServices.GetSubFunctionalSuperfunctional();
            return Ok(result);
        }

        [HttpDelete("DeleteSubFunctionalsuperfunctional")]
        public IActionResult DeleteSubFunctionalsuperfunctional(int id)
        {
            var result = _masterServices.DeleteSubFunctionalsuperfunctional(id);
            return Ok(result);
        }
        [HttpPost("AddUpdateFunctionalJob")]
        public IActionResult AddUpdateFunctionalJob(FunctionalJob add)
        {
            var result = _masterServices.AddUpdateFunctionalJob(add);
            return Ok(result);
        }

        [HttpGet("GetFunctionalJobrelational")]
        public IActionResult GetFunctionalJobrelational()
        {
            var result = _masterServices.GetFunctionalJobrelational();
            return Ok(result);
        }

        [HttpDelete("DeleteFunctionalJob")]
        public IActionResult DeleteFunctionalJob(int id)
        {
            var result = _masterServices.DeleteFunctionalJob(id);
            return Ok(result);
        }

        [HttpPost("UploadAllMastersExcelSheetAsync")]
        public async Task<IActionResult> UploadAllMastersExcelSheetAsync([FromForm] UploadExcelSheetViewModel ReqExcelFile)
        {
            var result = await _masterServices.UploadAllMastersExcelSheetAsync(ReqExcelFile);
            return Ok(result);
        }

        [HttpPost("ImportClassification")]
        public async Task<object> ImportClassification([FromBody] importdatanew MapedField)
        {
            var result = await _masterServices.ImportClassification(MapedField);
            return Ok(result);
        }

        [HttpPost("ImportSubClassification")]
        public async Task<object> ImportSubClassification(importdatanew MapedField)
        {
            var result = await _masterServices.ImportSubClassification(MapedField);
            return Ok(result);
        }

        [HttpPost("ImportSuperClassification")]
        public async Task<object> ImportSuperClassification(importdatanew MapedField)
        {
            var result = await _masterServices.ImportSuperClassification(MapedField);
            return Ok(result);
        }

        [HttpPost("ImportDomains")]
        public async Task<object> ImportDomains(importdatanew MapedField)
        {
            var result = await _masterServices.ImportDomains(MapedField);
            return Ok(result);
        }

        [HttpPost("ImportIndustry")]
        public async Task<object> ImportIndustry(importdatanew MapedField)
        {
            var result = await _masterServices.ImportIndustry(MapedField);
            return Ok(result);
        }

        [HttpPost("ImportSubIndustry")]
        public async Task<object> ImportSubIndustry(importdatanew MapField)
        {
            var result = await _masterServices.ImportSubIndustry(MapField);
            return Ok(result);
        }

        [HttpPost("ImportProducts")]
        public async Task<object> ImportProducts(importdatanew MapField)
        {
            var result = await _masterServices.ImportProducts(MapField);
            return Ok(result);
        }

        [HttpPost("ImportIndustryGroups")]
        public async Task<object> ImportIndustryGroups(importdatanew MapField)
        {
            var result = await _masterServices.ImportIndustryGroups(MapField);
            return Ok(result);
        }

        [HttpPost("ImportServicess")]
        public async Task<object> ImportServicess(importdatanew MapField)
        {
            var result = await _masterServices.ImportServicess(MapField);
            return Ok(result);
        }

        [HttpPost("ImportProcess")]
        public async Task<object> ImportProcess(importdatanew MapField)
        {
            var result = await _masterServices.ImportProcess(MapField);
            return Ok(result);
        }

        [HttpPost("ImportToolendTechnologies")]
        public async Task<object> ImportToolendTechnologies(importdatanew MapField)
        {
            var result = await _masterServices.ImportToolendTechnologies(MapField);
            return Ok(result);
        }

        [HttpPost(" ImportFunctionalAreas")]
        public async Task<object> ImportFunctionalAreas(importdatanew MapField)
        {
            var result = await _masterServices.ImportFunctionalAreas(MapField);
            return Ok(result);
        }

        [HttpPost("ImportSubFunctionalAreas")]
        public async Task<object> ImportSubFunctionalAreas(importdatanew MapField)
        {
            var result = await _masterServices.ImportSubFunctionalAreas(MapField);
            return Ok(result);
        }

        [HttpPost("ImportSuperFunctionalAreas")]
        public async Task<object> ImportSuperFunctionalAreas(importdatanew MapField)
        {
            var result = await _masterServices.ImportSuperFunctionalAreas(MapField);
            return Ok(result);
        }

        [HttpPost("AddUpdateCurrentEmployee")]
        public IActionResult AddUpdateCurrentEmployee(Currentemp add)
        {
            var result = _masterServices.AddUpdateCurrentEmployee(add);
            return Ok(result);
        }

        [HttpDelete("DeleteCurrentEmployee")]
        public IActionResult DeleteCurrentEmployee(int employeeid)
        {
            var result = _masterServices.DeleteCurrentEmployee(employeeid);
            return Ok(result);
        }

        [HttpPost("AddUpdateEducationkey")]
        public IActionResult AddUpdateEducationkey(Educationkey add)
        {
            var result = _masterServices.AddUpdateEducationkey(add);
            return Ok(result);
        }

        [HttpPost("AddUpdateCoursecategory")]
        public IActionResult AddUpdateCoursecategory(Coursecate add)
        {
            var result = _masterServices.AddUpdateCoursecategory(add);
            return Ok(result);
        }

        [HttpPost("AddUpdateSkill")]
        public IActionResult AddUpdateSkill(Skill add)
        {
            var result = _masterServices.AddUpdateSkill(add);
            return Ok(result);
        }

        [HttpGet("GetCurrentemployee")]
        public IActionResult GetCurrentemployee()
        {
            var result = _masterServices.GetCurrentemployee();
            return Ok(result);
        }

        [HttpGet("GetEducationKey")]
        public IActionResult GetEducationKey()
        {
            var result = _masterServices.GetEducationKey();
            return Ok(result);
        }

        [HttpGet("GetCoursecategory")]
        public IActionResult GetCoursecategory()
        {
            var result = _masterServices.GetCoursecategory();
            return Ok(result);
        }

        [HttpGet("GetSkill")]
        public IActionResult GetSkill()
        {
            var result = _masterServices.GetSkill();
            return Ok(result);
            
        }

        //[HttpPost("AddUpdateJobCurrentEmployee")]
        //public IActionResult AddUpdateJobCurrentEmployee(JobCurrentemp add)
        //{
        //    var result = _masterServices.AddUpdateJobCurrentEmployee(add);
        //    return Ok(result);
        //}

        //[HttpGet("GetJobCurrentEmployee")]
        //public IActionResult GetJobCurrentEmployee()
        //{
        //    var result = _masterServices.GetJobCurrentEmployee();
        //    return Ok(result);
        

        [HttpGet("GetJobCurrentEmployerid")]
        public IActionResult GetJobCurrentEmployerid(int employeeid)
        {
            var result = _masterServices.GetJobCurrentEmployerid(employeeid);
            return Ok(result);
        }

        //[HttpPost("AddUpdateJobEducation")]
        //public IActionResult AddUpdateJobEducation(JobEducation add)
        //{
        //    var result = _masterServices.AddUpdateJobEducation(add);
        //    return Ok(result);
        //}

        //[HttpGet("GetJobEducation")]
        //public IActionResult GetJobEducation()
        //{
        //    var result = _masterServices.GetJobEducation();
        //    return Ok(result);
        //}

        [HttpPost("AddUpdateCompanyDomain")]
        public IActionResult AddUpdateCompanyDomain(CompanyDomain add)
        {
            var result = _masterServices.AddUpdateCompanyDomain(add);
            return Ok(result);
        }

        [HttpGet("GetCompanyDomain")]
        public IActionResult GetCompanyDomain()
        {
            var result = _masterServices.GetCompanyDomain();
            return Ok(result);
        }

        [HttpGet("GetJob")]
        public IActionResult GetJob()
        {
            var result = _masterServices.GetJob();
            return Ok(result);
        }

        //[HttpPost("AddUpdateJobs")]
        //public IActionResult AddUpdateJobs(JobAddUpdateModel addUpdateModel)
        //{
        //    var result = _masterServices.AddUpdateJobs(addUpdateModel);
        //    return Ok(result);
        //}

        [HttpGet("GetJobDetails")]
        public IActionResult GetJobDetails(int id, bool isEmployeeId)
        {
            var result = _masterServices.GetJobDetails(id, isEmployeeId);
            return Ok(result);
        }

        [HttpGet("GetAllCompanies")]
        public IActionResult GetAllCompanies([FromQuery] string masterstable, [FromQuery] string filterByName)
        {
            var result = _masterServices.GetAllCompanies(masterstable, filterByName);
            return Ok(result);
        }

        [HttpPost("CreateAllJobs")]
        public IActionResult CreateAllJobs(AllJob jobs)
        {
            var result = _masterServices.CreateAllJobs(jobs);
            return Ok(result);
        }

        [HttpGet("GetAllJobs")]
        public IActionResult GetAllJobs()
        {
            var result = _masterServices.GetAllJobs();
            return Ok(result);
        }

        [HttpPost("UpdateJobs")]
        public IActionResult UpdateJobs(AllJob jobs)
        {
            var result = _masterServices.UpdateJobs(jobs);
            return Ok(result);
        }

        [HttpPost("CreateCompany")]
        public IActionResult CreateCompany(AllCompany company)
        {
            var result = _masterServices.CreateCompany(company);
            return Ok(result);
        }

        //[HttpGet("Export")]
        //public IActionResult Export()
        //{
        //    var result = _masterServices.Export();
        //    return Ok(result);
        //}



        //[HttpGet("GetIndustryClassRelation")]
        //public IActionResult GetIndustryClassRelation()
        //{
        //    var result = _masterServices.GetIndustryClassRelation();
        //    return Ok(result);
        //}


    }
}
