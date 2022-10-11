using UnityEngine;
using System.Collections;
using System;


public class player_movement : MonoBehaviour
{

	public float rotationPeriod = 0.3f;
	Vector3 scale;

	bool isRotate = false;
	float directionX = 0;
	float directionZ = 0;

	bool dash = false;

	float startAngleRad = 0;
	Vector3 startPos;
	float rotationTime = 0;
	float radius = 1;
	Quaternion fromRotation;
	Quaternion toRotation;

	bool rightLimit = false;
	bool leftLimit = false;
	bool frontLimit = false;
	bool backLimit = false;

	int dashStep = 0;

	// Use this for initialization
	void Start()
	{

		scale = transform.lossyScale;

	}


	void Update()
	{

		float x = 0;
		float y = 0;

		x = Input.GetAxisRaw("Horizontal");
		if (x == 0)
		{
			y = Input.GetAxisRaw("Vertical");
		}


		if ((x != 0 || y != 0) && !isRotate)
		{
			directionX = y;
			directionZ = x;
			if (rightLimit == true && x > 0)
			{
				directionZ = 0;
			}
			if (leftLimit == true && x < 0)
			{
				directionZ = 0;
			}
			if (frontLimit == true && y > 0)
			{
				directionX = 0;
			}
			if (backLimit == true && y < 0)
			{
				directionX = 0;
			}
			startPos = transform.position;
			fromRotation = transform.rotation;
			transform.Rotate(directionZ * 90, 0, directionX * 90, Space.World);
			toRotation = transform.rotation;
			transform.rotation = fromRotation;
			setRadius();
			rotationTime = 0;
			dash = false;
			if (Input.GetKey("space") == false)
			{
				isRotate = true;
			}
		}

		else
		{
			startPos.x = (float)Math.Round((double)startPos.x, 1);
			startPos.y = (float)Math.Round((double)startPos.y, 1);
			startPos.z = (float)Math.Round((double)startPos.z, 1);
			//transform.position = new Vector3(startPos.x, startPos.y, startPos.z);
		}
	}

