using System;
using Newtonsoft.Json;
using Utils.Model;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Numerics;

public class JsonConnector
{

    public dynamic getJson(Object obj)
    {
        var json = JsonConvert.SerializeObject(obj,
               Newtonsoft.Json.Formatting.None,
               new JsonSerializerSettings
               {
                   NullValueHandling = NullValueHandling.Ignore
               });
        return json;
    }

    //Send a command to create a tunnel
    public dynamic CreateTunnel(string session, string key)
    {
        Rootobject createTunnel = new Rootobject();
        createTunnel.data = new Data();
        createTunnel.id = "tunnel/create";
        createTunnel.data.session = session;
        createTunnel.data.key = key;
        return getJson(createTunnel);
    }

    //Send a command through the tunnel
    public dynamic SendTunnel(string dest, dynamic json)
    {
        Rootobject sendTunnel = new Rootobject();
        sendTunnel.data = new Data();
        sendTunnel.id = "tunnel/send";
        sendTunnel.data.data = new Data();
        sendTunnel.data.dest = dest;
        sendTunnel.data.data = json;
        dynamic jsons = getJson(sendTunnel);

        return jsons;
    }

    //Sending for get scene
    public dynamic GetScene()
    {
        Rootobject getSend = new Rootobject();
        getSend.id = "scene/get";
        return getSend;

    }

    //Sending for reset scene

    public dynamic ResetScene()
    {
        Rootobject getSend = new Rootobject();
        getSend.id = "scene/reset";
        return getSend;

    }

    //Sending for saving scene
    public dynamic SaveScene(string filename, Boolean overwrite)
    {
        Rootobject sceneSave = new Rootobject();
        sceneSave.data = new Data();
        sceneSave.id = "scene/save";
        sceneSave.data.filename = filename;
        sceneSave.data.overwrite = overwrite;
        return sceneSave;
    }

    //Sending for loading scene
    public dynamic LoadScene(string filename)
    {
        Rootobject sceneLoad = new Rootobject();
        sceneLoad.data = new Data();
        sceneLoad.id = "scene/load";
        sceneLoad.data.filename = filename;
        return sceneLoad;
    }

    //Sending for raycast scene
    public dynamic RaycastScene(int[] start, int[] direction, bool physics)
    {
        Rootobject raycastScene = new Rootobject();
        raycastScene.data = new Data();
        raycastScene.id = "scene/raycast";
        raycastScene.data.start = start;
        raycastScene.data.direction = direction;
        raycastScene.data.physics = physics;
        return raycastScene;
    }

    //Sending for adding a terrainNode to scene
    public dynamic AddNodeSceneTerrain(string name, string parent, double[] position, int scale, int[] rotation,
        string file, bool cullbackfaces, bool animated, string animation, bool smoothnormals, int[] sizePanel,
        int[] resolutionPanel, int[] background, bool castShadow, int[] sizeWater, float resolutionWater)
    {
        Rootobject addNode = new Rootobject();
        addNode.id = "scene/node/add";
        addNode.data = new Data();
        addNode.data.name = name;
        addNode.data.parent = parent;
        addNode.data.components = new Components();
        addNode.data.components.transform = new Transform();
        addNode.data.components.transform.position = position;
        addNode.data.components.transform.scale = scale;
        addNode.data.components.transform.rotation = rotation;
        addNode.data.components.terrain = new Terrain();
        addNode.data.components.terrain.smoothnormals = smoothnormals;
        return addNode;
    }

