using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using strange.extensions.command.impl;
using UnityEngine;

public class StartGameCommand : Command
{

    [Inject]
    public IGameModel gridModel { get; set; }
    
    
    public override void Execute()
    {
        gridModel.Reset();
        GameObject board = GameObject.Find("Board");
        GameObject boardPH = GameObject.Find("BoardPlaceholder");

        var myLoadedAssetBundle = AssetBundle.LoadFromFile(Path.Combine(Application.streamingAssetsPath, "gridspace"));
        if (myLoadedAssetBundle == null)
        {
            Debug.Log("Failed to load AssetBundle!");
            return;
        }

        GameObject myButtonPrefab = myLoadedAssetBundle.LoadAsset<GameObject>("GridSpace");
        int index = 0;
        foreach (Transform child in boardPH.transform)
        {
            GameObject actualButton = GameObject.Instantiate(myButtonPrefab, child.transform.position, child.transform.rotation, board.transform);
            actualButton.GetComponent<CellView>().idCell = index;
            index++;
        }

    }
}
