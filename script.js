// produtos

const produtos = [
    {
        nome: "Poke Tradicional",
        descricao: "Atum, arroz integral, pepino, cenoura e molho da casa.",
        preco: 36.90
    },
    {
        nome: "Poke Atum Spicy",
        descricao: "Atum, arroz integral, pepino e molho spicy mayo.",
        preco: 42.90
    },
    {
        nome: "Poke Frango Teriyaki",
        descricao: "Frango grelhado, arroz integral e molho teriyaki.",
        preco: 36.90
    },
    {
        nome: "Poke Vegano Zen",
        descricao: "Tofu, quinoa, abacate, edamame e molho de tahine.",
        preco: 34.90
    },
    {
        nome: "Poke Salmão Fresh",
        descricao: "Salmão, arroz integral, abacate e gergelim.",
        preco: 44.90
    },
    {
        nome: "Poke Camarão Tropical",
        descricao: "Camarão, manga, arroz integral e molho tropical.",
        preco: 43.90
    },
    {
        nome: "Poke Vegano Oriental",
        descricao: "Grão de bico, arroz integral e vegetais frescos.",
        preco: 32.90
    },
    {
        nome: "Poke Atum Sesame",
        descricao: "Atum, arroz integral, pepino e molho sesame.",
        preco: 42.90
    }
];

// combos

const combos = [
    {
        nome: "Segunda Leve",
        descricao: "Poke tradicional + suco detox.",
        preco: 45.80
    },
    {
        nome: "Terça Proteica",
        descricao: "Poke frango teriyaki + bebida natural.",
        preco: 45.80
    },
    {
        nome: "Quarta Vegana",
        descricao: "Poke vegano zen + suco verde.",
        preco: 43.80
    },
    {
        nome: "Quinta Low Carb",
        descricao: "Poke low carb + shot detox.",
        preco: 41.80
    },
    {
        nome: "Sexta Especial",
        descricao: "Poke salmão fresh + suco cítrico.",
        preco: 49.80
    },
    {
        nome: "Sábado em Dobro",
        descricao: "Dois pokes tradicionais.",
        preco: 79.80
    },
    {
        nome: "Domingo Energia",
        descricao: "Bowl de iogurte + suco natural.",
        preco: 41.80
    }
];

function salvarDados(nome, dados) {
    localStorage.setItem(nome, JSON.stringify(dados));
}

function buscarDados(nome) {
    return JSON.parse(localStorage.getItem(nome)) || [];
}

const cabecalho = document.getElementById("cabecalho");

if (cabecalho) {
    cabecalho.innerHTML = `
        <a href="index.html" class="logo">
            EDEN
            <small>POKÉ • FIT FOOD</small>
        </a>

        <nav>
            <a href="index.html">INÍCIO</a>
            <a href="cardapio.html">CARDÁPIO</a>
            <a href="combos.html">COMBOS</a>
            <a href="monte.html">MONTE O SEU</a>
            <a href="pedidos.html">PEDIDOS</a>
            <a href="perfil.html">PERFIL</a>
        </nav>

        <div class="acoes">
            <a href="acesso.html" class="botao">MINHA CONTA</a>
            <a href="carrinho.html">╰┈➤ <span id="quantidadeCarrinho">0</span></a>
            <button class="botao-tema" onclick="trocarTema()">☀ / ☾</button>
        </div>
    `;
}

const rodape = document.getElementById("rodape");

if (rodape) {
    rodape.innerHTML = `
        <p>EDEN - POKÉ & FIT FOOD</p>
        <p>Ingredientes frescos, sabor e equilíbrio.</p>
        <p>
            <a href="index.html">Início</a>
            <a href="cardapio.html">Cardápio</a>
            <a href="perfil.html">Minha conta</a>
        </p>
        <p>© 2026 EDEN. Todos os direitos reservados.</p>
    `;
}

// claro e escuro

function trocarTema() {
    document.body.classList.toggle("claro");

    if (document.body.classList.contains("claro")) {
        localStorage.setItem("tema", "claro");
    } else {
        localStorage.setItem("tema", "escuro");
    }
}

if (localStorage.getItem("tema") === "claro") {
    document.body.classList.add("claro");
}

