using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroSE.Kanban.Backend.BusinessLayer
{

    /// <summary>
    /// A factory for the business layer classes<br/>
    /// This factory implements the singleton pattern<br/>
    /// use GetInstance() to get an instance of this factory.<br/><br/>
    /// <b>Note:</b> this factory instantiates each class excactly once and does not produce duplicates
    /// <code>Inventory:</code>
    /// <list type="bullet">
    /// <item>DataCenter</item>
    /// <item>BoardController</item>
    /// <item>UserController</item>
    /// <item>BoardMembersPermissions</item>
    /// </list>
    /// </summary>
    public class BusinessLayerFactory
    {
        private static BusinessLayerFactory instance = null;

        private DataCenter dataCenter;
        private BoardController boardController;
        private UserController userController;
        //private BoardMembersPermissions BMP;

        private BusinessLayerFactory()
        {
            dataCenter = new();
            boardController = new(dataCenter);
            userController = new(dataCenter);
            //BMP = new(dataCenter,boardController);
        }

        /// <summary>
        /// retrieve the DataCenter instance
        /// </summary>
        public DataCenter DataCenter => dataCenter;

        /// <summary>
        /// retrieve the BoardController instance
        /// </summary>
        public BoardController BoardController => boardController;

        /// <summary>
        /// retrieve the UserController instance
        /// </summary>
        public UserController UserController => userController;
        //public BoardMembersPermissions BoardMembersPermissions => BMP;


        /// <returns>The instance of the singleton BusinessLayerFatory</returns>
        public static BusinessLayerFactory GetInstance()
        {
            if (instance == null) instance = new();
            return instance;
        }

        /// <summary>
        /// Resets the factory instance to null <br/><br/>
        /// <b>WARNING: USED FOR UNIT TESTING PURPOSES ONLY</b>
        /// 
        /// </summary>
        public static void DeleteEverything()
        {
            instance = null;
        }

        

    }
    
}
