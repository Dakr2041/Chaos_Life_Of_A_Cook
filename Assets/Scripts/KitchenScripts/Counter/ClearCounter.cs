using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : BaseCounter {



    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    public override void Interact(Player player)
    {
        if (!HasKitchenObject())
        {
            //no KitchenObject here
            if (player.HasKitchenObject())
            {
                //Player carring something
                player.GetKitchenObject().SetKitchentObjectParent(this);
            } else
            {
                //Player not carring anything
            }
        } else
        {
            //KitchenObject here
            if (player.HasKitchenObject())
            {
                //Player carring something
                if (player.GetKitchenObject().TryGetPlate(out PlateKitchenObject plateKitchenObject))
                {
                    //Player holding a Plate
                    if (plateKitchenObject.TryAddIngredient(GetKitchenObject().GetKitchenObjectSO()))
                    {
                        GetKitchenObject().DestroySelf();
                    }
                } else
                {
                    //Player not holding plate but somthing else
                    if (GetKitchenObject().TryGetPlate(out plateKitchenObject))
                    {
                        //Counter is holding Plate
                        if(plateKitchenObject.TryAddIngredient(player.GetKitchenObject().GetKitchenObjectSO())){
                            player.GetKitchenObject().DestroySelf();
                        }
                    }
                }
            } else
            {
                //Player not carring anything
                GetKitchenObject().SetKitchentObjectParent(player);
            }
        }

    }

   
}