function mostrarProdutos(lista, local) {
    const area = document.getElementById(local);

    if (!area) return;

    area.innerHTML = "";

    if (lista.length === 0) {
        area.innerHTML = "<p>Nenhum produto encontrado.</p>";
        return;
    }

    lista.forEach((produto) => {
        area.innerHTML += `
            <div class="produto">

                <div class="produto-imagem">
                    
                </div>

                <h3>${produto.nome}</h3>

                <p>${produto.descricao}</p>

                <div class="produto-rodape">
                    <span>R$ ${produto.preco.toFixed(2).replace(".", ",")}</span>

                    <button class="adicionar"
                    onclick="adicionarCarrinho('${produto.nome}')">
                        +
                    </button>
                </div>

            </div>
        `;
    });
}

mostrarProdutos(produtos, "produtos");
mostrarProdutos(produtos.slice(0, 4), "destaques");
mostrarProdutos(combos, "combos");

// pesquisar

function buscarProdutos() {
    const campo = document.getElementById("pesquisa");

    if (!campo) return;

    const pesquisa = campo.value.toLowerCase();

    const resultado = produtos.filter((produto) => {
        return produto.nome.toLowerCase().includes(pesquisa);
    });

    mostrarProdutos(resultado, "produtos");
}

const campoPesquisa = document.getElementById("pesquisa");

if (campoPesquisa) {
    campoPesquisa.addEventListener("input", buscarProdutos);
}

// adicionar produto para o carrinho

function adicionarCarrinho(nome) {
    let carrinho = buscarDados("carrinho");

    let produto = produtos.find((item) => item.nome === nome);

    if (!produto) {
        produto = combos.find((item) => item.nome === nome);
    }

    if (!produto) return;

    carrinho.push(produto);

    salvarDados("carrinho", carrinho);

    atualizarQuantidade();

    alert("Produto adicionado ao carrinho!");
}

function atualizarQuantidade() {
    const quantidade = document.getElementById("quantidadeCarrinho");

    if (quantidade) {
        quantidade.innerText = buscarDados("carrinho").length;
    }
}

atualizarQuantidade();

function mostrarCarrinho() {
    const area = document.getElementById("itensCarrinho");

    if (!area) return;

    const carrinho = buscarDados("carrinho");

    area.innerHTML = "";

    let total = 0;

    if (carrinho.length === 0) {
        area.innerHTML = "<p>Seu carrinho está vazio.</p>";
    }

    carrinho.forEach((produto, index) => {
        total += produto.preco;

        area.innerHTML += `
            <div class="item-carrinho">

                <div>
                    <h3>${produto.nome}</h3>
                    <p>R$ ${produto.preco.toFixed(2).replace(".", ",")}</p>
                </div>

                <button onclick="removerProduto(${index})">
                    Remover
                </button>

            </div>
        `;
    });

    const valor = document.getElementById("valorTotal");

    if (valor) {
        valor.innerText = total.toFixed(2).replace(".", ",");
    }
}

mostrarCarrinho();

function removerProduto(index) {
    let carrinho = buscarDados("carrinho");

    carrinho.splice(index, 1);

    salvarDados("carrinho", carrinho);

    mostrarCarrinho();
    atualizarQuantidade();
}

function limparCarrinho() {
    if (confirm("Deseja realmente limpar o carrinho?")) {
        salvarDados("carrinho", []);

        mostrarCarrinho();
        atualizarQuantidade();
    }
}

function finalizarPedido() {
    let carrinho = buscarDados("carrinho");

    if (carrinho.length === 0) {
        alert("Adicione algum produto antes de finalizar!");
        return;
    }

    // o pedido precisa de um cliente: ele vem do cadastro/login
    const usuario = JSON.parse(localStorage.getItem("usuario"));

    if (!usuario) {
        alert("Faça login ou cadastre-se para finalizar o pedido!");
        window.location.href = "acesso.html";
        return;
    }

    let pedidos = buscarDados("pedidos");

    let total = 0;

    carrinho.forEach((produto) => {
        total += produto.preco;
    });

    const novoPedido = {
        numero: pedidos.length + 1,
        produtos: carrinho,
        total: total,
        data: new Date().toLocaleDateString("pt-BR"),
        status: "Pedido recebido"
    };

    pedidos.push(novoPedido);

    salvarDados("pedidos", pedidos);
    salvarDados("carrinho", []);

    // gera o arquivo .json que o sistema em C# vai importar
    exportarPedidoJson(novoPedido, usuario);

    alert("Pedido realizado com sucesso! O arquivo do pedido (.json) foi baixado.");

    // pequena espera para o navegador terminar o download
    setTimeout(() => {
        window.location.href = "pedidos.html";
    }, 600);
}

