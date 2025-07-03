CREATE TABLE solicitud
(
    id NUMBER GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    titulo VARCHAR2(255),
    descripcion VARCHAR2(1000),
    estado VARCHAR2(100),
    prioridad VARCHAR2(100)
);

SELECT id, titulo ,descripcion, estado, prioridad FROM solicitud;

DROP TABLE solicitud;

INSERT INTO solicitud (titulo, descripcion, prioridad, estado) VALUES ('Solicitud 1', 'Descripcion', 'Baja', 'Pendiente');
INSERT INTO solicitud (titulo, descripcion, prioridad, estado) VALUES ('Solicitud 2', 'Descripcion2', 'Alta', 'Pendiente');
INSERT INTO solicitud (titulo, descripcion, prioridad, estado) VALUES ('Solicitud 3', 'Descripcion3', 'Media', 'Pendiente');
INSERT INTO solicitud (titulo, descripcion, prioridad, estado) VALUES ('Solicitud 4', 'Descripcion4', 'Media', 'Pendiente');
INSERT INTO solicitud (titulo, descripcion, prioridad, estado) VALUES ('Solicitud 5', 'Descripcion5', 'Baja', 'Pendiente');