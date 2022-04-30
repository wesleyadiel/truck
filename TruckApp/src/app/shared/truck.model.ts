export class Truck {
    id: number = 0;
    placa: string = '';
    modelo: string = '';
    anoModelo: string = new Date().getFullYear().toString();
    anoFabricacao: string = new Date().getFullYear().toString();
}
