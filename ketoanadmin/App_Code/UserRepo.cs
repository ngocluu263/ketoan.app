using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UserRepo
/// </summary>
public class UserRepo
{
	public UserRepo()
	{
		//
		// TODO: Add constructor logic here
		//
    }
    private ketoanadminDataContext db = new ketoanadminDataContext();
    public virtual User GetByUsername(string username)
    {
        try
        {
            return this.db.Users.Single(u => u.Username == username);
        }
        catch
        {
            return null;
        }
    }
    public virtual User GetById(int id)
    {
        try
        {
            return this.db.Users.Single(u => u.ID == id);
        }
        catch
        {
            return null;
        }
    }
    public virtual IQueryable GetAll()
    {
        return this.db.Users;
    }
    public virtual void Create(User user)
    {
        try
        {
            this.db.Users.InsertOnSubmit(user);
            db.SubmitChanges();
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
    public virtual void Update(User user)
    {
        try
        {
            User userOld = this.GetById(user.ID);
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
            User user = this.GetById(id);
            this.Remove(user);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
    public virtual void Remove(User user)
    {
        try
        {
            db.Users.DeleteOnSubmit(user);
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
            User user = this.GetById(id);
            return this.Delete(user);
        }
        catch (Exception e)
        {

            throw new Exception(e.Message);
        }
    }
    public virtual int Delete(User user)
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