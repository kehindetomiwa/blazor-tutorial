using System.Collections.Generic;

namespace BlazingPizza.Client
{
    public class OrderState
    {
        public Pizza configuringPizza { get; private set; }
        public bool showingConfigureDialog { get; private set; }
        public Order Order { get; private set; } = new Order();

        public  void ShowingConfigurePizzaDialog(PizzaSpecial special)
        {
            configuringPizza = new Pizza()
            {
                Special = special,
                SpecialId = special.Id,
                Size = Pizza.DefaultSize,
                Toppings = new List<PizzaTopping>()
            };
            showingConfigureDialog = true;
        }

        public void CancelConfigurePizzaDialog()
        {
            configuringPizza = null;
            showingConfigureDialog = false;
        }

        public void ConfirmConfigurePizzaDialog()
        {
            Order.Pizzas.Add(configuringPizza);
            configuringPizza = null;

            showingConfigureDialog = false;
        }

        public void ResetOrder()
        {
            Order = new Order();
        }

        public void RemoveConfiguredPizza(Pizza pizza)
        {
            Order.Pizzas.Remove(pizza);
        }

        public void ReplaceOrder(Order order)
        {
            Order = order;
        }
    }
}
