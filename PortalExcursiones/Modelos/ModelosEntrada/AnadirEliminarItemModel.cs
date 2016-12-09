using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalExcursiones.Modelos.ModelosEntrada
{
    public class AnadirEliminarItemModel
    {
        private long item_id;
        private long exact_id;

        public long Item_id
        {
            get
            {
                return item_id;
            }

            set
            {
                item_id = value;
            }
        }

        public long Exact_id
        {
            get
            {
                return exact_id;
            }

            set
            {
                exact_id = value;
            }
        }
    }
}