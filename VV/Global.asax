<%@ Application Language="C#" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="Microsoft.Practices.EnterpriseLibrary.Logging" %>

<script runat="server">

    static Cache _cache = null;
    static String _globalCacheFilePath = null;
    static String _globalSiteMapFilePath = null;
    
    void Application_Start(object sender, EventArgs e) 
    {   
        _globalCacheFilePath = Server.MapPath("~/App_Data/CachedProperties.xml");
        _cache = Context.Cache;

        _globalSiteMapFilePath = Server.MapPath("~/App_data/SiteMap.xml");        
        
        CacheDependency cacheDep = new CacheDependency(_globalCacheFilePath);
        CacheDependency cacheDepSM = new CacheDependency(_globalSiteMapFilePath);
        
        DataSet ds = new DataSet();
        ds.ReadXml(_globalCacheFilePath);
        _cache.Insert("GlobalCache", ds, cacheDep, Cache.NoAbsoluteExpiration, Cache.NoSlidingExpiration, CacheItemPriority.NotRemovable, new CacheItemRemovedCallback(RefreshCache));

        DataSet siteMapDs = new DataSet();
        siteMapDs.ReadXml(_globalSiteMapFilePath);
        _cache.Insert("SiteMapCache", siteMapDs, cacheDepSM, Cache.NoAbsoluteExpiration, Cache.NoSlidingExpiration, CacheItemPriority.NotRemovable, new CacheItemRemovedCallback(RefreshSiteMapCache));

        Random rndm = new Random(1000);
        Application["Random"] = rndm;

        Logger.Write(this.GetType().ToString() + " : Global.asax : " + " : " + DateTime.Now + " : " + "Loaded Global Cache...", "General", 0);
    }

    void RefreshCache(String key,Object item, CacheItemRemovedReason reason)
    {
        CacheDependency cacheDep = new CacheDependency(_globalCacheFilePath);

        DataSet ds = new DataSet();
        ds.ReadXml(_globalCacheFilePath);
        _cache.Insert("GlobalCache", ds, cacheDep, Cache.NoAbsoluteExpiration, Cache.NoSlidingExpiration, CacheItemPriority.NotRemovable, new CacheItemRemovedCallback(RefreshCache));

        Logger.Write(this.GetType().ToString() + " : Global.asax : " + " : " + DateTime.Now + " : " + "Refreshed Global Cache...", "General", 0);        
    }

    void RefreshSiteMapCache(String key, Object item, CacheItemRemovedReason reason)
    {
        CacheDependency cacheDepSM = new CacheDependency(_globalSiteMapFilePath);
        
        DataSet siteMapDs = new DataSet();
        siteMapDs.ReadXml(_globalSiteMapFilePath);
        _cache.Insert("SiteMapCache", siteMapDs, cacheDepSM, Cache.NoAbsoluteExpiration, Cache.NoSlidingExpiration, CacheItemPriority.NotRemovable, new CacheItemRemovedCallback(RefreshSiteMapCache));

        Logger.Write(this.GetType().ToString() + " : Global.asax : " + " : " + DateTime.Now + " : " + "Refreshed SiteMap Cache...", "General", 0);                
    }

    void Application_End(object sender, EventArgs e) 
    {
        //  Code that runs on application shutdown
    }
        
    void Application_Error(object sender, EventArgs e) 
    {
        Exception objErr = Server.GetLastError().GetBaseException();
        string RootURL = "Error Caught in Application_Error event\n" + "Error in: " + Request.Url.ToString();
        string errorMsg = "\nError Message:" + objErr.Message.ToString();
        string errorStackTrace = "\nStack Trace:" + objErr.StackTrace.ToString();
        Session["RootURl"] = RootURL;
        Session["errorMsg"] = errorMsg;
        Session["errorStackTrace"] = errorStackTrace;
        Server.ClearError();
        Logger.Write(this.GetType().ToString() + " : Application_Error() " + " : " + DateTime.Now + " : " + errorMsg.ToString(), "General", 0);
        Response.Redirect("ErrorPage.aspx");
       
    }

    void Session_Start(object sender, EventArgs e) 
    {
        // Code that runs when a new session is started      
    }

    void Session_End(object sender, EventArgs e) 
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.
    }
       
</script>
