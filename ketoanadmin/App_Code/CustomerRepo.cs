using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CustomerRepo
/// </summary>
public class CustomerRepo
{
	public CustomerRepo()
	{
		//
		// TODO: Add constructor logic here
		//
    }
    private ketoanadminDataContext db = new ketoanadminDataContext();
    public virtual Customer GetByAppcode(string code)
    {
        try
        {
            return this.db.Customers.Single(u => u.Appcode == code);
        }
        catch
        {
            return null;
        }
    }
    public virtual Customer GetById(int id)
    {
        try
        {
            return this.db.Customers.Single(u => u.ID == id);
        }
        catch
        {
            return null;
        }
    }
    public virtual IQueryable GetAll()
    {
        return this.db.Customers;
    }
    public virtual void Create(Customer user)
    {
        try
        {
            this.db.Customers.InsertOnSubmit(user);
            db.SubmitChanges();
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
    public virtual void Update(Customer user)
    {
        try
        {
            Customer userOld = this.GetById(user.ID);
            userOld = user;
            db.SubmitChanges();
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }


    public virtual void Remove(int id)
    {
        try
        {
            Customer user = this.GetById(id);
            this.Remove(user);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
    public virtual void Remove(Customer user)
    {
        try
        {
            db.Customers.DeleteOnSubmit(user);
            db.SubmitChanges();
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
    public virtual int Delete(int id)
    {
        try
        {
            Customer user = this.GetById(id);
            return this.Delete(user);
        }
        catch (Exception e)
        {

            throw new Exception(e.Message);
        }
    }
    public virtual int Delete(Customer user)
    {
        try
        {
            //user.IsDelete = true;
            db.SubmitChanges();
            return 0;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}