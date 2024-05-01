var objetos = [];

function preencherTabela() {
    document.getElementById("corpo-tabela").innerHTML = "";

    var numeroIndice = 1;

        objetos.forEach(obj => {
            var row = "<tr>" +
        "<td>" + numeroIndice + "</td>" +
        "<td id='coluna-descricao'>" + obj.descricao + "</td>" +
        "<td id='coluna-status'><div class='dropdown'>" +
            "<button class='btn dropdown-toggle " + getClass(obj.statusConcluido) + "' onclick='toggleDropdown(" + obj.id + ")' type='button' id='dropdownMenuButton-" + obj.id + "' data-toggle='dropdown' aria-haspopup='true' aria-expanded='false'>" +
                (obj.statusConcluido ? "Concluído" : "A fazer") +
                "</button>" +
            "<div class='dropdown-menu' aria-labelledby='dropdownMenuButton-" + obj.id + "' id='dropdownMenu-" + obj.id + "'>" +
                "<button class='dropdown-item' onclick='editarStatus(" + obj.id + ", true)'>Concluído</button>" +
                "<button class='dropdown-item' onclick='editarStatus(" + obj.id + ", false)'>A fazer</button>" +
                "</div>" +
            "</div></td>" +
        "<td id='coluna-excluir' onclick='excluirTarefa(" + obj.id + ")'><i class='fas fa-trash-alt' id='botao-excluir'></i></td>" +
        "</tr>";
    document.getElementById("corpo-tabela").innerHTML += row;

    numeroIndice++;
        });
}

function toggleDropdown(id) {
    var dropdown = document.getElementById("dropdownMenu-" + id);
dropdown.classList.toggle("show");
}

function editarStatus(id, statusConcluido) {
    var tarefa = objetos.find(obj => obj.id === id);
tarefa.statusConcluido = statusConcluido;
preencherTabela();
}

function obterTarefas() {
    fetch('/Tarefa/ObterTarefas')
        .then(response => {
            if (!response.ok) {
                throw new Error('Erro ao obter as tarefas');
            }

            return response.json();
        })
        .then(data => {
            objetos = data;
            preencherTabela();
        })
        .catch(error => {
            console.error('Erro:', error);
        });
}

function editarStatus(id, statusConcluido) {

    console.log("teste");
    var tarefa = objetos.find(obj => obj.id === id);

    if (tarefa.statusConcluido != statusConcluido) {
        tarefa.statusConcluido = statusConcluido;

    fetch('/Tarefa/AtualizarStatusTarefa/' + id, {
        method: 'PUT',
    headers: {
        'Content-Type': 'application/json'
                },
    body: JSON.stringify(tarefa)
            })
                .then(response => {
                    if (!response.ok) {
                        throw new Error('Erro ao atualizar a tarefa');
                    }
    preencherTabela();
                })
                .catch(error => {
        console.error('Erro:', error);
                });
        }
    else {
        preencherTabela();
        }
}

function getClass(statusConcluido) {
    return statusConcluido ? "btn-concluido" : "btn-a-fazer";
}

function excluirTarefa(id) {
    fetch('/Tarefa/ExcluirTarefa/' + id, {
        method: 'DELETE'
    })
        .then(response => {
            if (!response.ok) {
                throw new Error('Erro ao excluir a tarefa');
            }
            obterTarefas();
        })
        .catch(error => {
            console.error('Erro:', error);
        });
}

function adicionarTarefa() {
    var novaDescricao = document.getElementById("descricao").value;

if (novaDescricao.trim() !== "") {
    fetch('/Tarefa/AdicionarTarefa', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ descricao: novaDescricao })
    })
        .then(response => {
            if (!response.ok) {
                throw new Error('Erro ao adicionar a tarefa');
            }

            obterTarefas();
            document.getElementById("descricao").value = "";
        })
        .catch(error => {
            console.error('Erro:', error);
        });
    }
}

obterTarefas();
