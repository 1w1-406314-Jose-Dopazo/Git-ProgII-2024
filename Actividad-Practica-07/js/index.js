

const Lista_Turnos =
[
    {
        cliente:"jhon",
        fecha: '20-10-2023'
    },
    {
        cliente:"doe",
        fecha: '15-05-2024'
    }
]

function Consultar_turnos()
{
    var table = ''
    table+='<table border=1>';
    table+='<th>Cliente</th>';
    table+='<th>Fecha</th>';
    Lista_Turnos.forEach(turno=>
        {
            table+='<tr>';
            table+='<td>';
            table+=turno.cliente.toString();
            table+='</td>';
            table+='<td>';
            table+=turno.fecha.toString();
            table+='</td>';
            table+='</tr>';
        });
    table+='</table>';
    
    document.getElementById("tabla_container").innerHTML=table
};