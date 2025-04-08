using System;
using E_com.Data;
using E_com.Model;
using E_com.VeiwModel;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace E_com.Services
{
    public interface IComServices
    {
        object AddUser(User addnewuser);
        object EditUser(User req);
        object DeleteUser(User req);
        object AddProduct(Products addnewproduct);
        object EditProduct(Products products);
        object DeleteProduct(Products delete);
        object GetProduct();
        object GetProductByUser(int userid);
    }
    public class ComServices : IComServices
    {
        private readonly AppDbContext  _appDbContext;
        FinalreturnModel finalreturnModel = new FinalreturnModel();

        public ComServices(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public object AddUser(User addnewuser)
        {
            try
            {
                if (addnewuser.USerName == null)
                {
                    finalreturnModel.Message = "FullName is Required";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }
                if (addnewuser.UserId != 0)
                {
                    var userId = addnewuser.UserId;
                    var IsExist = _appDbContext.User.Where(x => x.UserId == userId).FirstOrDefault();
                    if (IsExist != null)
                    {
                        IsExist.USerName = addnewuser.USerName;
                        IsExist.Email = addnewuser.Email;
                        IsExist.PhoneNumber = addnewuser.PhoneNumber;
                        IsExist.Address = addnewuser.Address;
                        IsExist.UserType = addnewuser.UserType;

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
                    var Exist = _appDbContext.User.Where(x => x.USerName == addnewuser.USerName).FirstOrDefault();
                    if (Exist == null)
                    {
                        User newGrade = new User();
                        newGrade.USerName = addnewuser.USerName;
                        newGrade.Email = addnewuser.Email;
                        newGrade.PhoneNumber = addnewuser.PhoneNumber;
                        newGrade.Address = addnewuser.Address;
                        newGrade.UserType = addnewuser.UserType;
                        newGrade.Password = addnewuser.Password;
                        _appDbContext.User.Add(newGrade);
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

        public object EditUser(User req)
        {
            try
            {
                if (req.UserId == 0)
                {
                    finalreturnModel.Message = "Id is required!";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }
                var user = _appDbContext.User.Where(x => x.UserId == req.UserId ).FirstOrDefault();
                if (user != null)
                {
                    user.UserId = req.UserId;
                    user.USerName = req.USerName;
                    user.Address = req.Address;
                    user.PhoneNumber = req.PhoneNumber;
                    user.Email = req.Email;
                    user.UserType = req.UserType;
                    user.Password = req.Password;
                    _appDbContext.SaveChanges();
                    finalreturnModel.Message = "updated";
                    finalreturnModel.Success = true;
                }
                else
                {
                    finalreturnModel.Message = "data not found";
                    finalreturnModel.Success = false;
                }
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

        public object DeleteUser(User req)
        {
            var Remove = _appDbContext.User.Where(X => X.UserId == req.UserId).FirstOrDefault();
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

        public object AddProduct(Products addnewproduct)
        {
            var Addnew = _appDbContext.Products.Where(x => x.ProductId == addnewproduct.ProductId).FirstOrDefault();
            if (Addnew == null)
            {
                Products newGrade = new Products();
                newGrade.Name = addnewproduct.Name;
                newGrade.Description = addnewproduct.Description;
                newGrade.IsSold = addnewproduct.IsSold;
                newGrade.SoldAt = addnewproduct.SoldAt;
                newGrade.PaymentMethod = addnewproduct.PaymentMethod;
                newGrade.CreatedBy = addnewproduct.CreatedBy;
                newGrade.CreatedAt = addnewproduct.CreatedAt;
                newGrade.IsDeleted = addnewproduct.IsDeleted;
                newGrade.DeletedBy = addnewproduct.DeletedBy;
                _appDbContext.Products.Add(newGrade);
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

        public object EditProduct(Products products)
        {
            try
            {
                if (products.ProductId == 0)
                {
                    finalreturnModel.Message = "Id is required!";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }
                var user = _appDbContext.Products.Where(x => x.ProductId == products.ProductId).FirstOrDefault();
                if (user != null)
                {
                    
                    user.Name = products.Name;
                    user.Description = products.Description;
                    user.IsSold = products.IsSold;
                    user.SoldAt = products.SoldAt;
                    user.PaymentMethod= products.PaymentMethod;
                    user.CreatedBy = products.CreatedBy;
                    user.CreatedAt = products.CreatedAt;
                    user.IsDeleted = products.IsDeleted;
                    user.DeletedBy = products.DeletedBy;
                    _appDbContext.SaveChanges();
                    finalreturnModel.Message = "updated";
                    finalreturnModel.Success = true;
                }
                else
                {
                    finalreturnModel.Message = "data not found";
                    finalreturnModel.Success = false;
                }
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

        public object DeleteProduct(Products delete)
        {
            var Remove = _appDbContext.Products.Where(X => X.ProductId == delete.ProductId).FirstOrDefault();
            if (Remove != null)
            {
                Remove.IsDeleted = true;
                //_appDbContext.Remove(Remove);
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

        public object GetProduct()
        {
            var product = (from e in _appDbContext.Products
                           join u in _appDbContext.User on e.ProductId equals u.UserId into deptGroup
                           from u in deptGroup.DefaultIfEmpty()
                           select new
                           {
                               e.ProductId,

                               e.Description,
                               e.IsSold,
                               e.SoldAt,
                               e.PaymentMethod,
                               e.CreatedBy,
                               e.CreatedAt,
                               e.IsDeleted,
                               e.DeletedBy,
                               u.USerName,
                               //Users = u != null ? u.USerName: null
                           }).ToList();
            finalreturnModel.Success = true;
            return (product);
        }

        public object GetProductByUser(int productid)
        {
            try
            {
                if(productid == 0)
                {
                    finalreturnModel.Message = "id is required";
                    finalreturnModel.Success = false;
                    return finalreturnModel;
                }
                var result = (from u in _appDbContext.User
                             join p in _appDbContext.Products on u.UserId  equals p.ProductId into uJoin
                             from p in uJoin.DefaultIfEmpty()
                             join u1 in _appDbContext.User on p.Name equals u1.USerName into u1Join
                             from u1 in u1Join.DefaultIfEmpty()
                             //where u.UserId== 0 && p.IsDeleted == 0 && u1.IsDeleted == 0 && p.Id == Users
                             select new
                             {
                                 u.UserId,
                                 u.USerName,
                                 u.UserType,
                                 p.Name,
                                 p.Description
                                 
                             }).FirstOrDefault();
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
                //var result = (from p in _appDbContext.Products
                //              join u in _appDbContext.Users on p.Name equals u.UserId into uJoin
                //              from u in uJoin.DefaltEmpty()

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

     






    }

     


    
}

