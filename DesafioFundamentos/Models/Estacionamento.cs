namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private string nomeEstacionamento = "";
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(string nomeEstacionamento)
        {
            this.nomeEstacionamento = nomeEstacionamento;
        }

        public void BoasVindas()
        {
            Console.WriteLine($"Seja bem vindo ao sistema do estacionamento {this.nomeEstacionamento}!");
        }

        public void DefinirPrecoInicial()
        {
            while (true)
            {
                Console.WriteLine("Digite o preço inicial:");

                string precoInicialStr = Console.ReadLine().Trim();

                if (!(decimal.TryParse(precoInicialStr, out precoInicial) && this.precoInicial > 0))
                {
                    Console.WriteLine("Valor inicial inválido! Tente novamente.");
                    continue;
                }

                break;
            }
        }

        public void DefinirPrecoPorHora()
        {
            while (true)
            {
                Console.WriteLine("Digite o preço da hora:");

                string valorHoraStr = Console.ReadLine().Trim();

                if (!(decimal.TryParse(valorHoraStr, out precoPorHora) && precoPorHora > 0))
                {
                    Console.WriteLine("Valor da hora inválido! Tente novamente.");
                    continue;
                }

                break;
            }
        }

        public void AdicionarVeiculo()
        {
            while (true)
            {
                Console.WriteLine("Digite a placa do veículo para estacionar:");

                string placa = Console.ReadLine().Trim();

                if (string.IsNullOrEmpty(placa))
                {
                    Console.WriteLine("Placa inválida! Tente novamente.");
                    continue;
                }

                veiculos.Add(placa);

                Console.WriteLine($"Veículo {placa} adicionado!");

                break;
            }
        }

        public void RemoverVeiculo()
        {
            while (true)
            {
                Console.WriteLine("Digite a placa do veículo para remover:");

                string placa = Console.ReadLine().Trim();

                if (string.IsNullOrEmpty(placa))
                {
                    Console.WriteLine("Placa inválida! Tente novamente.");
                    continue;
                }

                int veiculoIndex = BuscarVeiculo(placa);

                if (veiculoIndex == -1)
                {
                    Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
                    continue;
                }

                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                int horasEstacionado = 0;

                decimal valorTotal = 0;

                if (!(int.TryParse(Console.ReadLine(), out horasEstacionado) && horasEstacionado >= 0))
                {
                    Console.WriteLine("Valor de horas estacionadas inválido! Tente novamente.");
                    continue;
                }

                valorTotal = ObterPrecoTotal(horasEstacionado);

                veiculos.RemoveAt(veiculoIndex);

                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: {valorTotal:C2}");

                break;
            }
        }

        public void ListarVeiculos()
        {
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");

                foreach (var placa in veiculos)
                {
                    Console.WriteLine(placa);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }

        private int BuscarVeiculo(string placa)
        {
            return veiculos.FindIndex(placaVeiculoEstacionado => placaVeiculoEstacionado.ToUpper() == placa.ToUpper());
        }

        private decimal ObterPrecoTotal(int horasEstacionado)
        {
            return (horasEstacionado * precoPorHora) + precoInicial;
        }
    }
}
