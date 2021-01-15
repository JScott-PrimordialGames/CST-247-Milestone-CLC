using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mines_Web.Models;
using Mines_Web.Services.Data;

namespace Mines_Web.Services.Business
{
    public class StatesService
    {
        StatesDAO service = new StatesDAO();

        public List<StateModel> GetStates()
        {
            return service.GetStates();
        }
    }
}