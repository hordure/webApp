using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp.Controllers;
using WebApp.Extra_Entities;
using System.Data.Entity;

namespace WebApp.Models
{
    public class Queries
    {

        private ProjectEntities db = new ProjectEntities();
        string username = WebApp.Models.ApplicationUser.CurrentUser;
        
        /// <summary>
        /// currentEmployeeController
        /// Get employeeId from AspNetUsers username (email)
        /// </summary>
        /// <returns></returns>
        public int GetUserId()
        {

            var q = from d in db.AspNetUsers
                    where d.UserName == username
                    select d.employee_eid;

            int userId = (int)q.FirstOrDefault();

            //TODO fix this
            projectsController.CurrentEmpId = userId;

            return userId;
        }

        /// <summary>
        /// currentEmployeeController
        /// Get User Info, incl. role for authorization in front end
        /// </summary>
        /// <returns></returns>
        public thisEmp GetCurrentEmployee()
        {

            thisEmp em = new thisEmp();
            if (username != "")
            {
                int empId = GetUserId();


                var emp = (from e in db.employees
                           from au in db.AspNetUsers
                           from ur in db.userroles
                           where e.eid == au.employee_eid
                           where e.userrole_urid == ur.urid
                           where e.eid == empId
                           select new thisEmp
                           {
                               userrole = ur.userrole1,
                               name = e.name,
                               username = au.UserName,
                               eid = e.eid
                           }).FirstOrDefault();

                return emp;

            }
            else
            {
                return em;
            }
        }

        /// <summary>
        /// projectmessagesController
        /// All project messages with employee name added
        /// </summary>
        /// <returns></returns>
        public IQueryable<project_messages> GetAllproject_messages()
        {
            var allProjectMessages = from pm in db.project_messages.Include(e => e.employee)

                                     //select pm;
                                     select new pmessagesWEmp
                                     {
                                         employeename = pm.employee.name,
                                         projectmessage = pm.projectmessage,
                                         employee_eid = pm.employee_eid,
                                         file = pm.file,
                                         pmid = pm.pmid,
                                         project_pid = pm.project_pid,
                                         filename = pm.filename,
                                         messagetimestamp = pm.messagetimestamp,
                                         project = pm.project
                                     };

            return allProjectMessages;
        }

        
        /// <summary>
        /// projectmessagesController
        /// All Project messages related to a particular project, with employee name added
        /// </summary>
        /// <returns></returns>
        public IQueryable<project_messages> Getproject_messages()
        {
            var currentProjectMessages = from pm in db.project_messages.Include(e => e.employee)
                                         where pm.project_pid == projectsController.CurrentProjectId
                                         //select pm;
                                         select new pmessagesWEmp
                                         {
                                             employeename = pm.employee.name,
                                             projectmessage = pm.projectmessage,
                                             employee_eid = pm.employee_eid,
                                             file = pm.file,
                                             pmid = pm.pmid,
                                             project_pid = pm.project_pid,
                                             filename = pm.filename,
                                             messagetimestamp = pm.messagetimestamp,
                                             project = pm.project
                                         };

            return currentProjectMessages;
        }

        /// <summary>
        /// projectCostsController
        /// Get all project costs with employee name and project title
        /// </summary>
        /// <returns></returns>
        public IQueryable<project_costs> GetAllproject_costs()
        {
            var currentProjectCosts = from pc in db.project_costs.Include(e => e.employee)
                                                                 .Include(p => p.project)


                                      //select pm;
                                      select new pcostsWEmp
                                      {
                                          employeeName = pc.employee.name,
                                          employee_eid = pc.employee_eid,
                                          projectTitle = pc.project.projectname,
                                          project_pid = pc.project_pid,
                                          cost = pc.cost,
                                          costdate = pc.costdate,
                                          costdescription = pc.costdescription,
                                          costtimestamp = pc.costtimestamp,
                                          pcid = pc.pcid
                                      };

            return currentProjectCosts;
        }

        /// <summary>
        /// project_costsController
        /// Get all project costs attached to currentProject with employee name and project title
        /// </summary>
        /// <returns></returns>
        public IQueryable<project_costs> Getproject_costs()
        {
            var currentProjectCosts = from pc in db.project_costs.Include(e => e.employee)
                                                                    .Include(p => p.project)
                                      where pc.project_pid == projectsController.CurrentProjectId
                                      //select pm;
                                      select new pcostsWEmp
                                      {
                                          employeeName = pc.employee.name,
                                          employee_eid = pc.employee_eid,
                                          projectTitle = pc.project.projectname,
                                          project_pid = pc.project_pid,
                                          cost = pc.cost,
                                          costdate = pc.costdate,
                                          costdescription = pc.costdescription,
                                          costtimestamp = pc.costtimestamp,
                                          pcid = pc.pcid
                                      };

            return currentProjectCosts;
        }

