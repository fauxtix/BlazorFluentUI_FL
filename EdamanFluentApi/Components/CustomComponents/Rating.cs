using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components;

namespace EdamanFluentApi.Components.CustomComponents
{
    public class Rating : IComponent
    {
        private RenderHandle _renderHandle;
        [Parameter]
        public int Value { get; set; }
        void IComponent.Attach(RenderHandle renderHandle)
        {
            _renderHandle = renderHandle;
        }
        Task IComponent.SetParametersAsync(ParameterView parameters)
        {
            foreach (var entry in parameters)
            {
                switch (entry.Name)
                {
                    case nameof(Value):
                        Value = (int)entry.Value;
                        break;
                }
            }
            _renderHandle.Render(RenderDelegate);
            return Task.CompletedTask;
        }
        private void RenderDelegate(RenderTreeBuilder builder)
        {
            int max = Math.Min(Value, 5);
            int seq = 1;
            for (var i = 0; i < max; i++)
            {
                builder.OpenElement(seq++, "span");
                builder.AddAttribute(seq++,
                          "style", "color:#f49813;font-size:30px");
                builder.AddContent(seq++, "★");
                builder.CloseElement();
            }
        }
    }
}
