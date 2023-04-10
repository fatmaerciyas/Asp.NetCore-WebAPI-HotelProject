namespace RapidApiConsume.Models
{
    public class NetflixMovieViewModel
    {


        public D[] d { get; set; }
        public string q { get; set; }
        public int v { get; set; }


        public class D
        {
            public I i { get; set; }
            public string id { get; set; }
            public string l { get; set; }
            public string q { get; set; }
            public string qid { get; set; }
            public int rank { get; set; }
            public string s { get; set; }
            public int y { get; set; }
            public string yr { get; set; }
        }

        public class I
        {
            public int height { get; set; }
            public string imageUrl { get; set; }
            public int width { get; set; }
        }

    }
}


//y: 2011