        /// <summary>
        /// project_hoursController
        /// Get all project hours with employee name
        /// </summary>
        /// <returns></returns>
        public IQueryable<project_hours> GetAllproject_hours()
        {
            var allProjectHours = from ph in db.project_hours.Include(e => e.employee)

                                     //select pm;
                                     select new phoursWEmp
                                     {
                                         projectTitle = ph.project.projectname,
                                         employeeName = ph.employee.name,
                                         workhour = ph.workhour,
                                         phid =ph.phid,
                                         hourdate = ph.hourdate,
                                         hourdescription = ph.hourdescription,
                                         hourtimestamp = ph.hourtimestamp
                                     };

            return allProjectHours;
        }

        public IQueryable<project_hours> Getproject_hours()
        {
            var currentProjectHours = from ph in db.project_hours.Include(e => e.employee)
                                      where ph.project_pid == projectsController.CurrentProjectId
                                      //select pm;
                                      select new phoursWEmp
                                      {
                                          projectTitle = ph.project.projectname,
                                          employeeName = ph.employee.name,
                                          phid = ph.phid,
                                          hourdate = ph.hourdate,
                                          hourdescription = ph.hourdescription,
                                          hourtimestamp = ph.hourtimestamp,
                                          workhour = ph.workhour

                                      };

            return currentProjectHours;
        }


        public List<SumHours> SumOfProject_hours()
        {
            //Sum of project_hours
            decimal sumOfHours = (from ph in db.project_hours
                              select ph.workhour).Sum();


            List<SumHours> tempList = new List<SumHours>();
            tempList.Add(new SumHours(sumOfHours));

            return tempList;
        }


        public List<SumCosts> SumOfCosts()
        {
            int sumOfCosts = (from pc in db.project_costs
                              select pc.cost).Sum();

            List<SumCosts> tempList = new List<SumCosts>();
            tempList.Add(new SumCosts(sumOfCosts));

            return tempList;
        }

        /// <summary>
        /// projectsController
        /// Get all projects where logged in user is owner
        /// </summary>
        /// <returns></returns>
        public IEnumerable<projectWEmp> Getprojects()
        {
            int userId = GetUserId();

            var projects = from p in db.projects.Include(e => e.employee)
                           where p.employee_eid == userId
                           select new projectWEmp
                           {
                               pid = p.pid,
                               projectname = p.projectname,
                               employee = p.employee.name,
                               pdescription = p.pdescription,
                               pdate = p.pdate,
                               pdeadline = p.pdeadline,
                               projectisfinished = p.projectisfinished
                           };
            return projects;
        }

        public IEnumerable<project> GetAffiliateProjects()
        {

            int userId = GetUserId();

            var affiliateProjects = from p in db.projects.Include(e => e.employee)
                                    from pe in db.project_employees
                                    where pe.employee_eid == userId
                                    where p.pid == pe.project_pid
                                    select new projectWEmp
                                    {
                                        pid = p.pid,
                                        projectname = p.projectname,
                                        employee = p.employee.name,
                                        pdescription = p.pdescription,
                                        pdate = p.pdate,
                                        pdeadline = p.pdeadline,
                                        projectisfinished = p.projectisfinished
                                    };

            return affiliateProjects;
        }

        /// <summary>
        /// employeesController  /api/emspNotInProject
        /// Get a list of employees who are not part of project yet
        /// </summary>
        /// <returns></returns>
        public IQueryable<tempEmp> GetEmployeesNotInProject()
        {
           

            var list1 = (from e in db.employees
                        select new tempEmp
                        {
                            name = e.name,
                            profession = e.profession,
                            eid = e.eid
                        }).Except
                        (from e in db.employees
                        from pe in db.project_employees
                        where e.eid == pe.employee_eid
                         where pe.project_pid == projectsController.CurrentProjectId
                        select new tempEmp
                        {
                            name = e.name,
                            profession = e.profession,
                            eid = e.eid
                        });

            


            return list1;



        }

        public IQueryable<tempEmp> GetProjectEmployees()
        {
            var projectemployees = from e in db.employees
                                   from pe in db.project_employees
                                   where pe.project_pid == projectsController.CurrentProjectId
                                   where e.eid == pe.employee_eid
                                   select new tempEmp
                                   {
                                       peid = pe.peid,
                                       name = e.name,
                                       profession = e.profession,
                                       eid = e.eid
                                   };

            return projectemployees;

        }

        public tempEmp GetProjectEmployee(int id)
        {

            tempEmp em = new tempEmp();
            


            var emp = (from e in db.employees
                        
                        where e.eid == id                      
                       select new tempEmp
                        {
                            name = e.name,
                            profession = e.profession,
                            eid = e.eid
                        }).FirstOrDefault();

            return emp;

         
        }
    }
}