    //Method for adding only a node to the terrain
    public dynamic AddNodeScene(string name, string parent, double[] position, float scale, int[] rotation,
          string file, bool cullbackfaces, bool animated, string animation, int[] panelSize = null, int[] panelResolution = null, double[] panelBackground = null, bool panelCastShadow = false)
    {
        Rootobject addNode = new Rootobject();
        addNode.id = "scene/node/add";
        addNode.data = new Data();
        addNode.data.name = name;
        addNode.data.parent = parent;
        addNode.data.components = new Components();
        addNode.data.components.transform = new Transform();
        addNode.data.components.transform.position = position;
        addNode.data.components.transform.scale = scale;
        addNode.data.components.transform.rotation = rotation;

        if (file != null)
        {
            addNode.data.components.model = new Model();
            addNode.data.components.model.file = file;
            addNode.data.components.model.cullbackfaces = cullbackfaces;
            addNode.data.components.model.animated = animated;
            addNode.data.components.model.animation = animation;
        }

        if (panelSize != null)
        {
            addNode.data.components.panel = new Panel();
            addNode.data.components.panel.size = panelSize;
            addNode.data.components.panel.resolution = panelResolution;
            addNode.data.components.panel.background = panelBackground;
            addNode.data.components.panel.castShadow = panelCastShadow;
        }

        return addNode;
    }

    public dynamic UpdateNodeScene(string dataId, string parent, double[] position, int[] rotation, int scale)
    {
        Rootobject addNode = new Rootobject();
        addNode.id = "scene/node/update";
        addNode.data = new Data();
        addNode.data.id = dataId;
        addNode.data.transform = new Transform();
        addNode.data.transform.position = position;
        addNode.data.transform.rotation = rotation;
        addNode.data.transform.scale = scale;
        addNode.data.parent = parent;
        return addNode;
    }

    public dynamic MovetoNodeScene(string id, string stop, double[] position, string rotate,
	    string interpolate, Boolean followheight, int speed, int time)
	{
		RootobjectMovetoNodeScene addNode = new RootobjectMovetoNodeScene();
		addNode.data = new DataMovetoNodeScene();
		addNode.id = "scene/node/moveto";
		addNode.data.id = id;
		addNode.data.stop = stop;
		addNode.data.position = position;
		addNode.data.rotate = rotate;
		addNode.data.interpolate = interpolate;
		addNode.data.followheight = followheight;
		addNode.data.speed = speed;
		addNode.data.time = time;
		return addNode;
	}

	public dynamic DeleteNodeScene(string id)
	{
		Rootobject deleteNode = new Rootobject();
		deleteNode.data = new Data();
		deleteNode.id = "scene/node/delete";
		deleteNode.data.id = id;
		return deleteNode;
	}

	public dynamic FindNodeScene(string id)
	{
		Rootobject findNode = new Rootobject();
		findNode.data = new Data();
		findNode.id = "scene/node/find";
		findNode.data.name = id;
		return findNode;
	}

	public dynamic AddLayerNodeScene(string id, string diffuse, string normal, int minHeight,
	    int maxHeight, int fadeDist)
	{
		Rootobject addLayerNode = new Rootobject();
		addLayerNode.data = new Data();
		addLayerNode.id = "scene/node/addlayer";
		addLayerNode.data.id = id;
		addLayerNode.data.diffuse = diffuse;
		addLayerNode.data.normal = normal;
		addLayerNode.data.minHeight = minHeight;
		addLayerNode.data.maxHeight = maxHeight;
		addLayerNode.data.fadeDist = fadeDist;
		return addLayerNode;
	}

	public dynamic DellayerNodeScene()
	{
		Rootobject dellayerNode = new Rootobject();
		dellayerNode.data = new Data();
		dellayerNode.id = "scene/node/dellayer";
		dellayerNode.data = new Data();
		return dellayerNode;
	}

	public dynamic ClearPanelScene(string id)
	{
		Rootobject clearPanel = new Rootobject();
		clearPanel.data = new Data();
		clearPanel.id = "scene/panel/clear";
		clearPanel.data.id = id;
		return clearPanel;
	}

	public dynamic SwapPanelScene(string id)
	{
		Rootobject swapPanel = new Rootobject();
		swapPanel.data = new Data();
		swapPanel.id = "scene/panel/swap";
		swapPanel.data.id = id;
		return swapPanel;
	}

