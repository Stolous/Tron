using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class ScaleSyncronizer : NetworkBehaviour {
	
	[SyncVar]
	float localScaleZ = 1f;
	
	// Update is called once per frame
	void Update() {
		if(hasAuthority) {
			this.localScaleZ = this.transform.localScale.z;
			CmdSyncScale(this.transform.localScale.z);
		}
		else {
			this.transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, localScaleZ);
		}
	}

	[Command]
	void CmdSyncScale(float scaleZ) {
		this.localScaleZ = scaleZ;
	}
}