	void FixedUpdate()
	{
		if (Input.GetKey("space") && dashStep < 4 && !isRotate)
		{
			dash = true;
			startPos = transform.position;
			if (Input.GetKey("right") && rightLimit == false)
			{
				startPos.z = startPos.z + 1;
				dashStep++;
			}
			if (Input.GetKey("down") && backLimit == false)
			{
				startPos.x = startPos.x + 1;
				dashStep++;
			}
			if (Input.GetKey("left") && leftLimit == false)
			{
				startPos.z = startPos.z - 1;
				dashStep++;
			}
			if (Input.GetKey("up") && frontLimit == false)
			{
				startPos.x = startPos.x - 1;
				dashStep++;
			}
			dash = false;
			transform.position = startPos;
		}

		if (Input.GetKey("space") == false)
		{
			dashStep = 0;
		}

		if (isRotate)
		{
			rotationTime += (Time.fixedDeltaTime / 1.5f);
			

			

			float ratio = Mathf.Lerp(0, 1, rotationTime / rotationPeriod);

			float thetaRad = Mathf.Lerp(0, Mathf.PI / 2f, ratio);
			float distanceX = -directionX * radius * (Mathf.Cos(startAngleRad) - Mathf.Cos(startAngleRad + thetaRad));
			float distanceY = radius * (Mathf.Sin(startAngleRad + thetaRad) - Mathf.Sin(startAngleRad));
			float distanceZ = directionZ * radius * (Mathf.Cos(startAngleRad) - Mathf.Cos(startAngleRad + thetaRad));
			transform.position = new Vector3(startPos.x + distanceX, startPos.y + distanceY, startPos.z + distanceZ);

			transform.rotation = Quaternion.Lerp(fromRotation, toRotation, ratio);

			if (ratio == 1)
			{
				isRotate = false;
				directionX = 0;
				directionZ = 0;
				rotationTime = 0;
			}
		}
	}

    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "WallRight")
        {
            rightLimit = true;
        }
        if (collisionInfo.collider.tag == "WallLeft")
        {
            leftLimit = true;
        }
        if (collisionInfo.collider.tag == "WallFront")
        {
            frontLimit = true;
        }
        if (collisionInfo.collider.tag == "WallBack")
        {
            backLimit = true;
        }
        if (collisionInfo.collider.tag == "Top")
        {
            isRotate = false;
        }

        if (collisionInfo.gameObject.CompareTag("Collectable"))
        {
            collisionInfo.gameObject.SetActive(false);
        }

    }

    void OnCollisionStay(Collision collisionInfo)
	{
		if (collisionInfo.collider.tag == "WallRight")
		{
			rightLimit = true;
		}
		if (collisionInfo.collider.tag == "WallLeft")
		{
			leftLimit = true;
		}
		if (collisionInfo.collider.tag == "WallFront")
		{
			frontLimit = true;
		}
		if (collisionInfo.collider.tag == "WallBack")
		{
			backLimit = true;
		}
	}

	void OnCollisionExit(Collision collisionInfo)
	{
		if (collisionInfo.collider.tag == "WallRight")
		{
			rightLimit = false;
		}
		if (collisionInfo.collider.tag == "WallLeft")
		{
			leftLimit = false;
		}
		if(collisionInfo.collider.tag == "WallFront")
		{
			frontLimit = false;
		}
		if (collisionInfo.collider.tag == "WallBack")
		{
			backLimit = false;
		}
	}

	void setRadius()
	{

		Vector3 dirVec = new Vector3(0, 0, 0);
		Vector3 nomVec = Vector3.up;

		if (directionX != 0)
		{
			dirVec = Vector3.right;
		}
		else if (directionZ != 0)
		{
			dirVec = Vector3.forward;
		}

		if (Mathf.Abs(Vector3.Dot(transform.right, dirVec)) > 0.99)
		{
			if (Mathf.Abs(Vector3.Dot(transform.up, nomVec)) > 0.99)
			{
				radius = Mathf.Sqrt(Mathf.Pow(scale.x / 2f, 2f) + Mathf.Pow(scale.y / 2f, 2f));
				startAngleRad = Mathf.Atan2(scale.y, scale.x);
			}
			else if (Mathf.Abs(Vector3.Dot(transform.forward, nomVec)) > 0.99)
			{
				radius = Mathf.Sqrt(Mathf.Pow(scale.x / 2f, 2f) + Mathf.Pow(scale.z / 2f, 2f));
				startAngleRad = Mathf.Atan2(scale.z, scale.x);
			}

		}
		else if (Mathf.Abs(Vector3.Dot(transform.up, dirVec)) > 0.99)
		{
			if (Mathf.Abs(Vector3.Dot(transform.right, nomVec)) > 0.99)
			{
				radius = Mathf.Sqrt(Mathf.Pow(scale.y / 2f, 2f) + Mathf.Pow(scale.x / 2f, 2f));
				startAngleRad = Mathf.Atan2(scale.x, scale.y);
			}
			else if (Mathf.Abs(Vector3.Dot(transform.forward, nomVec)) > 0.99)
			{
				radius = Mathf.Sqrt(Mathf.Pow(scale.y / 2f, 2f) + Mathf.Pow(scale.z / 2f, 2f));
				startAngleRad = Mathf.Atan2(scale.z, scale.y);
			}
		}
		else if (Mathf.Abs(Vector3.Dot(transform.forward, dirVec)) > 0.99)
		{
			if (Mathf.Abs(Vector3.Dot(transform.right, nomVec)) > 0.99)
			{
				radius = Mathf.Sqrt(Mathf.Pow(scale.z / 2f, 2f) + Mathf.Pow(scale.x / 2f, 2f));
				startAngleRad = Mathf.Atan2(scale.x, scale.z);
			}
			else if (Mathf.Abs(Vector3.Dot(transform.up, nomVec)) > 0.99)
			{
				radius = Mathf.Sqrt(Mathf.Pow(scale.z / 2f, 2f) + Mathf.Pow(scale.y / 2f, 2f));
				startAngleRad = Mathf.Atan2(scale.y, scale.z);
			}
		}
	}
}