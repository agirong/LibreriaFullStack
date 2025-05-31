export interface parametro {
  status:  number;
  message: string;
  data:    data[];
}

export interface data {
  idParametro:   number;
  codigo:        string;
  valor:         string;
  descripcion:   string;
  estado:        number;
  tipoParametro: string;
}
