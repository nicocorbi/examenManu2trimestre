using UnityEngine;

public class presetchanger : MonoBehaviour
{
    [SerializeField] MovementStats[] statsList;
    int currentStatIndex = 0;
    [SerializeField] private Movimiento movimientoScript; 

    void Start()
    {
        
        if (movimientoScript == null)
        {
            movimientoScript = GetComponent<Movimiento>(); 
        }
        SetStatsProfile();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            currentStatIndex++;

            if (currentStatIndex >= statsList.Length)
            {
                currentStatIndex = 0;
            }
            SetStatsProfile();
        }
    }
    void SetStatsProfile()
    {
        movimientoScript.UpdateStat(statsList[currentStatIndex]);
        print("preset ha cambiado a:" + statsList[currentStatIndex].name);
    }
}