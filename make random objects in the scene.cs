{
    public float delay = 0.1f;
    public GameObject cube;
	// Use this for initialization
	void Start () {
        InvokeRepeating("spawn", delay, delay);
	}
	
	// Update is called once per frame
	void spawn () {
        Instantiate(cube, new Vector3(Random.Range(-15,15), 20, 0),Quaternion.identity);
	}

}
