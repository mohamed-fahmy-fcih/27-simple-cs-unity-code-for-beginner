{

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.position += new Vector3(Input.GetAxis("Horizontal"), 0, 0);
	}
  }