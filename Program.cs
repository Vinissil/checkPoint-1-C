using System;
using System.Text;
using System.Globalization;

namespace CheckPoint1;

internal static class Program
{
    private static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.WriteLine("=== CHECKPOINT 1 - FUNDAMENTOS C# - Turma 3ESPY ===\n");

        Console.WriteLine("1. DemonstrarTiposDados");
        Console.WriteLine(DemonstrarTiposDados());

        Console.WriteLine("\n2. CalculadoraBasica (switch)");
        Console.WriteLine($"10 + 5 = {CalculadoraBasica(10, 5, '+')}");
        Console.WriteLine($"10 / 0 = {CalculadoraBasica(10, 0, '/')}");
        Console.WriteLine($"10 ? 2 = {CalculadoraBasica(10, 2, '?')}");

        Console.WriteLine("\n3. ValidarIdade (if/else)");
        Console.WriteLine($"8  -> {ValidarIdade(8)}");
        Console.WriteLine($"15 -> {ValidarIdade(15)}");
        Console.WriteLine($"30 -> {ValidarIdade(30)}");
        Console.WriteLine($"80 -> {ValidarIdade(80)}");
        Console.WriteLine($"-1 -> {ValidarIdade(-1)}");

        Console.WriteLine("\n4. ConverterString (TryParse)");
        Console.WriteLine(ConverterString("123", "int"));
        Console.WriteLine(ConverterString("12,5", "double"));
        Console.WriteLine(ConverterString("true", "bool"));
        Console.WriteLine(ConverterString("abc", "int"));

        Console.WriteLine("\n5. ClassificarNota (switch)");
        Console.WriteLine($"9.4  -> {ClassificarNota(9.4)}");
        Console.WriteLine($"8.2  -> {ClassificarNota(8.2)}");
        Console.WriteLine($"6.0  -> {ClassificarNota(6.0)}");
        Console.WriteLine($"3.5  -> {ClassificarNota(3.5)}");
        Console.WriteLine($"11.0 -> {ClassificarNota(11.0)}");

        Console.WriteLine("\n6. GerarTabuada (for)");
        Console.WriteLine(GerarTabuada(5));

        Console.WriteLine("\n7. JogoAdivinhacao (while)");
        Console.WriteLine(JogoAdivinhacao(63, new[] { 50, 75, 63 }));

        Console.WriteLine("\n8. ValidarSenha (do-while)");
        Console.WriteLine($"MinhaSenh@123 -> {ValidarSenha("MinhaSenh@123")}");
        Console.WriteLine($"fraca         -> {ValidarSenha("fraca")}");

        Console.WriteLine("\n9. AnalisarNotas (foreach)");
        Console.WriteLine(AnalisarNotas(new[] { 8.5, 7.0, 9.2, 6.5, 10.0, 4.8 }));

        Console.WriteLine("\n10. ProcessarVendas (foreach múltiplo)");
        var vendas = new[] { 500.0, 1000.0, 300.0, 200.0, 800.0, 700.0 };
        var categorias = new[] { "A", "B", "C", "A", "B", "A" };
        var nomesCategorias = new[] { "A", "B", "C" };
        var comissoes = new[] { 0.10, 0.07, 0.05 };
        Console.WriteLine(ProcessarVendas(vendas, categorias, comissoes, nomesCategorias));