	public dynamic DrawlinesPanelScene(string id, int width, int[] lines)
	{
		Rootobject drawlines = new Rootobject();
		drawlines.data = new Data();
		drawlines.id = "scene/panel/drawlines";
		drawlines.data.id = id;
		drawlines.data.width = width;
		drawlines.data.lines = lines;
		return drawlines;
	}

	public dynamic SetclearcolorPanelScene(string id, int[] color)
	{
		Rootobject setclearcolor = new Rootobject();
		setclearcolor.data = new Data();
		setclearcolor.id = "scene/panel/setclearcolor";
		setclearcolor.data.id = id;
		setclearcolor.data.color = color;
		return setclearcolor;
	}

	public dynamic ImagePanelScene(string id, string image, double[] position, double[] size)
	{
		RootobjectImagePanelScene imagePanel = new RootobjectImagePanelScene();
		imagePanel.data = new DataImagePanelScene();
		imagePanel.id = "scene/panel/image";
		imagePanel.data.id = id;
		imagePanel.data.image = image;
		imagePanel.data.position = position;
		imagePanel.data.size = size;
		return imagePanel;
	}

	public dynamic DrawTextPanelScene(string id, String text, double[] position, int size, int[] color, String font = null)
	{
		Rootobject drawText = new Rootobject();
		drawText.data = new Data();
		drawText.id = "scene/panel/drawtext";
		drawText.data.id = id;
		drawText.data.text = text;
		drawText.data.position = position;
		drawText.data.size = size;
		drawText.data.color = color;
		if (font != null) drawText.data.font = font;
		return drawText;
	}


	public dynamic RouteFollowSpeed(string nodeId, double speed)
	{
		RootObjectFollowRouteSpeed routeFollow = new RootObjectFollowRouteSpeed();
		routeFollow.data = new DataFollowRouteSpeed();
		routeFollow.id = "route/follow/speed";
		routeFollow.data.node = nodeId;
		routeFollow.data.speed = speed;
		return routeFollow;
	}

	public dynamic SkyboxSetTime(int time)
	{
		Rootobject SkyboxTime = new Rootobject();
		SkyboxTime.data = new Data();
		SkyboxTime.id = "scene/skybox/settime";
		SkyboxTime.data.time = time;
		return SkyboxTime;
	}

	public dynamic SkyboxUpdate(String type, Files files)
	{
		Rootobject SkyboxUpdate = new Rootobject();
		SkyboxUpdate.data = new Data();
		SkyboxUpdate.id = "scene/skybox/update";
		SkyboxUpdate.data.type = type;
        SkyboxUpdate.data.files = new Files();
		SkyboxUpdate.data.files = files;
		return SkyboxUpdate;
	}


	public dynamic AddTerrainScene(int[] size, double[] heights)
	{
		RootobjectAddTerrainScene addTerrain = new RootobjectAddTerrainScene();
		addTerrain.data = new DataAddTerrainScene();
		addTerrain.id = "scene/terrain/add";
		addTerrain.data.size = size;
		addTerrain.data.heights = heights;
		return addTerrain;
	}

	public dynamic UpdateTerrainScene()
	{
		Rootobject updateTerrain = new Rootobject();
		updateTerrain.data = new Data();
		updateTerrain.id = "scene/terrain/update";
		return updateTerrain;
	}
	public dynamic AddRoadScene(string route, string diffuse, string normal, string specular, float heightoffset)
	{
		Rootobject addPanel = new Rootobject();
		addPanel.data = new Data();
		addPanel.id = "scene/road/add";
		addPanel.data.route = route;
		addPanel.data.diffuse = diffuse;
		addPanel.data.normal = normal;
		addPanel.data.specular = specular;
		addPanel.data.heightoffset = heightoffset;
		return addPanel;
	}

