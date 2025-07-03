export interface Solicitud {
    id: number;
    titulo: string;
    descripcion: string;
    estado: 'Pendiente' | 'En Proceso' | 'Completada' | 'Cancelada' | string;
    prioridad: 'Baja' | 'Media' | 'Alta' | string;
}

export interface SolicitudCreate {
    titulo: string;
    descripcion: string;
    estado: 'Pendiente';
    prioridad: 'Baja' | 'Media' | 'Alta';
}