namespace New1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string inputCoffeePrice = CoffeePrice.Text;
            string inputCoffeeQuantity = CoffeeQuantity.Text;
            float coffeePrice, coffeeQuantity;

            bool isValidCoffeePrice = float.TryParse(inputCoffeePrice, out coffeePrice);
            bool isValidCoffeeQuantity = float.TryParse(inputCoffeeQuantity, out coffeeQuantity);

            string inputGreenTeaPrice = GreenTeaPrice.Text;
            string inputGreenTeaQuantity = GreenTeaQuantity.Text;
            float greenTeaPrice, greenTeaQuantity;

            bool isValidGreenTeaPrice = float.TryParse(inputGreenTeaPrice, out greenTeaPrice);
            bool isValidGreenTeaQuantity = float.TryParse(inputGreenTeaQuantity, out greenTeaQuantity);

            string inputNoodlePrice = NoodlePrice.Text;
            string inputNoodleQuantity = NoodleQuantity.Text;
            float noodlePrice, noodleQuantity;

            bool isValidNoodlePrice = float.TryParse(inputNoodlePrice, out noodlePrice);
            bool isValidNoodleQuantity = float.TryParse(inputNoodleQuantity, out noodleQuantity);

            string inputPizzaPrice = PizzaPrice.Text;
            string inputPizzaQuantity = PizzaQuantity.Text;
            float pizzaPrice, pizzaQuantity;

            bool isValidPizzaPrice = float.TryParse(inputPizzaPrice, out pizzaPrice);
            bool isValidPizzaQuantity = float.TryParse(inputPizzaQuantity, out pizzaQuantity);

            float total = 0;

            if (isValidCoffeePrice && isValidCoffeeQuantity &&
                isValidGreenTeaPrice && isValidGreenTeaQuantity &&
                isValidNoodlePrice && isValidNoodleQuantity &&
                isValidPizzaPrice && isValidPizzaQuantity)
            {
                if (Coffee.Checked)
                {
                    float coffeeTotal = coffeePrice * coffeeQuantity;
                    total += coffeeTotal;
                }

                if (GreenTea.Checked)
                {
                    float greenTeaTotal = greenTeaPrice * greenTeaQuantity;
                    total += greenTeaTotal;
                }

                if (Noodle.Checked)
                {
                    float noodleTotal = noodlePrice * noodleQuantity;
                    total += noodleTotal;
                }

                if (Pizza.Checked)
                {
                    float pizzaTotal = pizzaPrice * pizzaQuantity;
                    total += pizzaTotal;
                }

                float discount = 0;
                if (All.Checked)
                {
                    float discountRate = float.TryParse(textBox1.Text, out float rateAll) ? rateAll : 0;
                    discount = total * (discountRate / 100);
                }
                else if (Beverage.Checked)
                {
                    float beverageTotal = (Coffee.Checked ? coffeePrice * coffeeQuantity : 0) +
                                          (GreenTea.Checked ? greenTeaPrice * greenTeaQuantity : 0);
                    float discountRate = float.TryParse(textBox2.Text, out float rateBeverage) ? rateBeverage : 0;
                    discount = beverageTotal * (discountRate / 100);
                }
                else if (Food.Checked)
                {
                    float foodTotal = (Noodle.Checked ? noodlePrice * noodleQuantity : 0) +
                                      (Pizza.Checked ? pizzaPrice * pizzaQuantity : 0);
                    float discountRate = float.TryParse(textBox3.Text, out float rateFood) ? rateFood : 0;
                    discount = foodTotal * (discountRate / 100);
                }

                total -= discount;
                txtTotal.Text = total.ToString("F2");
            }
            else
            {
                MessageBox.Show("กรุณากรอกข้อมูลให้ถูกต้อง!", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!string.IsNullOrEmpty(txtCash.Text))
            {
                float cashReceived = 0;

                bool isValidCash = float.TryParse(txtCash.Text, out cashReceived);

                if (isValidCash)
                {
                    if (cashReceived >= total)
                    {
                        float change = cashReceived - total;
                        txtChange.Text = change.ToString("F2");

                        int[] denominations = { 1000, 500, 100, 50, 20, 10, 5, 1 };
                        float remainingChange = change;

                        txt1000.Text = txt500.Text = txt100.Text = txt50.Text =
                            txt20.Text = txt10.Text = txt5.Text = txt1.Text = "";

                        for (int i = 0; i < denominations.Length; i++)
                        {
                            int count = (int)(remainingChange / denominations[i]);
                            remainingChange %= denominations[i];

                            switch (denominations[i])
                            {
                                case 1000: txt1000.Text = count.ToString(); break;
                                case 500: txt500.Text = count.ToString(); break;
                                case 100: txt100.Text = count.ToString(); break;
                                case 50: txt50.Text = count.ToString(); break;
                                case 20: txt20.Text = count.ToString(); break;
                                case 10: txt10.Text = count.ToString(); break;
                                case 5: txt5.Text = count.ToString(); break;
                                case 1: txt1.Text = count.ToString(); break;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("เงินที่ได้รับน้อยกว่าราคาสินค้า!", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("กรุณากรอกจำนวนเงินสดที่ถูกต้อง!", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

        }
    }
}







