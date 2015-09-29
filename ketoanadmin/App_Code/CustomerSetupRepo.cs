using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CustomerSetupRepo
/// </summary>
public class CustomerSetupRepo
{
	public CustomerSetupRepo()
	{
		//
		// TODO: Add constructor logic here
		//
    }
    private ketoanadminDataContext db = new ketoanadminDataContext();

    public virtual CustomerSetup GetById(int id)
    {
        try
        {
            return this.db.CustomerSetups.Single(u => u.ID == id);
        }
        catch
        {
            return null;
        }
    }
    public virtual IQueryable GetAll()
    {
        return this.db.CustomerSetups;
    }
    public virtual void Create(CustomerSetup user)
    {
        try
        {
            this.db.CustomerSetups.InsertOnSubmit(user);
            db.SubmitChanges();
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
    public virtual void Update(CustomerSetup user)
    {
        try
        {
            CustomerSetup userOld = this.GetById(user.ID);
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
            CustomerSetup user = this.GetById(id);
            this.Remove(user);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
    public virtual void Remove(CustomerSetup user)
    {
        try
        {
            db.CustomerSetups.DeleteOnSubmit(user);
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
            CustomerSetup user = this.GetById(id);
            return this.Delete(user);
        }
        catch (Exception e)
        {

            throw new Exception(e.Message);
        }
    }
    public virtual int Delete(CustomerSetup user)
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