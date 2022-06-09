
namespace IntroSE.Kanban.Backend.BusinessLayer
{

    /// <summary>
    /// A factory for the business layer classes<br/>
    /// This factory implements the singleton pattern<br/>
    /// use GetInstance() to get an instance of this factory.<br/><br/>
    /// <b>Note:</b> this factory instantiates each class excactly once and does not produce duplicates
    /// <code>Inventory:</code>
    /// <list type="bullet">
    /// <item>UserDataOperations</item>
    /// <item>BoardDataOperations</item>
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
        private BoardMembersPermissions boardMembersPermissions;

        private BusinessLayerFactory()
        {
            dataCenter = new();
            boardController = new(dataCenter);
            userController = new(dataCenter);
            boardMembersPermissions = new();
        }

        /// <summary>
        /// retrieve the DataCenter instance
        /// </summary>
        public BoardDataOperations BoardDataOperations => dataCenter;

        /// <summary>
        /// retrieve the DataCenter instance
        /// </summary>
        public UserDataOperations UserDataOperations => dataCenter;

        /// <summary>
        /// retrieve the BoardController instance
        /// </summary>
        public BoardController BoardController => boardController;

        /// <summary>
        /// retrieve the UserController instance
        /// </summary>
        public UserController UserController => userController;
        //public BoardMembersPermissions BoardMembersPermissions => BMP;

        /// <summary>
        /// retrieve the BoardController instance
        /// </summary>
        public DataCenterManagement DataCenterManagement => dataCenter;

        /// <summary>
        /// retrieve the BoardMemebersPermissions instance
        /// </summary>
        public BoardMembersPermissions BoardMembersPermissions => boardMembersPermissions;

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
