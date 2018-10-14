using System;
using System.Collections.Generic;
using System.Numerics;
using Newtonsoft.Json;
using Utils.Model;

public class Rootobject
{
	public string id { get; set; }
	public Data data { get; set; }
}

public class RootobjectMovetoNodeScene
{
	public string id { get; set; }
	public DataMovetoNodeScene data { get; set; }

}

public class RootobjectImagePanelScene
{
	public string id { get; set; }
	public DataImagePanelScene data { get; set; }

}

public class RootobjectAddTerrainScene
{
	public string id { get; set; }
	public DataAddTerrainScene data { get; set; }

}

public class RootobjectGetHeightScene
{
	public string id { get; set; }
	public DataGetHeightScene data { get; set; }
}


public class RootObjectFollowRoute
{
	public string id { get; set; }
	public DataFollowRoute data { get; set; }
}

public class RootObjectSendBikeInfo
{
	public string id { get; set; }
	public string name { get; set; }
	public DataSendBikeInfo data { get; set; }
}

public class RootObjectSendChange
{
	public string id { get; set; }
	public string name { get; set; }
	public DataSendChange data { get; set; }
}

public class RootObjectConnect
{
    public string id { get; set; }
    public string name { get; set; }
    public Boolean doctor { get; set; }
}

public class RootObjectSendNames
{
    public string id { get; set; }
    public string[] names { get; set; }
    public Patient[] patientnames { get; set; }
}

public class RootObjectBroadcast
{
    public string id { get; set; }
    public string message { get; set; }
}

public class RootObjectPersonalMessage
{
    public string id { get; set; }
    public string message { get; set; }
    public string name { get; set; }
}

public class RootObjectEmergencyStop
{
    public string id { get; set; }
    public string name { get; set; }
}

public class Data
{
	internal bool? show;
	internal string button;
	internal string hand;

	public string filename { get; set; }
	public bool? overwrite { get; set; }
	public int[] start { get; set; }
	public int[] direction { get; set; }
	public bool? physics { get; set; }
	public string name { get; set; }
	public string parent { get; set; }
	public Components components { get; set; }
	public Transform transform { get; set; }
	public Animation animation { get; set; }
	public string stop { get; set; }
	public double[] position { get; set; }
	public string rotate { get; set; }
	public string interpolate { get; set; }
	public bool? followheight { get; set; }
	public int? speed { set; get; }
	public int? time { get; set; }
	public string diffuse { get; set; }
	public string normal { get; set; }
	public int? minHeight { get; set; }
	public int? maxHeight { get; set; }
	public int? fadeDist { get; set; }
	public int? width { get; set; }
	public int[] lines { get; set; }
	public int[] color { get; set; }
	public string text { get; set; }
	public int? size { get; set; }
	public string font { get; set; }
	public string image { get; set; }
	public string type { get; set; }
	public Files files { get; set; }
	public string route { get; set; }
	public string specular { get; set; }
	public float? heightoffset { get; set; }
	public dynamic data { get; set; }
	public string dest { get; set; }
	public string id
	{ get; set; }
	public string session { get; set; }
	public string key { get; set; }
}

public class DataSendChange
{
	public double? distance;
	public int? requestedPower;
	public string time;

}

public class DataSendBikeInfo
{
	public int? speed { get; set; }
	public double? distance { get; set; }
	public int? power { get; set; }
	public int? requestedPower { get; set; }
	public string time { get; set; }
	public double? RPM { get; set; }
	public int? pulse { get; set; }
	public string energy { get; set; }

	public override string ToString()
	{
		return this.speed + "\n" + this.distance + "\n" + this.power + "\n" + this.requestedPower
				+ "\n" + this.time + "\n" + this.RPM + "\n" + this.pulse + this.energy;
	}
}


