package ucr.ac.cr.proyecto3_b87107_b84211.adapters;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import org.jetbrains.annotations.NotNull;

import java.util.List;

import ucr.ac.cr.proyecto3_b87107_b84211.R;
import ucr.ac.cr.proyecto3_b87107_b84211.modelos.Alergias;
import ucr.ac.cr.proyecto3_b87107_b84211.modelos.Citas;


public class ListaCitasAdaptar extends RecyclerView.Adapter<ItemCitasViewHolder> {
    private List<Citas> listaCitas;
    private Context context;
    private Boolean contedorMasDetalles=false;

    public ListaCitasAdaptar(List<Citas> listaCitas, Context context) {
        this.listaCitas = listaCitas;
        this.context =context;
    }
    @NonNull
    @Override
    public ItemCitasViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        LayoutInflater inflater = LayoutInflater.from(parent.getContext());
        View itemLista = inflater.inflate(R.layout.item_citas, parent, false);
        ItemCitasViewHolder viewHolder = new ItemCitasViewHolder(itemLista);

        return viewHolder;
    }

    @Override
    public void onBindViewHolder(@NonNull ItemCitasViewHolder holder, int position) {
        final Citas citasActual = listaCitas.get(position);
        holder.fecha.setText(citasActual.getFecha());
        holder.centro_salud.setText(citasActual.getCentro_salud());
        holder.especialidad.setText(citasActual.getEspecialidad());
        holder.descripcion.setText(citasActual.getDescripcion());
        holder.medico.setText(citasActual.getCodigo());

        holder.verDetalles.setOnClickListener(view->{
            if (contedorMasDetalles==false)
            {
                contedorMasDetalles=true;
                holder.layoutDetalles.setVisibility(View.VISIBLE);
                holder.verDetalles.setText(context.getString(R.string.ocultar_detalles));
            }else
            {
                contedorMasDetalles=false;
                holder.layoutDetalles.setVisibility(View.GONE);
                holder.verDetalles.setText(context.getString(R.string.detalles));

            }
        });
    }

    @Override
    public int getItemCount() {
        return listaCitas.size();
    }
}
