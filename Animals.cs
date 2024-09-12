namespace Hobby_Animal
{
    public class Animal
    {
        protected string name;
        protected int exhilaration;
        protected bool state;
        public Animal(string str, int e = 0) { name = str; exhilaration = e; }
        public virtual void Care(Days mood) { }
        public string GetName() { return name; }

        public virtual bool IsAlive() { return this.state; }
        public virtual void SetState() { this.state = false; }
        public int GetExhilaration() { return exhilaration; }

        public void IncreaseBy(int x)
        {
            if (exhilaration + x > 70) exhilaration = 70;
            else exhilaration += x;
        }
        public void DecreaseBy(int x)
        {
            if (exhilaration - x < 0) exhilaration = 0;
            else exhilaration -= x;
        }
    }

    public class Tarantula : Animal
    {
        public Tarantula(string str, int e = 0) : base(str, e) { }

        public override void Care(Days mood)
        {
            mood.CareForTarantula(this);
        }

        public override void SetState() { 
            if (this.exhilaration > 0) this.state = true;
            else this.state = false;
        }
    }

    public class Hamster : Animal
    {
        public Hamster(string str, int e = 0) : base(str, e) { }

        public override void Care(Days mood)
        {
            mood.CareForHamster(this);
        }

        public override void SetState()
        {
            if (this.exhilaration > 0) state = true;
            else state = false;
        }
    }


    public class Cat : Animal
    {
        public Cat(string str, int e = 0) : base(str, e) { }

        public override void Care(Days mood)
        {
            mood.CareForCat(this);
        }

        public override void SetState()
        {
            if (this.exhilaration > 0) state = true;
            else state = false;
        }
    }
}