	public dynamic UpdateRoadScene(string id, string route, string diffuse, string normal, string specular, float heightoffset)
	{
		Rootobject updatePanel = new Rootobject();
		updatePanel.data = new Data();
		updatePanel.id = "scene/road/update";
		updatePanel.data.id = id;
		updatePanel.data.route = route;
		updatePanel.data.diffuse = diffuse;
		updatePanel.data.normal = normal;
		updatePanel.data.specular = specular;
		updatePanel.data.heightoffset = heightoffset;
		return updatePanel;
	}

	public dynamic getHeightTerrainScene(double[] position, double[][] positions)
	{
		RootobjectGetHeightScene getHeight = new RootobjectGetHeightScene();
		getHeight.data = new DataGetHeightScene();
		getHeight.id = "scene/terrain/getheight";
		getHeight.data.position = position;
		getHeight.data.positions = positions;
		return getHeight;
	}

	public dynamic DeleteTerrainScene()
	{
		Rootobject deleteTerrain = new Rootobject();
		deleteTerrain.data = new Data();
		deleteTerrain.id = "scene/terrain/delete";
		return deleteTerrain;
	}
    
    

	public dynamic RouteDelete(string id)
	{
		Rootobject routeDelete = new Rootobject();
		routeDelete.data = new Data();
		routeDelete.id = "route/delete";
		routeDelete.data.id = id;

		return routeDelete;
	}

	public dynamic RouteShow(Boolean show)
	{
		Rootobject routeShow = new Rootobject();
		routeShow.data = new Data();
		routeShow.id = "route/show";
		routeShow.data.show = show;
		return routeShow;
	}

	public dynamic Get()
	{
		Rootobject get = new Rootobject();
		get.data = new Data();
		get.id = "get";
		get.data.type = "head";
		return get;
	}

	public dynamic SetCallback(string type, string button, string hand)
	{
		Rootobject setCallback = new Rootobject();
		setCallback.data = new Data();
		setCallback.id = "setcallback";
		setCallback.data.type = "button";
		setCallback.data.button = "trigger";
		setCallback.data.hand = "left";

		return setCallback;
	}

	public dynamic SendBikeInfo(int speed, double distance, int power, int requestedPower, string time, double RPM, int pulse, string energy)
	{
		RootObjectSendBikeInfo sendBikeInfo = new RootObjectSendBikeInfo();
		sendBikeInfo.data = new DataSendBikeInfo();
		sendBikeInfo.id = "Bike";
		sendBikeInfo.name = Environment.MachineName;
        sendBikeInfo.data.speed = speed;
        sendBikeInfo.data.distance = distance;
		sendBikeInfo.data.power = power;
		sendBikeInfo.data.requestedPower = requestedPower;
		sendBikeInfo.data.time = time;
		sendBikeInfo.data.RPM = RPM;
		sendBikeInfo.data.pulse = pulse;
		sendBikeInfo.data.energy = energy;
		return sendBikeInfo;
	}

	public dynamic SendChange(string time, double distance, int requestedPower, string name)
	{
		RootObjectSendChange sendChange = new RootObjectSendChange();
		sendChange.data = new DataSendChange();
		sendChange.id = "Change";
		sendChange.name = name;
		sendChange.data.time = time;
		sendChange.data.distance = distance;
		sendChange.data.requestedPower = requestedPower;
		return sendChange;
	}

    public dynamic SendChangePower(string name, int requestedPower)
    {
        dynamic sendChange = new JObject();
        sendChange.id = "ChangePower";
        sendChange.name = name;
        sendChange.requestedPower = requestedPower;
        return sendChange;
    }
    public dynamic Connect(Boolean doctor)
	{
		RootObjectConnect connect = new RootObjectConnect();
		connect.id = "AddClient";
		connect.name = System.Environment.MachineName;
        connect.doctor = doctor;
		return connect;
	}