        Console.WriteLine("\nPressione qualquer tecla para sair...");
        Console.ReadKey();
    }

    // Questão 1
    private static string DemonstrarTiposDados()
    {
        int inteiro = 42;
        double decimalzinho = 3.14;
        bool booleano = true;
        char caractere = 'A';
        var texto = "Olá";
        return $"Inteiro: {inteiro}, Decimal: {decimalzinho}, Booleano: {booleano}, Caractere: {caractere}, Texto: {texto}";
    }

    // Questão 2
    private static double CalculadoraBasica(double num1, double num2, char operador)
    {
        switch (operador)
        {
            case '+': return num1 + num2;
            case '-': return num1 - num2;
            case '*': return num1 * num2;
            case '/': return num2 == 0 ? 0 : num1 / num2;
            default: return -1;
        }
    }

    // Questão 3
    private static string ValidarIdade(int idade)
    {
        if (idade < 0 || idade > 120) return "Idade inválida";
        if (idade < 12) return "Criança";
        if (idade < 18) return "Adolescente";
        if (idade <= 65) return "Adulto";
        return "Idoso";
    }

    // Questão 4
    private static string ConverterString(string valor, string tipoDesejado)
    {
        var ptBr = new CultureInfo("pt-BR");

        if (tipoDesejado.Equals("int", StringComparison.OrdinalIgnoreCase))
            return int.TryParse(valor, NumberStyles.Integer, ptBr, out var i) ? $"int: {i}" : "Conversão impossível para int";

        if (tipoDesejado.Equals("double", StringComparison.OrdinalIgnoreCase))
            return double.TryParse(valor, NumberStyles.Float, ptBr, out var d) ? $"double: {d}" : "Conversão impossível para double";

        if (tipoDesejado.Equals("bool", StringComparison.OrdinalIgnoreCase))
            return bool.TryParse(valor, out var b) ? $"bool: {b}" : "Conversão impossível para bool";

        return "Tipo alvo desconhecido";
    }

    // Questão 5
    private static string ClassificarNota(double nota)
    {
        if (nota < 0.0 || nota > 10.0) return "Nota inválida";
        int faixa = (int)Math.Floor(nota);
        switch (faixa)
        {
            case 10:
            case 9: return "Excelente";
            case 8:
            case 7: return "Bom";
            case 6:
            case 5: return "Regular";
            default: return "Insuficiente";
        }
    }

    // Questão 6
    private static string GerarTabuada(int numero)
    {
        if (numero <= 0) return "Número inválido";
        var sb = new StringBuilder();
        for (int i = 1; i <= 10; i++)
            sb.AppendLine($"{numero} x {i} = {numero * i}");
        return sb.ToString();
    }

    // Questão 7
    private static string JogoAdivinhacao(int numeroSecreto, int[] tentativas)
    {
        if (tentativas == null || tentativas.Length == 0) return "Sem tentativas";

        int i = 0;
        var sb = new StringBuilder();

        while (i < tentativas.Length)
        {
            int palpite = tentativas[i];
            if (palpite == numeroSecreto)
            {
                sb.AppendLine($"Tentativa {i + 1}: {palpite} - correto!");
                break;
            }
            sb.AppendLine($"Tentativa {i + 1}: {palpite} - " + (palpite < numeroSecreto ? "muito baixo" : "muito alto"));
            i++;
        }

        if (i == tentativas.Length && tentativas[tentativas.Length - 1] != numeroSecreto)
            sb.Append("Fim das tentativas.");

        return sb.ToString();
    }

    // Questão 8
    private static string ValidarSenha(string senha)
    {
        if (senha == null) return "Senha inválida";

        bool temNumero = false, temMaiuscula = false, temEspecial = false;
        int i = 0;

        do
        {
            if (i >= senha.Length) break;
            char c = senha[i];
            if (char.IsDigit(c)) temNumero = true;
            if (char.IsUpper(c)) temMaiuscula = true;
            if ("!@#$%&*".IndexOf(c) >= 0) temEspecial = true;
            i++;
        } while (i < senha.Length);

        string erros = "";
        if (senha.Length < 8) erros += "- Pelo menos 8 caracteres\n";
        if (!temNumero) erros += "- Pelo menos 1 número\n";
        if (!temMaiuscula) erros += "- Pelo menos 1 letra maiúscula\n";
        if (!temEspecial) erros += "- Pelo menos 1 caractere especial (!@#$%&*)\n";

        return string.IsNullOrEmpty(erros) ? "Senha válida" : "Senha inválida:\n" + erros.TrimEnd();
    }

    // Questão 9
    private static string AnalisarNotas(double[] notas)
    {
        if (notas == null || notas.Length == 0) return "Nenhuma nota para analisar";

        double soma = 0, maior = double.MinValue, menor = double.MaxValue;
        int aprovados = 0, faA = 0, faB = 0, faC = 0, faD = 0, faF = 0;

        foreach (var n in notas)
        {
            soma += n;
            if (n >= 7.0) aprovados++;
            if (n > maior) maior = n;
            if (n < menor) menor = n;

            if (n >= 9.0) faA++;
            else if (n >= 8.0) faB++;
            else if (n >= 7.0) faC++;
            else if (n >= 5.0) faD++;
            else faF++;
        }

        double media = soma / notas.Length;

        return $"Média: {media:F1}\nAprovados: {aprovados}\nMaior: {maior:F1}\nMenor: {menor:F1}\nA: {faA}, B: {faB}, C: {faC}, D: {faD}, F: {faF}";
    }

    // Questão 10
    private static string ProcessarVendas(double[] vendas, string[] categorias, double[] comissoes, string[] nomesCategorias)
    {
        if (vendas == null || categorias == null || comissoes == null || nomesCategorias == null)
            return "Dados inválidos";
        if (vendas.Length != categorias.Length)
            return "Tamanhos incompatíveis entre vendas e categorias";

        double[] totalVendasPorCat = new double[nomesCategorias.Length];
        double[] totalComissaoPorCat = new double[nomesCategorias.Length];

        int idx = 0;
        foreach (var valor in vendas)
        {
            string cat = categorias[idx];

            int indiceCat = -1;
            int k = 0;
            foreach (var nome in nomesCategorias)
            {
                if (string.Equals(nome, cat, StringComparison.OrdinalIgnoreCase))
                {
                    indiceCat = k;
                    break;
                }
                k++;
            }

            if (indiceCat >= 0)
            {
                double perc = (indiceCat < comissoes.Length) ? comissoes[indiceCat] : 0.0;
                totalVendasPorCat[indiceCat] += valor;
                totalComissaoPorCat[indiceCat] += valor * perc;
            }

            idx++;
        }

        var sb = new StringBuilder();
        for (int i = 0; i < nomesCategorias.Length; i++)
            sb.AppendLine($"Categoria {nomesCategorias[i]}: Vendas R$ {totalVendasPorCat[i]:N2}, Comissão R$ {totalComissaoPorCat[i]:N2}");

        return sb.ToString().TrimEnd();
    }
}