// gera e baixa o arquivo pedido_EDEN-xxxx.json
// a estrutura precisa bater com as classes PedidoJson, ClienteJson e ItemJson do C#

function exportarPedidoJson(pedido, usuario) {
    const dados = {
        PedidoId: "EDEN-" + String(pedido.numero).padStart(4, "0") + "-" + Date.now(),
        Cliente: {
            Nome: usuario.nome,
            Email: usuario.email,
            Telefone: usuario.telefone || "",
            Cep: usuario.cep || ""
        },
        Itens: pedido.produtos.map((produto) => {
            return {
                Nome: produto.nome,
                Descricao: produto.descricao,
                Preco: produto.preco,
                Quantidade: 1
            };
        }),
        Total: Number(pedido.total.toFixed(2)),
        Data: pedido.data
    };

    const blob = new Blob([JSON.stringify(dados, null, 2)], { type: "application/json" });
    const link = document.createElement("a");

    link.href = URL.createObjectURL(blob);
    link.download = "pedido_" + dados.PedidoId + ".json";

    document.body.appendChild(link);
    link.click();
    link.remove();

    URL.revokeObjectURL(link.href);
}

// historico de pedidos

function mostrarPedidos() {
    const area = document.getElementById("historico");

    if (!area) return;

    const pedidos = buscarDados("pedidos");

    if (pedidos.length === 0) {
        area.innerHTML = "<p>Você ainda não realizou nenhum pedido.</p>";
        return;
    }

    area.innerHTML = "";

    pedidos.forEach((pedido) => {
        let nomes = pedido.produtos.map((produto) => produto.nome).join(", ");

        area.innerHTML += `
            <div class="item-pedido">
                <h3>Pedido #${pedido.numero}</h3>
                <p>${nomes}</p>
                <p>Data: ${pedido.data}</p>
                <p>Status: ${pedido.status}</p>
                <strong>R$ ${pedido.total.toFixed(2).replace(".", ",")}</strong>
            </div>
        `;
    });
}

mostrarPedidos();

// cpf

function mascaraCPF(campo) {
    campo.addEventListener("input", function() {
        let valor = this.value.replace(/\D/g, "");

        valor = valor.substring(0, 11);

        valor = valor.replace(/(\d{3})(\d)/, "$1.$2");
        valor = valor.replace(/(\d{3})(\d)/, "$1.$2");
        valor = valor.replace(/(\d{3})(\d{1,2})$/, "$1-$2");

        this.value = valor;
    });
}

// telefone

function mascaraTelefone(campo) {
    campo.addEventListener("input", function() {
        let valor = this.value.replace(/\D/g, "");

        valor = valor.substring(0, 11);

        valor = valor.replace(/^(\d{2})(\d)/, "($1) $2");
        valor = valor.replace(/(\d{5})(\d)/, "$1-$2");

        this.value = valor;
    });
}

// cep

function mascaraCEP(campo) {
    campo.addEventListener("input", function() {
        let valor = this.value.replace(/\D/g, "");

        valor = valor.substring(0, 8);

        valor = valor.replace(/(\d{5})(\d)/, "$1-$2");

        this.value = valor;
    });
}

["cpf", "perfilCpf"].forEach((id) => {
    const campo = document.getElementById(id);
    if (campo) mascaraCPF(campo);
});

["telefone", "perfilTelefone"].forEach((id) => {
    const campo = document.getElementById(id);
    if (campo) mascaraTelefone(campo);
});

["cep", "perfilCep"].forEach((id) => {
    const campo = document.getElementById(id);
    if (campo) mascaraCEP(campo);
});