	public dynamic SendNames(string[] names,  Patient[]patients)
	{
        
		RootObjectSendNames sn = new RootObjectSendNames();
		sn.id = "Ack";
		sn.names = names;
        sn.patientnames = patients;
		return sn;
	}

	public dynamic Play()
	{
		Rootobject play = new Rootobject();
		play.id = "play";
		return play;
	}
	public dynamic Pause()
	{
		Rootobject pause = new Rootobject();
		pause.id = "pause";
		return pause;
	}

    public dynamic BroadcastMessage(string message)
    {
        RootObjectBroadcast bm = new RootObjectBroadcast();
        bm.id = "Broadcast";
        bm.message = message;
        return bm;
    }

    public dynamic SendMessage(string message)
    {
        RootObjectBroadcast bm = new RootObjectBroadcast();
        bm.id = "Message";
        bm.message = message;
        return bm;
    }

    public dynamic PersonalMessage(string message, string name)
    {
        RootObjectPersonalMessage pm = new RootObjectPersonalMessage();
        pm.id = "PersonalMessage";
        pm.message = message;
        pm.name = name;
        return pm;
    }

    public dynamic EmergencyStop(string name)
    {
        RootObjectEmergencyStop es = new RootObjectEmergencyStop();
        es.id = "EmergencyStop";
        es.name = name;
        return es;
    }


	public dynamic Login(BigInteger username, BigInteger password)
	{
		RootLogin rootLogin = new RootLogin();
		rootLogin.id = "Login";
		rootLogin.password = password;
		rootLogin.username = username;
		return rootLogin;
	}

	public dynamic LoginResponse(Boolean access)
	{
		LoginResponse loginResponse = new LoginResponse();
		loginResponse.id = "LoginResponse";
		loginResponse.response = access;
		return loginResponse;
	}

	public dynamic AccesHistory(Patient patientInfo)
	{
		RootDataHistory history = new RootDataHistory();
		history.id = "AccesHistory";
		history.info = patientInfo;
		
		return history;
	}

    public dynamic AssignPt(string name)
    {
        AssignPatientNEW assignPatient = new AssignPatientNEW();
        assignPatient.id = "AssignPatient";
        assignPatient.name = name;
        return assignPatient;
    }

    public dynamic StartSes(int duration)
    {
        StartSession startSession = new StartSession();
        startSession.id = "StartSession";
        startSession.duration = duration;
        return startSession;
    }

    public dynamic AddPat(Patient patient)
    {
        AddPatient addPatient = new AddPatient();
        addPatient.id = "AddPatient";
        addPatient.patientInfo = patient;
        return addPatient;
    }

    public dynamic AddPatientNames(List<Patient> patient)
    {
		AllPatients ap = new AllPatients();
		ap.id = "PatientNames";
		ap.data = patient;
        return ap;
    }

    public dynamic SendCombo(string machine, string patient, string birth)
    {
        dynamic json = new JObject();
        json.id = "Combo";
        json.machine = machine;
        json.patient = patient;
        json.date = birth;
        return json;
    }
    
    public dynamic sendHistoryData(string json)
    {
        HistoryJson hj = new HistoryJson();
        hj.id = "HistoryData";
        hj.json = json;
        return hj;
    }

    public dynamic SendChangeTime(string time, string name)
    {
        dynamic sendChange = new JObject();
        sendChange.id = "ChangeTime";
        sendChange.name = name;
        sendChange.time = time;
        return sendChange;
    }

    public dynamic StartAvansTest(string name, Patient p)
    {
        dynamic test = new JObject();
        test.id = "StartAstrand";
        test.name = name;
        //test.patient = new JObject();
        test.patient = JObject.FromObject(p);
        return test;
    }

    public dynamic SendDocAstrandInfo(string infor, string name)
    {
        dynamic info = new JObject();
        info.id = "Astrand";
        info.info = infor;
        info.name = name;
        return info;
    }
}