public class DataMovetoNodeScene
{
	public string filename { get; set; }
	public bool? overwrite { get; set; }
	public int[] start { get; set; }
	public int[] direction { get; set; }
	public bool? physics { get; set; }
	public string name { get; set; }
	public string parent { get; set; }
	public Components components { get; set; }
	public Transform transform { get; set; }
	public Animation animation { get; set; }
	public string stop { get; set; }
	public double[] position { get; set; }
	public string rotate { get; set; }
	public string interpolate { get; set; }
	public bool? followheight { get; set; }
	public int? speed { set; get; }
	public int? time { get; set; }
	public string diffuse { get; set; }
	public string normal { get; set; }
	public int? minHeight { get; set; }
	public int? maxHeight { get; set; }
	public int? fadeDist { get; set; }
	public int? width { get; set; }
	public int[] lines { get; set; }
	public int[] color { get; set; }
	public string text { get; set; }
	public double? size { get; set; }
	public string font { get; set; }
	public string image { get; set; }

	public string id
	{ get; set; }
	public Data data { get; set; }

}


public class DataFollowRoute
{
	public string route;
	public string node;
	public double? speed;
	public double? offset;
	public string rotate;
	public double? smoothing;
	public bool? followHeight;
	public int[] rotateOffset;
	public int[] positionOffset;
}

public class DataImagePanelScene
{
	public string id { get; set; }
	public string image { get; set; }
	public double[] position { get; set; }
	public double[] size { get; set; }
	public double[][] positions { get; set; }
}

public class DataGetHeightScene
{
	public string id { get; set; }
	public double[] position { get; set; }
	public double[][] positions { get; set; }
}

public class DataAddTerrainScene
{
	public int[] size { get; set; }
	public double[] heights { get; set; }
}

public class Components
{
	public Transform transform { get; set; }
	public Model model { get; set; }
	public Terrain terrain { get; set; }
	public Panel panel { get; set; }
	public Water water { get; set; }
}

public class Transform
{
	public double[] position { get; set; }
	public float? scale { get; set; }
	public int[] rotation { get; set; }
}

public class Model
{
	public string file { get; set; }
	public bool? cullbackfaces { get; set; }
	public bool? animated { get; set; }
	public string animation { get; set; }
}

public class Terrain
{
	public bool? smoothnormals { get; set; }
}

public class Panel
{
	public int[] size { get; set; }
	public int[] resolution { get; set; }
	public double[] background { get; set; }
	public bool? castShadow { get; set; }
}

public class Water
{
	public int[] size { get; set; }
	public float? resolution { get; set; }
}


public class Animation
{
	public string name { get; set; }
	public float? speed { get; set; }
}

public class Files
{
	public string xpos { get; set; }
	public string xneg { get; set; }
	public string ypos { get; set; }
	public string yneg { get; set; }
	public string zpos { get; set; }
	public string zneg { get; set; }
}


public class RootObjectFollowRouteSpeed
{
	public string id { get; set; }
	public DataFollowRouteSpeed data { get; set; }
}

public class DataFollowRouteSpeed
{
	public string node;
	public double? speed;
}

public class RootLogin
{
	public string id { get; set; }
	public BigInteger username { get; set; }
	public BigInteger password { get; set; }
}

public class LoginResponse
{
	public string id { get; set; }
	public Boolean response { get; set; }
}

public class RootDataHistory
{
	public string id { get; set; }
	public string name { get; set; }
	public string birthDate { get; set; }
	public Patient info { get; set; }
}

public class AssignPatient
{
    public string id { get; set; }
    public int IndexOfPatient { get; set; }
}

public class AssignPatientNEW
{
    public string id { get; set; }
    public string name { get; set; }
}

public class StartSession
{
    public string id { get; set; }
    public int duration { get; set; }
}

public class AddPatient
{
    public string id { get; set; }
    public Patient patientInfo { get; set; }
}

public class AllPatients
{
	public string id { get; set; }
	public List<Patient> data { get; set; }
}

public class HistoryJson
{
    public string id { get; set; }
    public string json { get; set; }
}

