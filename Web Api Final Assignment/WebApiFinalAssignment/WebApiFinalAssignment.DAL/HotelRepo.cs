using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiFinalAssignment.DAL.Interface;
using WebApiFinalAssignment.Models;

namespace WebApiFinalAssignment.DAL
{
    public class HotelRepo : IHotelRepo
    {
        public List<HotelsModel> GetAllHotels()
        {
            try {
                using (var entity = new WebApiFinalAssignmentEntities())
                {
                    var result = entity.Hotels.Select(x => new HotelsModel() {
                        Id = x.Id,
                        Name = x.Name,
                        Address = x.Address,
                        City=x.City,
                        Pincode=x.Pincode,
                        ContactNumber=x.ContactNumber,
                        ContactPerson=x.ContactPerson,
                        Website=x.Website,
                        Facebook=x.Facebook,
                        Twitter=x.Twitter,
                        IsActive=x.IsActive,
                        CreatedBy=x.CreatedBy,
                        CreatedDate=x.CreatedDate,
                        UpdatedBy=x.UpdatedBy,
                        UpdatedDate=x.UpdatedDate

                    }).OrderBy(x=>x.Name).ToList();
                    return result;
                }
            }
            catch(Exception e)
            {
                return new List<HotelsModel>();
            }
            }

        public void PostAddHotel(HotelsModel model)
        {
            try
            {
                using (var entity = new WebApiFinalAssignmentEntities())
                {
                    Hotel h = new DAL.Hotel();
                    h.Name = model.Name;
                    h.Address = model.Address;
                    h.City = model.City;
                    h.Pincode = model.Pincode;
                    h.ContactNumber = model.ContactNumber;
                    h.ContactPerson = model.ContactPerson;
                    h.Website = model.Website;
                    h.Facebook = model.Facebook;
                    h.Twitter = model.Twitter;
                    h.CreatedBy = model.CreatedBy;
                    h.CreatedDate = model.CreatedDate;
                    h.UpdatedBy = model.UpdatedBy;
                    h.UpdatedDate = model.UpdatedDate;




                    entity.Hotels.Add(h);
                    entity.SaveChanges();
                }
            }
            catch(Exception e)
            {

            }
        }
    }
}
