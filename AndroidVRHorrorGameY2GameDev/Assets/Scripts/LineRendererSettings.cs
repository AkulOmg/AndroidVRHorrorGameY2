using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LineRendererSettings : MonoBehaviour
{

    [SerializeField] LineRenderer rend;

    Vector3[] points;


    public GameObject panel;
    public Image img;
    public Button btn;

    // Start is called before the first frame update
    void Start()
    {

        rend = gameObject.GetComponent<LineRenderer>();

        points = new Vector3[2];

        points[0] = Vector3.zero;

        points[1] = transform.position + new Vector3(0, 0, 20);

        rend.SetPositions(points);
        rend.enabled = true;

        img = panel.GetComponent<Image>();

        

    }

    public LayerMask layerMask;

    public bool AlignLineRenderer(LineRenderer rend)
    {
        Ray ray;
        ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        Debug.DrawRay(ray.origin, ray.direction);
        bool hitBtn = false;
        

        if (Physics.Raycast(ray, out hit, layerMask))
        {
            rend.startColor = Color.red;
            rend.endColor = Color.red;
            btn = hit.collider.gameObject.GetComponent<Button>();
            points[1] = transform.forward + new Vector3(0, 0, hit.distance);
            hitBtn = true;

        }
        else
        {
            points[1] = transform.forward + new Vector3(0, 0, 50);
            rend.startColor = Color.green;
            rend.endColor = Color.green;
            hitBtn = false;
        }
        
        rend.SetPositions(points);
        rend.material.color = rend.startColor;
        return hitBtn;


    }

    private void Update()
    {
        AlignLineRenderer(rend);
        rend.material.color = rend.startColor;
        
        if (AlignLineRenderer(rend) && Input.GetAxis("Submit") > 0)
        {
            btn.onClick.Invoke();
        }
    }

    public void ColorChangeOnClick()
    {
        if (btn != null)
        {
            if (btn.name == "red_btn")
            {
                img.color = Color.red;
            }
            else if(btn.name == "blue_btn")
            {
                img.color = Color.blue;
            }
            else if (btn.name == "green_btn")
            {
                img.color = Color.green;
            }

        }

    }
}