document.querySelectorAll(".somente-numeros").forEach((campo) => {
    campo.addEventListener("input", function() {
        this.value = this.value.replace(/\D/g, "");
    });
});

// cadastro

const formCadastro = document.getElementById("formCadastro");

if (formCadastro) {
    formCadastro.addEventListener("submit", function(event) {
        event.preventDefault();

        const nome = document.getElementById("nome").value;
        const cpf = document.getElementById("cpf").value;
        const telefone = document.getElementById("telefone").value;
        const email = document.getElementById("email").value;
        const cep = document.getElementById("cep").value;
        const senha = document.getElementById("senha").value;

        if (cpf.replace(/\D/g, "").length !== 11) {
            alert("Digite um CPF válido com 11 números.");
            return;
        }

        if (telefone.replace(/\D/g, "").length < 10) {
            alert("Digite um telefone válido.");
            return;
        }

        if (cep.replace(/\D/g, "").length !== 8) {
            alert("Digite um CEP válido.");
            return;
        }

        if (senha.length < 6) {
            alert("A senha precisa ter pelo menos 6 caracteres.");
            return;
        }

        const usuario = {
            nome: nome,
            cpf: cpf,
            telefone: telefone,
            email: email,
            cep: cep,
            senha: senha
        };

        localStorage.setItem("usuario", JSON.stringify(usuario));

        alert("Cadastro realizado com sucesso!");

        window.location.href = "perfil.html";
    });
}

const formLogin = document.getElementById("formLogin");

if (formLogin) {
    formLogin.addEventListener("submit", function(event) {
        event.preventDefault();

        const email = document.getElementById("loginEmail").value;
        const senha = document.getElementById("loginSenha").value;

        const usuario = JSON.parse(localStorage.getItem("usuario"));

        if (usuario && usuario.email === email && usuario.senha === senha) {
            alert("Bem-vindo à EDEN!");

            window.location.href = "perfil.html";
        } else {
            alert("E-mail ou senha incorretos. Verifique seus dados.");
        }
    });
}

function carregarPerfil() {
    const usuario = JSON.parse(localStorage.getItem("usuario"));

    if (!usuario) return;

    const campos = {
        perfilNome: usuario.nome,
        perfilEmail: usuario.email,
        perfilCpf: usuario.cpf,
        perfilTelefone: usuario.telefone,
        perfilCep: usuario.cep
    };

    for (let id in campos) {
        const campo = document.getElementById(id);

        if (campo) {
            campo.value = campos[id];
        }
    }
}

carregarPerfil();

const formPerfil = document.getElementById("formPerfil");

if (formPerfil) {
    formPerfil.addEventListener("submit", function(event) {
        event.preventDefault();

        const usuario = {
            nome: document.getElementById("perfilNome").value,
            email: document.getElementById("perfilEmail").value,
            cpf: document.getElementById("perfilCpf").value,
            telefone: document.getElementById("perfilTelefone").value,
            cep: document.getElementById("perfilCep").value
        };

        localStorage.setItem("usuario", JSON.stringify(usuario));

        alert("Dados atualizados com sucesso!");
    });
}

// montar poke

function adicionarPoke() {
    const base = document.querySelector('input[name="base"]:checked');
    const proteina = document.querySelector('input[name="proteina"]:checked');
    const molho = document.querySelector('input[name="molho"]:checked');

    const complementos = document.querySelectorAll(
        'input[name="complemento"]:checked'
    );

    if (complementos.length !== 3) {
        alert("Escolha exatamente 3 complementos!");
        return;
    }

    const lista = [];

    complementos.forEach((item) => {
        lista.push(item.value);
    });

    const nome = "Poke Personalizado";

    const descricao =
        base.value + ", " +
        proteina.value + ", " +
        lista.join(", ") + " e molho " +
        molho.value;

    const poke = {
        nome: nome,
        descricao: descricao,
        preco: 42.90
    };

    let carrinho = buscarDados("carrinho");

    carrinho.push(poke);

    salvarDados("carrinho", carrinho);

    atualizarQuantidade();

    alert("Seu poke foi adicionado ao carrinho!");
}
